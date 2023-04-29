using UnityEngine;

using System;
using System.Collections;

public static class DanceMoves
{
	public static Func<Transform, IEnumerator>[] AIDanceMoves = new Func<Transform, IEnumerator>[]
	{
		RotateDancer,
        RotateDancerBackwards,
        Schiffschaukel,
        Jiggle
	};
	public static Func<Transform, IEnumerator>[] PlayerDanceMoves  = new Func<Transform, IEnumerator>[]
	{
		RotateDancer,
        RotateDancerBackwards,
        Schiffschaukel,
        Jiggle
	};

	//scale for growing
	private static IEnumerator RotateDancer(Transform Dancer)
    {
        float TotalRotation = 0;
        while (TotalRotation < 360)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        Dancer.rotation = Quaternion.identity;
    }

    private static IEnumerator RotateDancerBackwards(Transform Dancer)
    {
        float TotalRotation = -1;
        while (TotalRotation > -360)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z - Addition);

            TotalRotation -= Addition;

            yield return null;
        }
        Dancer.rotation = Quaternion.identity;
    }

    private static IEnumerator Schiffschaukel(Transform Dancer)
    {
        float TotalRotation = 0;
        while (TotalRotation < 90)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        while (TotalRotation > -90)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z - Addition);

            TotalRotation -= Addition;

            yield return null;
        }
        while (TotalRotation < 0)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        Dancer.rotation = Quaternion.identity;
    }

    private static IEnumerator Jiggle(Transform Dancer)
    {
        float TotalRotation = 0;
        while (TotalRotation < 30)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        while (TotalRotation > -30)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z - Addition);

            TotalRotation -= Addition;

            yield return null;
        }
        while (TotalRotation < 30)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        while (TotalRotation > -30)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z - Addition);

            TotalRotation -= Addition;

            yield return null;
        }
        while (TotalRotation < 0)
        {
            float Addition = Time.deltaTime * 180;

            Dancer.rotation = Quaternion.Euler(0, 0, Dancer.rotation.eulerAngles.z + Addition);

            TotalRotation += Addition;

            yield return null;
        }
        Dancer.rotation = Quaternion.identity;
    }
}
