using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour
{
    Transform spawner;

    void Start()
    {
        //find the child of the boss object
        //and assign it as the spawner
        spawner = transform.GetChild(0);
    }

    //this function is run as an event inside the boss animation
    //the bullet you want to spawn is passed into the event directly
    void BulletPattern(GameObject pattern)
    {
        //if spawner exists
        if(spawner != null)
        {
            //spawn a bullet and assign it to a bullet variable
            GameObject bullet = Instantiate(pattern, spawner.position, pattern.transform.rotation) as GameObject;
            //find the boss bullets script attached to the spawned bullet
            BossBullets bb = bullet.GetComponent<BossBullets>();
            //if the script exists
            if (bb != null)
            //assign the spawner above to
            //that bullets spawner
            bb.spawner = spawner;
        }       
    }
}
