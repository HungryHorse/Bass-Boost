using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelectManager : MonoBehaviour
{
    public Text title;
    public Text length;
    public Text highScore;
    public AudioClip[] songs;

    private void Start()
    {
        SongOne();
    }

    public void SongOne()
    {
        title.text = songs[0].name;
        length.text = "Length: " + secondsMinuets(songs[0].length);
        highScore.text = "High Score: " + PlayerPrefs.GetInt("SongOneScore");
        PlayerPrefs.SetInt("SongPicked", 0);
    }

    public void SongTwo()
    {
        title.text = songs[1].name;
        length.text = "Length: " + secondsMinuets(songs[1].length);
        highScore.text = "High Score: " + PlayerPrefs.GetInt("SongTwoScore");
        PlayerPrefs.SetInt("SongPicked", 1);
    }

    public void SongThree()
    {
        title.text = songs[2].name;
        length.text = "Length: " + secondsMinuets(songs[2].length);
        highScore.text = "High Score: " + PlayerPrefs.GetInt("SongThreeScore");
        PlayerPrefs.SetInt("SongPicked", 2);
    }


    public string secondsMinuets(float musicLength)
    {
        string minutes = Mathf.Floor(musicLength / 60).ToString("00");
        string seconds = (musicLength % 60).ToString("00");

        string musicTime = string.Format("{0}:{1}", minutes, seconds);

        return musicTime;
    }
}
