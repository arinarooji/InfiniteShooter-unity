using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour
{
    //these variables are related to controlling the lives display
    public int numberOfLives;
    public Transform livesController;
    public GameObject levelController;

    //these variables are used to destroy and respawn the player
    float respawnTimer = 2;
    SpriteRenderer sr;
    Collider2D shipCollider;
    Collider2D controllerCollider;
    public GameObject explosion;
    public AudioClip explosionSound;
    
    //this is used after the player dies
    public GameObject gameOverIcon;

    
    // Use this for initialization
    void Start ()
    {
        GlobalVar.canShoot = true;
	}
	
    //when the player ship collides with an object
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the other object is an enemy or enemy bullet
        if(other.tag == "enemy" || other.tag == "enemyBullet")
        {
            //reduce lives by one and run the destroy ship function 
            numberOfLives -= 1;
            DestroyShip();

            //if there are still no live left
            if(numberOfLives <= 0)
            {
                //run the Game Over function
                GameOver();
            }
        }
    }

    void DestroyShip()
    {
        //make it so the player can not shoot
        GlobalVar.canShoot = false;
        
        //create the explosion animation
        if(explosion != null)
            Instantiate(explosion, transform.position, transform.rotation);
        
        //play the explosion sound
        if (explosionSound != null)
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position);

        //define and destroy one of the life icons
        Transform toDestroy = livesController.GetChild(numberOfLives);
        Destroy(toDestroy.gameObject);

        //reset power levels
        GlobalVar.powerLevel = 0;
        WeaponController wc = transform.GetChild(0).GetComponent<WeaponController>();
        wc.SwitchWeapons();

        //define the current ship sprite and collider
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        shipCollider = transform.GetChild(0).GetComponent<Collider2D>();
        //define the main collider
        controllerCollider = GetComponent<Collider2D>();

        //disable the sprite renderer so the ship is no longer visible
        sr.enabled = false;

        //disable to ship collider and main collider so
        //they no longer collide with objects in the scene
        shipCollider.enabled = false;
        controllerCollider.enabled = false;

        //if there are still lives left over
        //run the return sprite function with a delay
        if (numberOfLives > 0)
            Invoke("ReturnSprite", respawnTimer);
        else
            GameOver();
    }

    void ReturnSprite()
    {
        if (numberOfLives > 0)
        {
            //make it so the player can shoot again
            GlobalVar.canShoot = true;
            //enable the sprite renderer so the ship is visible again
            sr.enabled = true;
            //run the Return collider function after a delay
            //to give the player temporary invincibility
            Invoke("ReturnCollider", respawnTimer);
        }
        else
            GameOver();
    }

    void ReturnCollider()
    {
        if (numberOfLives > 0)
        {
            //enable the ship collider and main collider
            //so the player can collide with objects again
            shipCollider.enabled = true;
            controllerCollider.enabled = true;
        }
        else
            GameOver();
    }

    void GameOver()
    {
        //show the game over icon
        Instantiate(gameOverIcon, Vector2.zero, Quaternion.identity);
    }
}
