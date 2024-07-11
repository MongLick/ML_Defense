using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Renderer render;
	[SerializeField] Color nomalColor;
	[SerializeField] Color highlightColor;

	[SerializeField] BuildUI buildUI;

	[Header("Tower")]
	[SerializeField] TowerData archorTower;
	[SerializeField] TowerData cannonTower;

	private void Awake()
	{
		archorTower = Resources.Load<TowerData>("Data/Tower/ArchorTower");
		cannonTower = Resources.Load<TowerData>("Data/Tower/CannonTower");
	}


	public void OnPointerClick(PointerEventData eventData)
	{
		BuildUI ui = Manager.UI.ShowInGameUI(buildUI);
		ui.SetTarget(transform);
		ui.SetTowerPlace(this);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		render.material.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		render.material.color = nomalColor;
	}

	public void BuildTower(string name)
	{
		if(name == "Archor")
		{
			gameObject.SetActive(false);
			Tower tower = Instantiate(archorTower.prefab, transform.position, transform.rotation);
			tower.SetTowerPlace(this);
		}
		else if(name == "Cannon")
		{
			gameObject.SetActive(false);
			Tower tower = Instantiate(cannonTower.prefab, transform.position, transform.rotation);
			tower.SetTowerPlace(this);
		}
	}
}
