using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] EventSystem eventSystemPrefab;

	private void Awake()
	{
		EnsureEventSystem();
	}

	public void EnsureEventSystem()
    {
        EventSystem eventSystem = FindAnyObjectByType<EventSystem>();
        if(eventSystem == null)
        {
            Instantiate(eventSystemPrefab);
        }
    }
}
