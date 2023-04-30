using System;
using System.Collections;

using UnityEngine;

public static class DanceMoves
{
	public static Func<IDancer, IEnumerator>[] AIDanceMoves = new Func<IDancer, IEnumerator>[]
	{
		RotateDancer,
		RotateDancerBackwards,
		Schiffschaukel,
		Jiggle,
		FirstScalechange,
		turnDancer
	};
	public static Func<IDancer, IEnumerator>[] PlayerDanceMoves  = new Func<IDancer, IEnumerator>[]
	{
		RotateDancer,
		RotateDancerBackwards,
		Schiffschaukel,
		Jiggle,
		FirstScalechange,
		turnDancer
	};


	private static IEnumerator RotateDancer(IDancer Dancer)
	{
		float TotalRotation = 0;
		while (TotalRotation < 360)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		Dancer.transform.rotation = Quaternion.identity;
		Dancer.IsDancing = false;
	}

	private static IEnumerator RotateDancerBackwards(IDancer Dancer)
	{
		float TotalRotation = -1;
		while (TotalRotation > -360)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z - Addition);

			TotalRotation -= Addition;

			yield return null;
		}
		Dancer.transform.rotation = Quaternion.identity;
		Dancer.IsDancing = false;
	}

	private static IEnumerator Schiffschaukel(IDancer Dancer)
	{
		float TotalRotation = 0;
		while (TotalRotation < 90)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		while (TotalRotation > -90)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z - Addition);

			TotalRotation -= Addition;

			yield return null;
		}
		while (TotalRotation < 0)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		Dancer.transform.rotation = Quaternion.identity;
		Dancer.IsDancing = false;
	}

	private static IEnumerator Jiggle(IDancer Dancer)
	{
		float TotalRotation = 0;
		while (TotalRotation < 30)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		while (TotalRotation > -30)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z - Addition);

			TotalRotation -= Addition;

			yield return null;
		}
		while (TotalRotation < 30)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		while (TotalRotation > -30)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z - Addition);

			TotalRotation -= Addition;

			yield return null;
		}
		while (TotalRotation < 0)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}
		Dancer.transform.rotation = Quaternion.identity;
		Dancer.IsDancing = false;
	}

	private static IEnumerator FirstScalechange(IDancer Dancer)
	{
		float TotalScale = 0;
		while (TotalScale < 1)
		{
			float Addition = Time.deltaTime * 1;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x + Addition, Dancer.transform.localScale.y + Addition, 1);

			TotalScale += Addition;

			yield return null;
		}
		while (TotalScale > -1)
		{
			float Addition = Time.deltaTime * 2;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x - Addition, Dancer.transform.localScale.y - Addition, 1);

			TotalScale -= Addition;

			yield return null;
		}
		while (TotalScale < 1)
		{
			float Addition = Time.deltaTime * 1;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x + Addition, Dancer.transform.localScale.y + Addition, 1);

			TotalScale += Addition;

			yield return null;
		}
		while (TotalScale > 0)
		{
			float Addition = Time.deltaTime * 2;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x - Addition, Dancer.transform.localScale.y - Addition, 1);

			TotalScale -= Addition;

			yield return null;
		}
		Dancer.transform.localScale = Vector3.one;
		Dancer.IsDancing = false;
	}

	private static IEnumerator turnDancer(IDancer Dancer)
	{
		float TotalScale = 0;
		while (TotalScale < 1)
		{
			float Addition = Time.deltaTime * 1;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x + Addition, Dancer.transform.localScale.y + Addition, 1);

			TotalScale += Addition;

			yield return null;
		}
		float TotalRotation = 0;
		while (TotalRotation < 360)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z + Addition);

			TotalRotation += Addition;

			yield return null;
		}

		while (TotalScale > 0)
		{
			float Subtraktion = Time.deltaTime * 1;

			Dancer.transform.localScale = new Vector3(Dancer.transform.localScale.x - Subtraktion, Dancer.transform.localScale.y - Subtraktion, 1);

			TotalScale -= Subtraktion;

			yield return null;
		}
		//float TotalRotation = -1;
		while (TotalRotation > -360)
		{
			float Addition = Time.deltaTime * 180;

			Dancer.transform.rotation = Quaternion.Euler(0, 0, Dancer.transform.rotation.eulerAngles.z - Addition);

			TotalRotation -= Addition;

			yield return null;
		}

		Dancer.transform.rotation = Quaternion.identity;
		Dancer.IsDancing = false;
	}
}
