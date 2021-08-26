using System.Collections;
using UnityEngine;

public class MotherVision : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Transform pointer;
    [SerializeField, Range(0, 360)] public float angle;
    public float radius;
    public bool canSeePlayer;

    private void Start()
    {
        StartCoroutine(FOVRoutine());
    }

    // coroutine which frequently checks the field of view
    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            CanSeeTarget(player, angle, radius);
        }
    }

    // checks FOV to see if the player is visible
    private void CanSeeTarget(Transform target, float viewAngle, float viewRange)
    {
        // the direction to the target
        Vector3 toTarget = target.position - transform.position;

        // if player is within the viewAngle
        if (Vector3.Angle(transform.forward, toTarget) <= viewAngle)
        {
            // raycast shot out from pointer in direction of target
            if (Physics.Raycast(pointer.position, toTarget, out RaycastHit hit, viewRange))
            {
                // if the ray hits the player
                if (hit.transform.root == target)
                {
                    // mother can see player
                    canSeePlayer = true;
                }
                else
                {
                    // else mother can't see player
                    canSeePlayer = false;
                }
            }
        }
    }
}
