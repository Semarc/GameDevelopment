using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class MaterialImageClick : MonoBehaviour, IPointerClickHandler
{
	public Material material;


	public void OnPointerClick(PointerEventData eventData)
	{
		BallController.BallTexture = material;
	}
}