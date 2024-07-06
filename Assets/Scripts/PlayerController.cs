using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
	[SerializeField] Transform endPoint;

	private void Start()
	{
		agent.destination = endPoint.position;
	}
}
