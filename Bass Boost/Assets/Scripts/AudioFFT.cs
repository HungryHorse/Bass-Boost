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
        //This makes the music play and grabs the song that was slected by the user
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClips[PlayerPrefs.GetInt("SongPicked")];
        audioSource.Play();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //This gets the spectrum data from the audio and makes it possible to use FFT
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        CreateBands();

        float average = 0;

        // gets the average of the frequency bands from 3 - 8
        for(int i = 2; i < 8; i++)
        {
            average += freqBands[i];
        }
        average /= 6;

        // this gets the average of the sub bass and bass frequency bands
        bassAverage = ((freqBands[0] + freqBands[1]) / 2);
        if(bassAverage > average)
        {
            move.onBeat = true;
        }
        else
        {
            move.onBeat = false;
        }

        // this changes the intesity of the lights based on the impact they are having
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
            // The frequencies follow the power of 2 law so frquencies all follow this simple sum
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            // at the 2 highest freqencies the sample count needs to be bigger
            if (i == 7)
            {
                sampleCount += 2;
            }

            // this gets an average of all the sample in the one frequency band
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;

            // this makes the average of the sample a reasonble number so it can visualized, otherwise the difference is minute
            freqBands[i] = average * 1000;
        }

    }
}
