using UnityEngine;
using System.Collections;

public class MainLevelController : MonoBehaviour
{
    //declare our variables
    public int numberOfEnemyWaves;
    public float enemySpawnTimer;
    public GameObject[] enemyWaves;
    public GameObject boss;
    public Transform waveSpawner;

    float spawnTimer;
    bool keepSpawning = true;

    public GameObject getReadyIcon;
	
    // Use this for initialization
	void Start ()
    {
        //set spawnTimer to value indicated in the editor
        spawnTimer = enemySpawnTimer;
        //create the getReadyIcon
        Instantiate(getReadyIcon, Vector2.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check to see if there are still more enemy waves to spawn
        //and that we should keep spawning them
        if (numberOfEnemyWaves >= 1 && keepSpawning)
        {
            //reduce spawn timer
            spawnTimer -= 1 * Time.deltaTime;
            //when spawn timer reaches zero
            if (spawnTimer <= 0)
            {
                //spawn enemies and reset the spawn timer
                SpawnEnemies();
                spawnTimer = enemySpawnTimer;
            }
        }
        //if all enemies have spawned above
        else if(keepSpawning)
        {
            //reset spawn timer
            //and spawn the boss
            //and make it so nothing else spawns
            spawnTimer = enemySpawnTimer;
            Invoke("SpawnBoss", enemySpawnTimer * 1.5f);
            keepSpawning = false;
        }
	}


    void SpawnEnemies()
    {
        //pick a random enemy wave and spawn it
        int rnd = Random.Range(0, enemyWaves.Length);
        Instantiate(enemyWaves[rnd], waveSpawner.transform.position, waveSpawner.transform.rotation);
        //subtract 1 from the total number of spawns left
        numberOfEnemyWaves -= 1;
    }

    void SpawnBoss()
    {
        //spawn boss enemy
        Instantiate(boss, waveSpawner.transform.position, waveSpawner.transform.rotation);
    }
}
