using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    private PlayerMovement player;

    void Start()
    {
        player = gameObject.GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }
}
