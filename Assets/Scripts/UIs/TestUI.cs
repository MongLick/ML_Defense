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
		// 사용방법
		// UI 중에서 이름이 : "Name" 인 게임오브젝트에서 컴포넌트 Button를 갖다 쓰고 싶다.
		// GetUI<Button>("Name");

		GetUI<TMP_Text>("Title").text = "Title2";
		GetUI<Button>("NextButton").interactable = false;
	}
}
