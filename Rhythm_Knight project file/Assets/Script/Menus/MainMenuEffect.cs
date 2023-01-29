using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEffect : MonoBehaviour
{
    //background
    public Image img;

    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject sprite;
    public float sizeFactor = 1;

    public float minSize = 1;
    public float maxSize = 10;


    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if(currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoudness = 0f;
            foreach(var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;
            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
            sprite.transform.localScale = new Vector3(clipLoudness, clipLoudness, clipLoudness);
        }

        if(clipLoudness >= 2)
        {
            img.color = new Color32(255, 255, 225, 100);
        }

        if (clipLoudness <= 0.5)
        {
            img.color = new Color32(96, 96, 96, 100);
        }
    }

    
}
