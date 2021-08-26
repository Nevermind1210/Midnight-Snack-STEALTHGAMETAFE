using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        // if player collides with this trigger
        if (other.CompareTag("Player"))
        {
            // if player has gotten food from fridge
            if (controller.hasFood)
            {
                // the win scene is loaded
                SceneManager.LoadScene("Win"); 
            }
            else
            {
                print("You don't have food yet!");
            }
        }
    }
}
