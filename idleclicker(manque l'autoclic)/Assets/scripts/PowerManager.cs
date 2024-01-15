using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerManager : MonoBehaviour {
    public int curLvl = 0;
    public int cost = 10;
    public int myMoney;
    public static PowerManager instance;
    public TextMeshProUGUI pwrLvlText;
    public TextMeshProUGUI pwrCostText;

    void Awake()
    {
        instance = this;
        
    }
    public void MyMoney(int amount)
    {
        myMoney = amount;
    }
    public void Upgrade()
    {
        if (myMoney >= cost) {
            Debug.Log(myMoney);
            GameManager.instance.TakeMoney(cost);
            myMoney = myMoney - cost;
            curLvl++;
            cost = cost + 2 * curLvl;
            pwrCostText.text = "prix : " + cost.ToString() + "€";
            pwrLvlText.text = "lvl: " + curLvl.ToString();
           
        }
        /*Debug.Log("coucou");
        GameManager.instance.TakeMoney(cost);
        curLvl++;
        cost = cost + 2 * curLvl;*/

    }
    public void Update() {
        Monsters.instance.Power(curLvl);
    }

}
