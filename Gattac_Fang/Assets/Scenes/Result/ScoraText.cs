using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  ////ここを追加////

public class ScoraText : MonoBehaviour
{
    //スコアを格納する。
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "総得点　" + score.ToString() + "点";
    }
}
