using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonstersManager : MonoBehaviour {
    
    public GameObject[] monsterPrefabs;
    public Monsters curMonster;
    public Transform canvas;
    public static MonstersManager instance;
    public int lvl;

    void Awake() {
        instance = this;
        lvl = 1;
        Spawn();
    }

    // Spawn Monster
    public void Spawn() {
        GameObject monsterToSpawn = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        GameObject obj = Instantiate(monsterToSpawn, canvas);

        curMonster = obj.GetComponent<Monsters>();
    }
    // Replace Monster
    public void Replace(GameObject monster){
        Destroy(monster);
        Spawn();
    }
    public void LevelUp(int lvlNow)
    {
        lvl = lvlNow + 1;
        Monsters.instance.Stat(lvl);
    }
    public void LevelDown(int lvlNow)
    {
        if (lvl > 1)
        {
            lvl = lvlNow - 1;
        }
        Monsters.instance.Stat(lvl);
    }
    /*public void Update()
    {
        
    }*/


}   
