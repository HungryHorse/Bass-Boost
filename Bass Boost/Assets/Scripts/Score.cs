using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score;
    public Text text;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = ("Score: " + score);
	}

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
