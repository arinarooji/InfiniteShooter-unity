using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer;
    public GameObject[] enemyWaves;

    float timer;

    // Use this for initialization
	void Start ()
    {
        timer = spawnTimer;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= 1 * Time.deltaTime;
        if(timer < 0)
        {
            int rand = Random.Range(0, enemyWaves.Length);
            Instantiate(enemyWaves[rand], transform.position, transform.rotation);
            timer = spawnTimer;
        }
	}
}
