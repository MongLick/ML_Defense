using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] int hp;
    [SerializeField] Slider hpBar;

    public int HP{ get { return hp;}  private set { hp = value; OnChangedHP?.Invoke(value); } }

    public event UnityAction OnDied;
    public event UnityAction<int> OnChangedHP;

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

    public void TakeDamage(int damage)
    {
        HP -= damage;
        hpBar.value = HP;

        if(hp <= 0)
        {
            OnDied?.Invoke();
            Destroy(gameObject);
		}
    }
}
