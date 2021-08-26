using System.Collections;
using UnityEngine;

public class MotherVision : MonoBehaviour
{
    //[SerializeField] private LayerMask targetMask;
    //[SerializeField] private LayerMask obstructionMask;
    public Transform player;
    public Transform pointer;
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
        Vector3 toTarget = target.position - transform.position;
        if (Vector3.Angle(transform.forward, toTarget) <= viewAngle)
        {
            if (Physics.Raycast(pointer.position, toTarget, out RaycastHit hit, viewRange))
            {
                if (hit.transform.root == target)
                {
                    canSeePlayer = true;
                }
                else
                {
                    canSeePlayer = false;
                }
            }
        }
    }



    //private void FOV()
    //{
    //    Vector3 targetDir = player.position - transform.position;
    //    float angleToPlayer = (Vector3.Angle(targetDir, transform.forward));

    //    if (angleToPlayer >= -90 && angleToPlayer <= 90) // 180° FOV
    //    {
    //        canSeePlayer = true;
    //    }
    //    else
    //    {
    //        canSeePlayer = false;
    //    }
    //}
    //private void FieldOfViewCheck()
    //{
    //    // array of colliders is generated to populate the OverlapSphere
    //    Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

    //    // if the length of the array of colliders isn't 0
    //    if (rangeChecks.Length != 0)
    //    {
    //        // target is set to the first collider in the array
    //        Transform target = rangeChecks[0].transform;

    //        // direction to the target is calculated (normalized since you don't need the distance right now)
    //        Vector3 directionToTarget = (target.position - transform.position).normalized;

    //        // returns an angle between the forward direction of the mother and the direction to the target
    //        if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
    //        {
    //            // gets the distance to from the mother to the target
    //            float distanceToTarget = Vector3.Distance(transform.position, target.position);

    //            // raycasts to the target
    //            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
    //            {
    //                // player can be seen
    //                canSeePlayer = true;
    //            }
    //            else
    //            {
    //                // player can't be seen
    //                canSeePlayer = false;
    //            }
    //        }
    //        else
    //        {
    //            canSeePlayer = false;
    //        }
    //    }
    //    // if mother can currently see player
    //    else if (canSeePlayer)
    //    {
    //        canSeePlayer = false;
    //    }
    //}

}
