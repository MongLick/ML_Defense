using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	[SerializeField] Transform startPoint;
	[SerializeField] Transform endPoint;
    [SerializeField] Monster monsterPrefab;
	[SerializeField] float repeatTime;

	Coroutine spawnerRoutine;

	private void OnEnable()
	{
		spawnerRoutine = StartCoroutine(SpawnerRoutine());
	}

	private void OnDisable()
	{
		StopCoroutine(spawnerRoutine);
	}

	IEnumerator SpawnerRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(repeatTime);
			Monster monster = Instantiate(monsterPrefab, startPoint.position, startPoint.rotation);
			monster.SetDestination(endPoint.position);
		}
	}
}
