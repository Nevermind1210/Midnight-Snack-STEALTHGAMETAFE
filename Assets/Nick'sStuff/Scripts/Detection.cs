using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    [Header("References")]
    public Audio audioManager;
    [Header("General")]
    public bool started;
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
        // if game has started
        if (started)
        {
            Detect(); 
        }
    }

    private void Detect()
    {
        // if any sound effects are playing
        if (audioManager.sfx.isPlaying)
        {
            // increase detection over time
            detection += Time.deltaTime;

            // update detection bar
            detectionBar.value = detection;
        }
    }

}
