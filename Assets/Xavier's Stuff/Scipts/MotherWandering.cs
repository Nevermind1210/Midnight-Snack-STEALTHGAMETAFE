using UnityEngine;
using UnityEngine.AI;

public class MotherWandering : MonoBehaviour
{
    [SerializeField] float wanderRadius;
    [SerializeField] float wanderTimer;
    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private Animator _anim;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        target = transform;
        timer = wanderTimer;
    }

    void Update()
    {
        Wander();
    }

    private void Wander()
    {
        // timer increases gradually
        timer += Time.deltaTime;

        // if timer is greater or equal to wanderTimer
        if (timer >= wanderTimer)
        {
            // if agent's path is finished and the remaining distance to the destination is less than 0.1
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                Vector3 newPos = RandomNavSphere(target.position, wanderRadius, -1);    // new position is generated
                agent.SetDestination(newPos);   // agent moves to next destination            
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
}
