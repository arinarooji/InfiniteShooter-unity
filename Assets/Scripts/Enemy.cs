using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed;
    public string shipType;
    public float travelTime;
    public float restTime;
    public GameObject spawner;
    public GameObject bullet;
    public GameObject player;
    
    public bool canShoot;
    public bool lookAtPlayer;

    void Start()
    {
        //float posX = transform.position.x + offsetRange * Random.value;
        //Vector2 offset = new Vector2(posX, transform.position.y);
        //transform.position = offset;
    }

    void Update()
    {
        ShipControl(shipType);
    }

    void ShipControl(string type)
    {
        switch(type)
        {
            case "basic": Move(); break;
            case "shooting": Move(); break;
            case "moveShoot": Move(); PointAt(); break;
        }
    }

    void Move()
    {
        if(travelTime > 0)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            travelTime -= 1 * Time.deltaTime;
        }
        else if(restTime > 0)
        {
            if(canShoot)
                Shoot();
            restTime -= 1 * Time.deltaTime;
        }
        else
        {
            if (canShoot)
                Shoot();
            travelTime += 1;
            Move();
        }
    }

    void PointAt()
    {
        if(spawner != null && player != null)
            spawner.transform.up = player.transform.position - transform.position;
    }

    void Shoot()
    {
        if(bullet != null && spawner != null)
        {
            GameObject thisBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation) as GameObject;
            canShoot = false;
        }
            
    }
}
