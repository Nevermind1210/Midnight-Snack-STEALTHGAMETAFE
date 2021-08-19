using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSFX : MonoBehaviour
{
    public Audio audioManager;

    private void OnCollisionEnter(Collision collision)
    {
        // an AudioClip is played once
        audioManager.sfx.PlayOneShot(audioManager.doorCreak);
        print("a sound effect was played!");
    }
}
