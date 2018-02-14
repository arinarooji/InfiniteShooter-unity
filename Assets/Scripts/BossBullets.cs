using UnityEngine;
using System.Collections;

public class BossBullets : MonoBehaviour
{
    public float speed;
    public bool isDelay;
    public float delay;

    public Transform spawner;
	
	// Update is called once per frame
	void Update ()
    {
        //if the bullet should delay
        if(isDelay && spawner != null)
        {
            //count down delay time by 1
            //and follow the spawner object
            delay -= 1 * Time.deltaTime;
            transform.position = spawner.position;
        }
        //once delay is equal to or less than 0
        if(delay <= 0)
        {
            //set isDelay to false
            //and move in the upward direction (Whatever direction y is pointing)
            isDelay = false;
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
	}
}
