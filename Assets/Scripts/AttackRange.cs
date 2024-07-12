using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
	public List<Monster> monsterList = new List<Monster>();
	public LayerMask monsterMask;

	private void OnTriggerEnter(Collider other)
	{
		if(((1 << other.gameObject.layer) & monsterMask) != 0)
		{
			Monster monster = other.GetComponent<Monster>();
			monster.OnDied += () => monsterList.Remove(monster);
			monsterList.Add(monster);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(monsterMask.Contain(other.gameObject.layer))
		{
			Monster monster = other.GetComponent<Monster>();
			monsterList.Remove(monster);
		}
	}
}

public static class Extension
{
	public static bool Contain(this LayerMask layerMask, int layer)
	{
		return ((1 << layer) & layerMask) != 0;
	}
}