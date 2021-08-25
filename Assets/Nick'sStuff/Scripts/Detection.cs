using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    [Header("References")]
    public Audio audioManager;
    [Header("Detection")]
    [SerializeField] private Image detectionBar;
    [SerializeField] private Image backgroundBar;
    [SerializeField] private float detection;         
    [SerializeField] private float minDetection;
    [SerializeField] private float maxDetection;

    private void Start()
    {
        // detection bar setup
        detectionBar.fillAmount = minDetection;
        backgroundBar.fillAmount = maxDetection;
    }

    private void Update()
    {
        Detect(); 
    }

    private void Detect()
    {
        // if any sound effects are playing
        if (audioManager.sfx.isPlaying)
        {
            if (detection >= maxDetection)
            {
                // detection stops at maximum detection and mother knows exactly where you are now
                detectionBar.color = Color.red;
            }
            else
            {
                // increase detection over time
                detection += Time.deltaTime * 5;

                // update detection bar
                detectionBar.fillAmount = detection / 100; 
            }
        }
    }

}
