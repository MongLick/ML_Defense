using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

	private void Update()
	{
		CheckEndPoint();
	}

	public void SetDestination(Vector3 destination)
    {   
        agent.destination = destination;
    }

    private void CheckEndPoint()
    {
        if((transform.position - agent.destination).sqrMagnitude < 0.01f)
        {
            Destroy(gameObject);
        }
    }
}
