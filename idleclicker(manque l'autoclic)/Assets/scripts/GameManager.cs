using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class GameManager : MonoBehaviour {

    public int money = 2;
    public TextMeshProUGUI moneyText;
    public static GameManager instance;

    void Awake () {
        instance = this;
    }

    public void AddMoney (int amount) {
        money += amount;
        moneyText.text = "€" + money.ToString();
        AutoClickManager.instance.MyMoney(money);
        PowerManager.instance.MyMoney(money);
    }
    public void TakeMoney (int amount) {
        AutoClickManager.instance.MyMoney(money);
        PowerManager.instance.MyMoney(money);
        money -= amount;
        moneyText.text = "€" + money.ToString();
    }
}
