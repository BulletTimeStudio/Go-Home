using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSimple : MonoBehaviour {
	public Rigidbody PlatformRB;
	public Transform[] platformPosition;
	public float platformSpeed;

	private int actualPosition = 0;
	private int nextPosition = 1;
    public bool moveToTheNext = true;
    public float waitTime;
    
	void Update () {
		MovePlatform();
	}

	void MovePlatform()
	{
        if (moveToTheNext)
        {
            StopCoroutine(WaitForMove(0));
            PlatformRB.MovePosition(Vector3.MoveTowards(PlatformRB.position, platformPosition[nextPosition].position, platformSpeed * Time.deltaTime));
        }
		if (Vector3.Distance(PlatformRB.position, platformPosition[nextPosition].position) <= 0)
		{
            StartCoroutine(WaitForMove(waitTime));
			actualPosition = nextPosition;

			nextPosition++;

			if (nextPosition > platformPosition.Length - 1)
			{
				nextPosition = 0;
			}
		}
	}
    
    IEnumerator WaitForMove(float Time)
    {
        moveToTheNext = false;
        yield return new WaitForSeconds(Time);
        moveToTheNext = true;
    }    
}
