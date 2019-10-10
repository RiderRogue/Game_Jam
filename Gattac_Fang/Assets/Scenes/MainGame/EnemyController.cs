using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    //カメラの範囲。
    const float Camera_up = 4.8f;
    const float Camera_down = -4.8f;
    const float Camera_right = 5.0f;
    const float Camera_left = -5.0f;

    GameObject player;
    public GameObject enemy_bulletPrefab;
    Vector3 forwardVector = new Vector3(0, 1, 0);
    //0で移動、1で回転、2で攻撃。
    int state = 0;
    //敵の行動に関わるカウント。
    int count = 0;
    //ランダム。
    float random = 1.0f;
    float player_rot = 0.0f;
    void Start()
    {
        player = GameObject.Find("TestPlayerBody");
    }

    // Update is called once per frame
    void Update()
    {

        switch (state)
        {
            case 0:
                this.transform.position += forwardVector * (random / 10.0f);

                break;
            case 1://回転。
                //forwardVector（前方ベクトル）も傾ける。
                forwardVector = Quaternion.Euler(0, 0, (random % 5.0f))* forwardVector;
                this.transform.Rotate(new Vector3(0, 0, (random%5.0f)));
                break;
            case 2://攻撃。
                if (count == 0)
                {
                    Vector3 player_enemy = player.transform.position - this.transform.position;
                    player_enemy.Normalize();
                    float cos = Vector3.Dot(player_enemy, forwardVector);
                    float rad = Mathf.Acos(cos);
                    float degree = rad * Mathf.Rad2Deg;//プレイヤーまでの角度を求める。
                    degree /= 10.0f;//10当分。10フレームで回転させる。
                    player_rot = degree;
                }

                if (count < 10)
                {
                    forwardVector = Quaternion.Euler(0, 0, player_rot) * forwardVector;
                    this.transform.Rotate(new Vector3(0, 0, player_rot));
                }
                else
                {
                    if (count%8==0)
                    {
                        EnemyShot();
                    }
                   
                }

                break;
            default:
                break;
        }



        //カメラ範囲内での移動制限。
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, Camera_left, Camera_right),
           Mathf.Clamp(this.transform.position.y, Camera_down, Camera_up));


        count++;
        if (count > 30)
        {
            state++;
            if (state > 2)
            {
                state = 0;
            }
            if (state > 1)
            {
                if (Random.Range(1, 4) % 3 == 0)
                {
                    state = 2;
                }
                else
                {
                    state = 0;
                }
                
            }
            count = 0;
            random = Random.Range(1.0f, 3.0f);
        }

    }

    public void EnemyShot()
    {
        //弾の生成と初期化。
        GameObject go = Instantiate(enemy_bulletPrefab) as GameObject;
       
        go.GetComponent<enemy_bulletController>().Shot(
            forwardVector,this.transform.position,random);
    }
}
