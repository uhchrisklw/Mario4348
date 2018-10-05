using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    public GameObject Player;
    //Defines boundaries, most and least it can travel on x and y plane
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;
    

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");   
        // Finds any object with the tag player and associates that with this variable
	}
	
	// Update is called once per frame
    // Gets called at end of update cycle
	void LateUpdate () {
        float x = Mathf.Clamp(Player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(Player.transform.position.y, yMin, yMax);
        // Don't want to change z, our game is 2D      
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
	}
}
