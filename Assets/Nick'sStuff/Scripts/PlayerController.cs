using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent player;       // the player agent
    [SerializeField] private Transform pointer;         // interaction raycast is shot from this
    [SerializeField] private float reach;               // how far player can reach to interact

    private void Update()
    {
        Movement();
        Interact();
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
                    // player doesn't move if they can't reach the destination
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
        // if 'E' button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // used to store information on what raycast hits
            RaycastHit hit;

            // if the raycast is shot 5 units from the player position
            if (Physics.Raycast(pointer.position, pointer.transform.forward, out hit, reach))
            {
                // if the raycast hits a collider tagged 'Fridge'
                if (hit.collider.name == "Fridge")
                {
                    // get food from the fridge
                    print("you are interacting with the fridge!");
                }
                else if (hit.collider.name == "Door")
                {
                    // open the door
                    print("you are interacting with the door!");
                }
            }
        }
    }
}