using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //左矢印が押された時
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-1, 0, 0); //左に「1」動かす
        }
        //右矢印が押された時
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0); //右に「1」動かす
        }
        //上矢印が押された時
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0); //上に「1」動かす
        }
        //下矢印が押された時
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0); //下に「１」動かす
        }


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
       this.transform.position += new Vector3(x/2, y/2,0);
        float xr = Input.GetAxisRaw("Horizontal2");
        float yr = Input.GetAxisRaw("Vertical2");
        float z = xr * yr;
        this.transform.rotation =  new Quaternion(0,0,z,1);

    }
}
