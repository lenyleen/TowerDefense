using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UFOScript : MonoBehaviour
{
    private Transform finishPos;
    private NavMeshAgent agent;
    private void OnEnable()
    {
        finishPos = GameObject.FindGameObjectWithTag("Fin").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(finishPos.position);
    }
}
