using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour
{
    public float backgroundSpeed; //speed the background scrolls

    Renderer rend; //the renderer component

	// Use this for initialization
	void Start ()
    {
        //defines the renderer component and assigns it
        //to the rend variable
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //offsets the background layer over time
        //to create a scrolling effect
        Vector2 offset = new Vector2(0, Time.time * backgroundSpeed);
        rend.material.mainTextureOffset = offset;
	}
}
