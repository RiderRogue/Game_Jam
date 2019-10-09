using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(1, 0, 0); //右に「1」動かす
        }
        //上矢印が押された時
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(0, 1, 0); //上に「1」動かす
        }
        //下矢印が押された時
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(0, -1, 0); //下に「１」動かす
        }
    }
}
