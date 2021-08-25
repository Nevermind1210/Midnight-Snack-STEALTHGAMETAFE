using System;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

namespace MotherIntelligence
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class SmartMother : MonoBehaviour
    {
        //public AudioMixer masterMixer;
        //public AudioSource winMusic;

        public MotherState stateBehaviours;

        public NavMeshAgent agent;
        [SerializeField] private GameObject placeholder;

        private void Start()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();

            stateBehaviours.Start(agent);
        }

        private void Update()
        {
            stateBehaviours.Update();
            
            MainPath();
            SwitchStates();
        }

        public void MainPath()
        {
            if (stateBehaviours.currentStates == States.SearchingChild)
            {
                {
                    stateBehaviours.ChangeState(States.SearchingChild);
                }
                // If path is blocked
                if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathPartial &&
                    agent.remainingDistance <= 10)
                {
                    stateBehaviours.ChangeState(States.HeardSound);
                }
                // if path is unreachable....
                if (agent.hasPath && agent.path.status == NavMeshPathStatus.PathInvalid &&
                    agent.remainingDistance <= 10)
                {
                    stateBehaviours.ChangeState(States.SearchingChild);
                }
            }
        }

        public void SwitchStates()
        {
            if (stateBehaviours.currentStates == States.SearchingChild)
            {
                if (!agent.pathPending && agent.remainingDistance < 0.1f)
                {
                    stateBehaviours.ChangeState(States.SearchingChild);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (agent != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(agent.destination, 1f);

                Gizmos.DrawLine(transform.position, agent.destination);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(agent.steeringTarget, 1f);
            }
        }
    }
}
