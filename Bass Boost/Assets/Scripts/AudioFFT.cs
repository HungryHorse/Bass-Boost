using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFFT : MonoBehaviour {

    public PlayerMovement move;
    AudioSource audioSource;
    private float[] samples = new float[512];
    public float[] freqBands = new float[8]; 

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
        CreateBands();
        if(freqBands[0] > 1f || freqBands[1] > 1f)
        {
            move.onBeat = true;
        }
        else
        {
            move.onBeat = false;
        }
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

            freqBands[i] = average * 100;
        }

    }
}
