using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] protected TowerData data;
	[SerializeField] MeshFilter meshFilter;
	
	private TowerPlace towerPlace;
	protected int level = 1;
	private bool isUpgrading;

	Coroutine upgradeRoutine;
	Coroutine checkRangeRoutine;

	public List<Monster> monsterList = new List<Monster>();

	public LayerMask monsterMask;
	private Collider[] colliders = new Collider[10];


	private void Start()
	{
		// Upgrade();
	}

	protected virtual void OnEnable()
	{
		checkRangeRoutine = StartCoroutine(CheckRangeRoutine());
	}

	protected virtual void OnDisable()
	{
		StopCoroutine(checkRangeRoutine);
	}

	public void SetTowerPlace(TowerPlace towerPlace)
	{
		this.towerPlace = towerPlace;
	}

	public void Upgrade()
	{
		/*if (level == data.towers.Length)
		{
			return;
		}

		if (isUpgrading)
		{
			return;
		}

		StartCoroutine(UpgradeRoutine(level));*/
	}

	public void Sell()
	{
		/*Destroy(gameObject);
		towerPlace.gameObject.SetActive(true);*/
	}

	IEnumerator UpgradeRoutine(int level)
	{
		meshFilter.mesh = data.towers[level].cons;
		isUpgrading = true;
		yield return new WaitForSeconds(data.towers[level].buildTime);
		meshFilter.mesh = data.towers[level].build;
		isUpgrading = false;
		this.level++;
	}

	IEnumerator CheckRangeRoutine()
	{
		while (true)
		{
			monsterList.Clear();
			int size = Physics.OverlapSphereNonAlloc(transform.position, data.towers[level -1].range, colliders, monsterMask);
			// Collider[] colliders = Physics.OverlapSphere(transform.position, data.towers[level - 1].range, monsterMask);
			for (int i = 0; i < size; i++)
			{
				Monster monster = colliders[i].GetComponent<Monster>();
				monsterList.Add(monster);
			}

			yield return new WaitForSeconds(data.towers[level - 1].coolTime);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		/*if (eventData.button == PointerEventData.InputButton.Left)
		{
			Upgrade();
		}
		else
		{
			Sell();
		}*/
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, data.towers[level - 1].range);
	}
}
