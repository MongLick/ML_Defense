using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
	[SerializeField] CannonBall cannonBallPrefab;
	[SerializeField] Transform cannonPoint;

	Coroutine attackRoutine;

	public void Attack(Vector3 position)
	{
		CannonBall cannonball = Instantiate(cannonBallPrefab, cannonPoint.position, cannonPoint.rotation);
		cannonball.SetTargetPos(position);
		cannonball.SetDamage(data.towers[level -1].damage);
	}

	protected override void OnEnable()
	{
		base.OnEnable();

		attackRoutine = StartCoroutine(AttackRoutine());
	}

	protected override void OnDisable()
	{
		base.OnDisable();

		StopCoroutine(attackRoutine);
	}

	IEnumerator AttackRoutine()
	{
		while (true)
		{
			if (monsterList.Count > 0)
			{
				Attack(monsterList[0].transform.position);
				yield return new WaitForSeconds(data.towers[level - 1].coolTime);
			}
			else
			{
				yield return null;
			}
		}
	}
}
