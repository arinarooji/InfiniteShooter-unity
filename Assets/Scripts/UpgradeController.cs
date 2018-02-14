using UnityEngine;
using System.Collections;

public class UpgradeController : MonoBehaviour
{
    public float speed; //the speed of the object
	
    // Update is called once per frame
	void Update ()
    {
        //moves the object downward at the specified speed
        transform.Translate(Vector2.down * Time.deltaTime * speed);
	}
}
