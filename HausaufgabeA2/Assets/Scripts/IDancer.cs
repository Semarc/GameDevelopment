using UnityEngine;

public interface IDancer
{
	Transform transform { get; }
	bool IsDancing { get; set; }
}