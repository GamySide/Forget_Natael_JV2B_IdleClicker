using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monsters : MonoBehaviour {
    public float curHp;
    public int maxHp;
    public int moneyToGive;
    public int baseDamage;
    public int damageAdd;
    public int curLvl;
    public Image healthBarFill;
    public static Monsters instance;

    void Awake()
    {
        instance = this;
    }
    public void Stat(int lvl)
    {
        curLvl = lvl;
        curHp = curHp * lvl;
        maxHp = maxHp * lvl;
        moneyToGive = moneyToGive * lvl;
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
        MonstersManager.instance.Replace(gameObject);
        MonstersManager.instance.LevelUp(curLvl);
    }
}
