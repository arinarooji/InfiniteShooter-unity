using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float speed; //the speed of the bullet
    public int bulletDamage; //how much damage it does

	// Use this for initialization
	void Start ()
    {
        //runs the destroy bullet function
        DestroyBullet();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //move the bullet upward LOCALLY at the speed defined
        //in the editor
        transform.Translate(Vector2.up * speed * Time.deltaTime);    
	}

    //this function destroys the bullet prefab
    //after 2 seconds
    void DestroyBullet()
    {
        if (transform.parent != null)
            Destroy(transform.parent.gameObject, 2);
        else
            Destroy(this.gameObject, 2);
    }

    //Runs when the bullet collides with an object
    //that has a trigger component
    void OnTriggerEnter2D(Collider2D other)
    {
        //checks to see if it is an enemy
        if(other.tag == "enemy")
        {
            //finds the enemy stats scripts attached to the enemy
            EnemyStats es = other.GetComponent<EnemyStats>();
            //runs the Take Damage function on the Enemy Stats script
            //causes damage based on the damage variable declared in the editor
            es.TakeDamage(bulletDamage);
            //destroys this object
            Destroy(this.gameObject);
        }
    }
}
