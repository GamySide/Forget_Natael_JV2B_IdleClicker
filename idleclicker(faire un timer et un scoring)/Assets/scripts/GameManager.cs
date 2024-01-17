using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int money = 0;
    public int min = 9;
    public int sec = 60;
    public int theScore = 0;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timer;
    public static GameManager instance;
    public int curMonsterLvl;
    void Awake () {
        instance = this;
        InvokeRepeating("Time", 1f, 1f);
    }

    public void AddMoney (int amount) {
        money += amount;
        moneyText.text = "€" + money.ToString();
        AutoClickManager.instance.MyMoney(money);
        PowerManager.instance.MyMoney(money);
    }
    public void AddScore(int score)
    {
        theScore += score;
        scoreText.text = "score:" + theScore.ToString();
    }
    public void TakeMoney (int amount) {
        AutoClickManager.instance.MyMoney(money);
        PowerManager.instance.MyMoney(money);
        money -= amount;
        moneyText.text = "€" + money.ToString();
    }
    public void Min()
    {
        min--;
    }
    public void Time()
    {
        sec--;
        timer.text = "0" + min.ToString() + ":" + sec.ToString();
        if (sec <= 0)
        {
            sec = 59;
            Min();
        }
    }
    public void Update() {
        if (sec <= 0 && min <= 0)
        {
            SceneManager.LoadScene(1);
        }
        ScoreTransfer.instance.ScoreToTransfer(theScore);

    }
}

