using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Monsters : MonoBehaviour {
    public float curHp;
    public int maxHp;
    public int moneyToGive;
    public int scoreToGive;
    public int baseDamage;
    public int damageAdd;
    public int curLvl;
    public int myTime;
    public Image healthBarFill;
    public TextMeshProUGUI timerMonster;
    public static Monsters instance;

    void Awake()
    {
        InvokeRepeating("Time", 1f, 1f);
        instance = this;
    }
    public void Stat(int lvl)
    {
        curLvl = lvl;
        curHp = curHp * lvl;
        maxHp = maxHp * lvl;
        moneyToGive = moneyToGive * lvl;
        scoreToGive = scoreToGive * lvl;
        Debug.Log(curLvl);
}

    public void DamageAutoclic(float damageTaken) {
        curHp = curHp - damageTaken;
        healthBarFill.fillAmount = (float)curHp/(float)maxHp;
        if(curHp <= 0){
            Killed();
        }
    }
    public void Power(int damage) {
        damageAdd = damage;
    }
    public void Damage() {
        //damage = 1;
        baseDamage = 1;
        curHp = curHp - (baseDamage + damageAdd);
        Debug.Log(baseDamage);
        healthBarFill.fillAmount = (float)curHp/(float)maxHp;
        if(curHp <= 0){
            Killed();
        }
    }
    public void Killed() {
        GameManager.instance.AddMoney(moneyToGive);
        GameManager.instance.AddScore(scoreToGive);
        MonstersManager.instance.Replace(gameObject);
        MonstersManager.instance.LevelUp(curLvl);
    }
    public void Time()
    {
        myTime--;
        timerMonster.text = myTime.ToString();
        if (myTime <= 0)
        {
            Flee();
        }
    }
    public void Flee() {
        MonstersManager.instance.Replace(gameObject);
        MonstersManager.instance.LevelDown(curLvl);
        GameManager.instance.AddMoney(0);
        GameManager.instance.AddScore(0);
    }
}
