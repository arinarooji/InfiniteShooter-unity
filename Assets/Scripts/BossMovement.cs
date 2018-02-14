using UnityEngine;
using System.Collections;

public class BossMovement : MonoBehaviour
{
    //declare public variables
    public float speed;
    public float travelTime;
    public float restTime;
    public float horizontalBorder;
    bool beginMove; 
    bool movingRight;

    void Update()
    {
        //if we don't want the ship to move back and forth yet
        if(!beginMove)
        {
            //start moving down
            MoveDown();
        }
        //otherwise, if we want the ship to move back and forth
        else
        {
            //start moving left and right
            MoveSideToSide();
        }
    }

    void MoveDown()
    {
        //if travel time is greater than 0
        if (travelTime > 0)
        {
            //move down and count down travel time by 1
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            travelTime -= 1 * Time.deltaTime;
        }
        //once travel time is 0
        //if rest time is greater than 0
        else if (restTime > 0)
        {
            //wait and count down rest time by 1
            restTime -= 1 * Time.deltaTime;
        }
        //then set begin move to true
        else
        {
            beginMove = true;
        }
    }
    
    void MoveSideToSide()
    {
        //check to see if the boss is moving right
        if(movingRight)
        {
            //move right until the right border is hit
            if (transform.position.x < horizontalBorder)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            //once the border is hit, set moving right to false
            else
                movingRight = false;
        }
        //if moving right is false
        else
        {
            //move left until the left border is hit
            if (transform.position.x > -horizontalBorder)
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            //once the border is hit, set moving right to true
            else
                movingRight = true;
        }
    }
}
