using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MotherIntelligence
{
    public enum States
    {
        SearchingChild,
        FoundChild,
        HeardSound,
    }

    public delegate void DelegateState();
    
    [System.Serializable]
    public class MotherState
    {
        private Dictionary<States, DelegateState> states = new Dictionary<States, DelegateState>();

        [SerializeField] public States currentStates = States.SearchingChild;

        public NavMeshAgent agent;

        [Header("Waypoints")] 
        public Waypoints[] Waypoints;
        
        public void ChangeState(States _newstate)
        {
            if (_newstate != currentStates)
                currentStates = _newstate;
        }

        public void Start(NavMeshAgent _agent)
        {
            agent = _agent;
            
            states.Add(States.SearchingChild, SearchingChild);
        }

        public void Update()
        {
            // This basically keeps the states changing! please don't touch this too much!
            if (states.TryGetValue(currentStates, out DelegateState state))
                state.Invoke();
            else
                Debug.LogError($"No state function set for state {currentStates}.");
        }

        private void SearchingChild()
        {
            
        }
    }
}