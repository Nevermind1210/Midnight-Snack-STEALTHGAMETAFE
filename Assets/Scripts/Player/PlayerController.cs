using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Audio audioScript;
    [Header("Movement")]
    [SerializeField] private NavMeshAgent player;       // the player agent
    [SerializeField] private Transform pointer;         // interaction raycast is shot from this
    [Header("Interaction")]
    [SerializeField] private TextMeshProUGUI tipsText;  // hints on what the player should do next
    [SerializeField] private float reach;               // how far player can reach to interact
    public bool hasFood;                                // whether player has already gotten food from fridge
    [Header("Animation")]
    [SerializeField] private Animator playerAnimation;  // the player's animation controller 
    [SerializeField] private Animator fridgeAnimation;  // the fridge's animation controller

    private void Update()
    {
        Movement();
        Interact();
        PlayerAnimation();
    }

    private void Movement()
    {
        // if the left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            // ray is shot from mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // used to store information on what raycast hit
            RaycastHit hit;

            // raycast is shot our from click position
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                // creates a path that can be calculated
                NavMeshPath path = new NavMeshPath();
                // calculates the path of the most recent click
                player.CalculatePath(hit.point, path);
                // if path is blocked
                if (path.status == NavMeshPathStatus.PathPartial)
                {

                }
                // else if the path is clear
                else
                {
                    // player moves towards the hit position
                    player.SetDestination(hit.point);              
                }             
            }
        }      
    }

    private void Interact()
    {
        // if space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // used to store information on what raycast hits
            RaycastHit hit;

            // if the raycast is shot 5 units from the player position
            if (Physics.Raycast(pointer.position, pointer.transform.forward, out hit, reach))
            {
                if (!hasFood)
                {
                    // if the raycast hits a collider tagged 'Fridge'
                    if (hit.collider.CompareTag("Fridge"))
                    {
                        // get food from the fridge
                        playerAnimation.Play("Grab");
                        fridgeAnimation.Play("Open");
                        FridgeSound();
                        hasFood = true;
                        tipsText.text = "Get back to your room!";
                    } 
                }
                else
                {
                    print("You already have food you greedy little kid!");
                }
            }
        }
    }

    private void PlayerAnimation()
    {
        if (player.remainingDistance > player.stoppingDistance)
        {
            playerAnimation.Play("Walking");
        }
        else
        {
            playerAnimation.Play("Idle");
        }
    }

    private void FridgeSound()
    {
        audioScript.sfx.PlayOneShot(audioScript.fridgeSound);
    }
}