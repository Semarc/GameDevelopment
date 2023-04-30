using UnityEngine;

using System;
using System.Collections;

public static class DanceMoves
{
	public static Func<IDancer, IEnumerator>[] AIDanceMoves = new Func<IDancer, IEnumerator>[]
	{
		RotateDancer,
        RotateDancerBackwards,
        Schiffschaukel,
        Jiggle,
        Scalechange
	};
	public static Func<IDancer, IEnumerator>[] PlayerDanceMoves  = new Func<IDancer, IEnumerator>[]
	{
		RotateDancer,
        RotateDancerBackwards,
        Schiffschaukel,
        Jiggle,
        Scalechange
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

    private static IEnumerator Scalechange(IDancer Dancer)
    {
        float TotalScale = 0;
        while (TotalScale < 0.5)
        {
            float Addition = Time.deltaTime * 2;

			Dancer.transform.localScale = new Vector3 (Dancer.transform.localScale.x + Addition, Dancer.transform.localScale.y + Addition, 1);

            TotalScale += Addition;

            yield return null;
        }
		Dancer.transform.localScale = Vector3.one;
		Dancer.IsDancing = false;
	}
}
