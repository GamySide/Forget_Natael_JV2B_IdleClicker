using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTransfer : MonoBehaviour {
    public static ScoreTransfer instance;
    public int score;
    void Awake()
    {
        instance = this;
    }

    public void ScoreToTransfer(int theScore) {
        score = theScore;
        Debug.Log(score);
    }
}
