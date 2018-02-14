using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed; //how quickly the player moves
    public string moveLeftKey, moveRightKey, moveUpKey, moveDownKey; //which keys move the player
    public GameObject[] shipLevel; //an array of the different ships
    public AudioClip pickup; //the audio clip for the pickups

    GameObject playerShip; //the player ship

    void Start()
    {
        //sets the intitial power level to zero
        GlobalVar.powerLevel = 0; 
    }

	void Update ()
    {   
        //checks to see which direction key is pressed
        //and moves in that direction
        if (Input.GetKey(moveLeftKey))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(moveRightKey))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(moveUpKey))
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (Input.GetKey(moveDownKey))
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    //this function is called when the player object
    //collides with another object with a Trigger Collider component
    void OnTriggerEnter2D(Collider2D other)
    {
        //if it is the weapon upgrade item
        if (other.tag == "weaponUpgrade")
        {
            //destroys the upgrade object
            Destroy(other.gameObject);
            //if the power level isn't at max
            if (GlobalVar.powerLevel < 2)
            {
                //add one to the power level
                //and upgrade the weapon
                GlobalVar.powerLevel += 1;
                UpgradeWeapons();
            }
        }
        
        //if it is the ship upgrade item
        if (other.tag == "shipUpgrade")
        {
            //destroy the upgrade item
            Destroy(other.gameObject);
            //if the ship isn't upgraded to maximum
            if(GlobalVar.upgradeLevel < 2)
            {
                //add one to upgrade level
                //and upgrade the ships
                GlobalVar.upgradeLevel += 1;
                NewShip(shipLevel[GlobalVar.upgradeLevel]);
                //destroys the old ship
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }

    //this function upgrades the ship
    void NewShip(GameObject ship)
    {
        //creates a new ship and defines it as newShip
        GameObject newShip = Instantiate(ship, transform.position, transform.rotation) as GameObject;
        
        //makes the new ship a child of the player controller
        newShip.transform.parent = this.gameObject.transform;
        
        //plays the pickup sound if it is attached
        if (pickup != null) PlaySound(pickup);
    }

    //this function upgrades the player's weapons
    void UpgradeWeapons()
    {
        //defines the player's ship
        playerShip = gameObject.transform.GetChild(0).gameObject;
        //finds the weapon controller script attached to the ship
        WeaponController wc = playerShip.GetComponent<WeaponController>();
        //runs the switch weapon script attached to the ship
        wc.SwitchWeapons();

        //plays the pickup sound if it is attached
        if (pickup != null) PlaySound(pickup);
    }
    
    //this function plays a sound
    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
