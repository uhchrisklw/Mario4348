using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_movement : MonoBehaviour {

    public float speed = 2.5f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move the mario sprite from (0, 0, 0) to (0, 2, 0) and to (0, -5, 0)
        /* Idea for death animation, if falling through the level  doesn't work
           Animate up down movement in y plane
        transform.position = new Vector2(PlayerMovement, 0);

        transform.position = new Vector2(0, 0);
        */
    }
}
