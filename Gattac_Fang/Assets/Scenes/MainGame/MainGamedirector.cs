using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGamedirector : MonoBehaviour
{
    GameObject HP_Gauge;
    // Start is called before the first frame update
    void Start()
    {
        this.HP_Gauge = GameObject.Find("HP_gauge");
    }

    public void DecreaseHp()
    {
        this.HP_Gauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
