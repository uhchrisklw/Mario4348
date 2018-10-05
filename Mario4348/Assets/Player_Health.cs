using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour {

    public int health;
    public bool hasDied;
	// Use this for initialization
	void Start () {
        hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -.0423){
            // Debug.Log("Player has died");
            // Commented out, may be useful for debugging
            hasDied = true;
        }
        if (hasDied == true){
            // Maybe can test once we implement left right movement
            StartCoroutine("Die");
        }
	}

    IEnumerator Die()
    {
        Debug.Log("player has fallen");
        yield return new WaitForSeconds(2);
        Debug.Log("player has died");
    }

    public void Die2()
    {
        if(!hasDied)
        {
            hasDied = true;
            // Setting all colliders to triggers should let the player fall through the level
            // Find all colliders on the gameobject ad set them all to be triggers.
            Collider2D[] cols = GetComponents<Collider2D>();
            foreach(Collider2D c in cols)
            {
                c.isTrigger = true;
            }

            // Move all sprite parts of the player to the front by placing them on the UI sorting layer
            SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
            foreach(SpriteRenderer s in spr)
            {
                s.sortingLayerName = "UI";
            }

            // Play the animation for death
            // anim.SetTrigger("mario_death");

        // disable  the health UI
       
        }
    }
}


