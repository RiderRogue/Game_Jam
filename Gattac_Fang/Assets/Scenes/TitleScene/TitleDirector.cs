﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;          //シーンマネジメントを有効にする

public class TitleDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) //任意のボタンを押した場合。
        {
            SceneManager.LoadScene("MainGameScene");//gameシーンをロードする。
        }
    }
}
