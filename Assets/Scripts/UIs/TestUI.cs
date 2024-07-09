using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : BaseUI
{
	protected override void Awake()
	{
		base.Awake();
		// �����
		// UI �߿��� �̸��� : "Name" �� ���ӿ�����Ʈ���� ������Ʈ Button�� ���� ���� �ʹ�.
		// GetUI<Button>("Name");

		GetUI<TMP_Text>("Title").text = "Title2";
		GetUI<Button>("NextButton").interactable = false;
	}
}
