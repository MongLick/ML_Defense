using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] TowerData data;
	[SerializeField] MeshFilter meshFilter;

	private TowerPlace towerPlace;
	private int level;
	private bool isUpgrading;

	Coroutine upgradeRoutine;

	private void Start()
	{
		Upgrade();
	}

	public void SetTowerPlace(TowerPlace towerPlace)
	{
		this.towerPlace = towerPlace;
	}

	public void Upgrade()
	{
		if(level == data.towers.Length)
		{
			return;
		}

		if(isUpgrading)
		{
			return;
		}

		StartCoroutine(UpgradeRoutine(level));
	}

	public void Sell()
	{
		Destroy(gameObject);
		towerPlace.gameObject.SetActive(true);
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

	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Left)
		{
			Upgrade();
		}
		else
		{
			Sell();
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		if(level > 0)
		{
			Gizmos.DrawWireSphere(transform.position, data.towers[level - 1].range);
		}
	}
}
