using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler
{
	[SerializeField] Renderer render;
	[SerializeField] Color nomalColor;
	[SerializeField] Color highlightColor;

	public void OnPointerClick(PointerEventData eventData)
	{
		
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		render.material.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		render.material.color = nomalColor;
	}

	public void OnPointerMove(PointerEventData eventData)
	{
		
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		
	}
}
