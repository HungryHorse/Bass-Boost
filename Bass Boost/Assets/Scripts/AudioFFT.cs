using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFFT : MonoBehaviour {

    public PlayerMovement move;
    public Light pointRed;
    public Light pointGreen;
    public Light pointBlue;
    public int audioClipToPlay;
    public AudioClip[] audioClips;
    AudioSource audioSource;
    private float[] samples = new float[512];
    public float[] freqBands = new float[8];
    private float bassAverage;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClips[PlayerPrefs.GetInt("SongPicked")];
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        CreateBands();

        float average = 0;
        for(int i = 2; i < 7; i++)
        {
            average += freqBands[i];
        }
        average /= 6;

        bassAverage = ((freqBands[0] + freqBands[1]) / 2);
        if(bassAverage > average)
        {
            move.onBeat = true;
        }
        else
        {
            move.onBeat = false;
        }

        pointBlue.intensity = Mathf.Clamp(bassAverage / 10, 1, 2.5f);
        pointRed.intensity =  Mathf.Clamp(((freqBands[2] + freqBands[3] + freqBands[4]) / 3) / 10, 1, 2.5f);
        pointGreen.intensity = Mathf.Clamp(((freqBands[5] + freqBands[6] + freqBands[7]) / 3) / 10, 1, 2.5f);
    }

    void CreateBands()
    {
        int count = 0;
        float average = 0;

        for(int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            freqBands[i] = average * 1000;
        }

    }
}
