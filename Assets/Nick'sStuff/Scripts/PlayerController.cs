using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform pointer;
    [SerializeField] private float speed;

    private void Update()
    {
        Movement();
        Rotation();
        Interact();
    }

    private void Movement()
    {
        // gets the horizontal and vertical axes (for WASD movement)
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // puts these axes into a Vector3
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // depending on which key is pressed the player moves in that direction
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void Rotation()
    {
        // used to store information on what raycast hits
        RaycastHit hit;
        // raycast is shot from mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // if the raycast hits something (which it always should)
        if (Physics.Raycast(ray, out hit))
        {
            // the player rotates towards that position
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void Interact()
    {
        // if 'E' button is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // used to store information on what raycast hits
            RaycastHit hit;

            // if the raycast is shot 5 units from the pointer position
            if (Physics.Raycast(pointer.position, Vector3.forward, out hit, 5))
            {
                // if the raycast hits a collider tagged 'Fridge'
                if (hit.collider.CompareTag("Fridge"))
                {
                    // obtain food
                }              
            }
        }
    }
}
