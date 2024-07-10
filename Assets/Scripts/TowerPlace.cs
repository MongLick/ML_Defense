using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Renderer render;
	[SerializeField] Color nomalColor;
	[SerializeField] Color highlightColor;

	[SerializeField] InGameUI buildUI;

	public void OnPointerClick(PointerEventData eventData)
	{
		InGameUI ui = Manager.UI.ShowInGameUI(buildUI);
		ui.SetTarget(transform);
		ui.SetOffset(new Vector3(0, 150, 0));
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		render.material.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		render.material.color = nomalColor;
	}
}
