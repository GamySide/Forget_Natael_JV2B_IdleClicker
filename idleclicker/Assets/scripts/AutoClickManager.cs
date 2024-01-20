using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoClickManager : MonoBehaviour
{
    public int curLvl = 0;
    public int cost = 500;
    public float power = 0;
    public int myMoney;

    public static AutoClickManager instance;
    public TextMeshProUGUI autoLvlText;
    public TextMeshProUGUI autoCostText;


    void Awake()
    {
        instance = this;
        InvokeRepeating("DoDamage", 0.1f, 0.1f);
        power = 0.0f;
    }
    public void MyMoney(int amount)
    {
        myMoney = amount;
    }

    public void Upgrade()
    {
        if (myMoney >= cost)
        {
            GameManager.instance.TakeMoney(cost);
            myMoney = myMoney - cost;
            curLvl++;
            power += 1.5f;
            cost = cost + 500;
            autoCostText.text = "prix : " + cost.ToString() + "€";
            autoLvlText.text = "lvl: " + curLvl.ToString();
            Debug.Log(myMoney);

        }
        /*Debug.Log("coucou");
        GameManager.instance.TakeMoney(cost);
        curLvl++;
        cost = cost + 2 * curLvl;*/

    }

    public void DoDamage()
    {
        Monsters.instance.DamageAutoclic(power);
    }
}
    

