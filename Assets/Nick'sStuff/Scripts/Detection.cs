using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// this script deals with player detection
public class Detection : MonoBehaviour
{
    public Audio audioScript;
    [Header("Detection")]
    [SerializeField] private Slider detectionBar;
    [SerializeField] private float detection;
    [SerializeField] private float minDetection;
    [SerializeField] private float maxDetection;

    private void Start()
    {
        // detection bar setup
        detectionBar.minValue = minDetection;
        detectionBar.maxValue = maxDetection;
        detectionBar.value = detection;
    }

    private void Update()
    {

    }

    private void Detect()
    {
        // check if any audio is playing
        if (audioScript.master.isPlaying)
        {
            // if audioScript.master.clip equals sound effect
            // detection = detection += time.DeltaTime
        }
        else
        {
            print("no audio is playing currently!");
        }
    }

}
