using UnityEngine;
using System.Collections;

public class DestroyObjects : MonoBehaviour
{
    //the amount of time before the object is destroyed
    public float timeToDestroy;

	void Start ()
    {
        //destroy this object
        //after the time passes
        Destroy(gameObject, timeToDestroy);
	}
}
