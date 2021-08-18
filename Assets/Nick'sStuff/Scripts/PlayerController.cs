using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private float speed;
    [SerializeField] private float reach;
    private Rigidbody rb;
    private Vector2 mousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Interact();
    }

    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);
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
            if (hit.collider.CompareTag("Player"))
            {
                // this stops some jittering
            }
            else
            {
                // the player rotates towards that position
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }

    private void Interact()
    {
        // if 'E' button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // used to store information on what raycast hits
            RaycastHit hit;

            // if the raycast is shot 5 units from the player position
            if (Physics.Raycast(pointer.position, pointer.transform.forward, out hit, reach))
            {
                // if the raycast hits a collider tagged 'Fridge'
                if (hit.collider.CompareTag("Fridge"))
                {
                    // get food from the fridge
                    print("you are interacting with the fridge!");
                }
                else if (hit.collider.CompareTag("Door"))
                {
                    // open the door
                    print("you are interacting with the door!");
                }
            }
        }
    }
}