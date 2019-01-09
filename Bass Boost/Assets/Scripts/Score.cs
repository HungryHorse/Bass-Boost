using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score;
    public Text scoreText;
    public Text musicTimeLeft;
    public Text finalScore;
    public GameObject gameplayUI;
    public GameObject gameoverUI;
    public AudioSource music;
    public CursorManager cursorManager;

    private float musicLength;
	// Use this for initialization
	void Start ()
    {
        score = 0;
        musicLength = music.clip.length;
	}
	
	// Update is called once per frame
	void Update ()
    {
        string minutes = Mathf.Floor(musicLength / 60).ToString("00");
        string seconds = (musicLength % 60).ToString("00");

        scoreText.text = ("Score: " + score);
        musicTimeLeft.text = ("Time: " + string.Format("{0}:{1}", minutes, seconds));
        musicLength -= Time.deltaTime;
        if(musicLength <= 0.1)
        {
            finalScore.text = score.ToString();
            SetHighScore(PlayerPrefs.GetInt("SongPicked"));
            gameplayUI.SetActive(false);
            gameoverUI.SetActive(true);
            Time.timeScale = 0;
            cursorManager.makeCursorVisable();
        }
	}

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void SetHighScore(int songIndex)
    {
        switch (songIndex)
        {
            case 0:
                PlayerPrefs.SetInt("SongOneScore", score);
                break;
            case 1:
                PlayerPrefs.SetInt("SongTwoScore", score);
                break;
            case 2:
                PlayerPrefs.SetInt("SongThreeScore", score);
                break;
        }
        
    }
}
