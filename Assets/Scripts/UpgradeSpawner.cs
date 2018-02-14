using UnityEngine;
using System.Collections;

public class UpgradeSpawner : MonoBehaviour
{
    public GameObject[] upgrades; //array of upgrade prefabs
    public float timer; //used to determine initial offset for reseting the timer

    public float currentTimer; //used for current countdown for spawning

    void Start()
    {
        //sets a random initial time based on the timer variable
        //and adds 10 seconds to create a minimum time for spawns
        currentTimer = Random.value * timer + 10;    
    }
    
    void Update()
    {
        //current timer counts down
        currentTimer -= 1 * Time.deltaTime;
        //when it reaches 0 it runs the Spawn Upgrade Function
        //and resets the current timer
        if(currentTimer <= 0)
        {
            SpawnUpgrade();
            currentTimer = Random.value * timer + 10;
        }
    }

    //this function randomly picks an upgrade to spawn
    void SpawnUpgrade()
    {
        //get a random number
        int rnd = Random.Range(0, upgrades.Length);
        //spawn a random upgrade from the array
        Instantiate(upgrades[rnd], transform.position, transform.rotation);
    }
}
