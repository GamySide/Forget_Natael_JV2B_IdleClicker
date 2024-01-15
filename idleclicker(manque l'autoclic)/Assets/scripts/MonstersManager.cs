using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersManager : MonoBehaviour {
    
    public GameObject[] monsterPrefabs;
    public Monsters curMonster;
    public Transform canvas;
    public static MonstersManager instance;

    void Awake() {
        instance = this;
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


}   
