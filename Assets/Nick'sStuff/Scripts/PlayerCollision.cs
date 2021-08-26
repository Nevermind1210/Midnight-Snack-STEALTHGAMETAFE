using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Sanity sanity;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Mother"))
        {
            sanity.LoseSanity(5);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Mother"))
        {
            sanity.LoseSanity(0.1f);
        }
    }
}
