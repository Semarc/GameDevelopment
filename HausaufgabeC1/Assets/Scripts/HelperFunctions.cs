using UnityEngine;

public static class HelperFunctions
{
	public static void InstantiateChildObject(GameObject parent, GameObject prefab)
	{
		Transform temp =  GameObject.Instantiate(prefab).transform;

		temp.SetPositionAndRotation(parent.transform.position, prefab.transform.rotation);
	}
}