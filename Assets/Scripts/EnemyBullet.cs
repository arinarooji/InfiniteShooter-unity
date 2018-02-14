using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
	
    // Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector2.MoveTowards(transform.position, target, speed);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
