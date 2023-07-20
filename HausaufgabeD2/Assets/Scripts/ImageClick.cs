using UnityEngine;
using UnityEngine.EventSystems;

public class ImageClick : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] int levelNumber;
	public void OnPointerClick(PointerEventData eventData)
	{
		AudioScript.Instance.PlaySelectSound();
		SceneManagerScript.Instance.LoadLevel(levelNumber);
	}
}