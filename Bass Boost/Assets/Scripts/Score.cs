using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score;
    public Text scoreText;
    public Text musicTimeLeft;
    public AudioSource music;

    private float musicLength;
	// Use this for initialization
	void Start () {
        score = 0;
        musicLength = music.clip.length / 60;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = ("Score: " + score);
        musicTimeLeft.text = ("Time: " + musicLength);
	}

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
