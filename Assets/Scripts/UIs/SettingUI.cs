using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : PopUpUI
{
	[SerializeField] ShotCutUI shotCutUIPrefab;

	protected override void Awake()
	{
		base.Awake();

		GetUI<Button>("ShotCutButton").onClick.AddListener(ShotCut);
		GetUI<Button>("CloseButton").onClick.AddListener(Close);
	}

	public void ShotCut()
	{
		Manager.UI.ShowPopUpUI(shotCutUIPrefab);
	}
}
