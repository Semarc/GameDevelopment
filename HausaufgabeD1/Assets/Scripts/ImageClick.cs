using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClick : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] int levelNumer;
	public void OnPointerClick(PointerEventData eventData)
	{
		SceneManagerScript.Instance.LoadLevel(levelNumer);
	}
}