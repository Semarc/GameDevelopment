using System.Collections.Generic;

using UnityEngine;
public static class HelperFunctions
{
	public static T[] GetComponentsFromObjects<T>(string ObjectTag) where T : Component
	{
		GameObject[] Objects = GameObject.FindGameObjectsWithTag(ObjectTag);
		List<T> tempAnimalAiList = new();
		foreach (GameObject item in Objects)
		{
			tempAnimalAiList.Add(item.GetComponent<T>());
		}
		return tempAnimalAiList.ToArray();
	}
}