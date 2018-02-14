using UnityEngine;
using System.Collections;

public class BorderScript : MonoBehaviour
{
    public float horizontalBorder; //the horizontal border defined in the editor
    public float verticalBorder; //the vertical border defined in the editor

    //Late Update is called a the END of every frame
    void LateUpdate()
    {
        //checks to see if the player has reached
        //the right side of the screen
        if(transform.position.x > horizontalBorder)
        {
            //sets the position back to where it was when it
            //hit the side of the screen
            transform.position = new Vector2(horizontalBorder, transform.position.y);
        }
        //checks to see if the player has reached
        //the left side of the screen
        else if(transform.position.x < -horizontalBorder)
        {
            transform.position = new Vector2(-horizontalBorder, transform.position.y);
        }

        //checks to see if the player has reached
        //the top of the screen
        if(transform.position.y > verticalBorder)
        {
            transform.position = new Vector2(transform.position.x, verticalBorder);
        }
        //checks to see if the player has reached
        //the bottom of the screen
        else if(transform.position.y < -verticalBorder)
        {
            transform.position = new Vector2(transform.position.x, -verticalBorder);
        }

    }
}
