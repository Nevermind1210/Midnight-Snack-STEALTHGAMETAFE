using System.Collections;
using System.Collections.Generic;
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
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        target = transform;
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.1f)
            {
                Vector3 newPos = RandomNavSphere(target.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }

            //_anim.SetTrigger("");
        }
        else if (target == null)
        {
            //anim.SetTrigger("");
        }
    }
    
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
