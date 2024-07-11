using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildUI : InGameUI
{
	private TowerPlace towerPlace;

	protected override void Awake()
	{
		base.Awake();

		GetUI<Button>("ArchorButton").onClick.AddListener(BuildArchorTower);
		GetUI<Button>("CannonButton").onClick.AddListener(BuildCannonTower);
		GetUI<Button>("MageButton").onClick.AddListener(BuildMageTower);
		GetUI<Button>("BarrackButton").onClick.AddListener(BuildBarrackTower);
	}

	public void SetTowerPlace(TowerPlace towerPlace)
	{
		this.towerPlace = towerPlace;
	}

	public void BuildArchorTower()
	{
		towerPlace.BuildTower("Archor");
		CloseUI();
	}

	public void BuildCannonTower()
	{
		towerPlace.BuildTower("Cannon");
		CloseUI();
	}

	public void BuildMageTower()
	{
		towerPlace.BuildTower("Mage");
		CloseUI();
	}

	public void BuildBarrackTower()
	{
		towerPlace.BuildTower("Barrack");
		CloseUI();
	}
}
