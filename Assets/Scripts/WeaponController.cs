using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    //declare public variables
    public GameObject[] bulletLevel; //used to determine bullet power
    public string fireKey; //button you press to fire
    public float fireDelay; //sets delay betwen bullets when holding down the fire button
    public AudioClip[] fire; //Array of fire sounds

    //declare private variables
    Transform spawner; //reference to object where bullet spawns
    float delay; //used as a timer for bullet delay
    GameObject bullet; //changes depending on powerlevel and ship level

    // Use this for initialization
    void Start ()
    {
        //finds spawner object in the scene
        //sets initial delay, and
        //sets initial weapon level  
        spawner = transform.GetChild(0).transform;
        delay = fireDelay;
        SwitchWeapons();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //counts down the delay until it reaches zero
        //fires a bullet and resets delay back to initial delay 
        delay -= 1 * Time.deltaTime;
	    if(Input.GetKey(fireKey) && delay <= 0 && GlobalVar.canShoot)
        {
            FireBullet();
            delay = fireDelay;
        }
	}

    //creates the bullets and plays the bullet sounds
    void FireBullet()
    {
        Instantiate(bullet, spawner.position, spawner.rotation);
        if(fire.Length > 0)
        {
            PlaySound(fire[GlobalVar.upgradeLevel]);
        }
    }

    //plays a sound at the cameras location
    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }

    //Checks the powerlevel and changes bullet prefab
    public void SwitchWeapons()
    {
        switch (GlobalVar.powerLevel)
        {
            case 0: bullet = bulletLevel[0]; break;
            case 1: bullet = bulletLevel[1]; break;
            case 2: bullet = bulletLevel[2]; break;
            default: bullet = bulletLevel[0]; break;
        }
    }
}
