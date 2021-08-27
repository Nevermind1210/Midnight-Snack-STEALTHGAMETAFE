using UnityEngine;
using UnityEngine.AI;

public class MotherStates : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MotherVision vision;
    [SerializeField] private Audio audioScript;
    [Header("Wander")]
    [SerializeField] float wanderRadius;
    [SerializeField] float wanderTimer;
    private Transform target;
    private NavMeshAgent mother;
    private float timer;
    private Animator _anim;
    [Header("Chase")]
    [SerializeField] private Transform player;
    private float moveSpeed = 3f;
    public bool isWandering;
    [Header("Investigate")]
    [SerializeField] private bool checkedSound;
    [Header("Animation")]
    [SerializeField] private Animator motherAnimation;

    void Start()
    {
        mother = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        target = transform;
        timer = wanderTimer;
    }

    void Update()
    {
        if (vision.canSeePlayer)
        {
            Chase();
        }
        else if (!vision.canSeePlayer)
        {
            Wander();
            Investigate();
        }

        MotherAnimation();
    }

    // mother wanders around
    private void Wander()
    {
        isWandering = true;

        // timer increases gradually
        timer += Time.deltaTime;

        // if timer is greater or equal to wanderTimer
        if (timer >= wanderTimer)
        {
            // if agent's path is finished and the remaining distance to the destination is less than 0.1
            if (!mother.pathPending && mother.remainingDistance < 0.1f)
            {
                Vector3 newPos = RandomNavSphere(target.position, wanderRadius, -1);    // new position is generated
                mother.SetDestination(newPos);   // agent moves to next destination            
                timer = 0;  // timer is reset
            }
            _anim.SetTrigger("Walking");
        }
        else if (target == null)
        {
            _anim.SetTrigger("Idle");
        }
    }
    
    // random position that the mother travels to
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist; // gets random position inside the unit sphere

        randDirection += origin; // that position is added to the origin of the unit sphere

        NavMeshHit navHit;  // stores information on what hits navmesh

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask); // converts the random position into a position on the navmesh

        return navHit.position; // returns the random position as a position on the navmesh
    }

    // mother chases player
    public void Chase()
    {
        isWandering = false;

        // mother's speed changes
        mother.speed = moveSpeed;

        // mother looks at player
        transform.LookAt(player);

        // mother travels towards player
        mother.SetDestination(player.position);
    }

    private void Investigate()
    {
        // if any sound effects are playing
        if (audioScript.sfx.isPlaying && !checkedSound)
        {
            mother.SetDestination(player.position);
            checkedSound = true;
        }
    }

    private void MotherAnimation()
    {
        if (mother.remainingDistance > mother.stoppingDistance)
        {
            motherAnimation.Play("Walking");
        }
        else
        {
            motherAnimation.Play("Idle");
        }
    }
}
