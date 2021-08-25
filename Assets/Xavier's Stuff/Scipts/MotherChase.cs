using UnityEngine;
using UnityEngine.AI;

namespace MotherIntelligence.Editor
{
    public class MotherChase : MonoBehaviour
    {
        private MotherVision fieldOfVision;
        [SerializeField] private Transform Hero;
        private Transform itself;
        private float moveSpeed = 3f;
        private NavMeshAgent agent;

        public void Start()
        {
            itself = transform;
            agent = GetComponent<NavMeshAgent>();
            fieldOfVision = GetComponent<MotherVision>();
        }

        public void Update()
        {
            agent.speed = moveSpeed;
            itself.LookAt(Hero);

            if (!agent.pathPending && agent.remainingDistance <= fieldOfVision.radius && fieldOfVision.canSeePlayer)
            {
                if (!agent.hasPath && agent.remainingDistance >= fieldOfVision.radius)
                {
                  
                }
                else
                {
                    GetComponent<MotherWandering>().enabled = true;
                }
            }
        }
    }
}