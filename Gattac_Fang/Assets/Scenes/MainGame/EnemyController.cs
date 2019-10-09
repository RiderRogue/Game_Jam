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

    float speed;
    float enemy_x =0.0f;
    float enemy_y = 0.0f;

    //GameObject player;

    Vector3 forwardVector=new Vector3(0,1,0);
    //0で移動、1で回転、2で攻撃。
    int state = 0;
    int count = 0;
    void Start()
    {
       // player = GameObject.Find("TestPlayerBody");
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case 0:
                this.transform.position += forwardVector * 0.2f;

                break;
            case 1://回転。
                forwardVector = Quaternion.Euler(0, 0, 4) * forwardVector;
                this.transform.Rotate(new Vector3(0, 0, 4));
                break;
            case 2:

                break;
            default:
                break;
        }

       

        //カメラ範囲内での移動制限。
        this.transform.position= new Vector3(Mathf.Clamp(this.transform.position.x, Camera_left, Camera_right),
           Mathf.Clamp(this.transform.position.y, Camera_down, Camera_up) );

        
        count++;
        if (count > 30)
        {
            state++;
            if (state >= 2)
            {
                state = 0;
            }
            count = 0;
        }

    }
}
