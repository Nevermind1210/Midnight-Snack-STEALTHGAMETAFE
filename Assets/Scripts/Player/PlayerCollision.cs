using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private Sanity sanity;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Mother"))
        {
            sanity.LoseSanity(5f);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Mother"))
        {
            sanity.LoseSanity(1f);
        }
    }
}
