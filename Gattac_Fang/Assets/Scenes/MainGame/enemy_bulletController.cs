using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bulletController : MonoBehaviour
{
    //移動先を示す単位ベクトル。
    public Vector3 e_bulletVector=new Vector3(0,1,0);
    //弾速。
    float move = 1.0f;
    //プレイヤーの半径。
    public float player_r=00.1f;
    //敵弾の半径。
    public float enemybullet_r = 0.008f;
    //プレイヤーのオブジェクト。
    GameObject player;

    //発射方向を代入。
    public void Shot(Vector3 vector_1, Vector3 vector_2,float b_move)
    {
        e_bulletVector = vector_1;
        this.transform.position = vector_2;
        move = b_move;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("TestPlayerBody");//追加。
        
        //this.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //移動。
        this.transform.position += e_bulletVector* (move*0.05f);
        //画面外に出たら削除。
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
        //当たり判定。
        //プレイヤーから弾へ向かうベクトルを計算。
        Vector3 dir = transform.position-this.player.transform.position;
        float d = dir.magnitude;//長さを計算。

        if(d< player_r+ enemybullet_r)
        {
            //監督スクリプトにプレイヤーと衝突したことを報告
            GameObject director = GameObject.Find("MainGameDirector");
            director.GetComponent<MainGamedirector>().DecreaseHp();
            //衝突した場合は弾(自分自身)を消す。
            Destroy(this.gameObject);
        }
    }
}
