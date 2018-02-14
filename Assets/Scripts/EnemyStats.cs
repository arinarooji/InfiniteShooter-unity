using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour
{
    public int health; //the amount of health the enemy has
    public AudioClip death; //the sound effect played on death

    void Update()
    {
        //checks to see if enemy health is 0
        if (health < 1)
        {
            //checks to see that the death variable
            //has been assigned in the editor
            //and plays the death sound
            if (death != null)
                PlaySound(death);
            
            //destroys the enemy
            Destroy(this.gameObject);    
        } 
    }

    //this function applies damage to the enemy
    //it is called from the bullet controller script
    public void TakeDamage(int dmg)
    {
        //the value of dmg when the function is called
        //is subtracted from the enemy health
        //the Debug Log display the current enemy health for testing
        health -= dmg;
        Debug.Log("Enemy Health = " + health);
    }

    //This function plays a sound
    void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
    }
}
