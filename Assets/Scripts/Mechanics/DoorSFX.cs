using UnityEngine;

public class DoorSFX : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private bool played;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (played == false)
            {
                audioScript.sfx.PlayOneShot(audioScript.doorSound);
                played = true;
            } 
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        played = false;
    }
}
