using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
    [Header("References")]
    public Audio audioManager;

    // door sfx
    private void OnTriggerEnter(Collider other)
    {
        // if the collider is tagged "Player"
        if (other.GetComponent<CharacterController>().CompareTag("Player"))
        {
            // an AudioClip is played once
            audioManager.sfx.PlayOneShot(audioManager.doorCreak);
            print("a sound effect was played!");
        }
    }
}
