using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacter : MonoBehaviour {

    Rigidbody2D player;
    SpriteRenderer flip;
    bool nagativeGravity = false;
    public float gravityPower = 1;
    float distToGround;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        Controls();
    }
    bool checkGrounded()
    {
        return Physics.Raycast(transform.position, -Vector2.up,  200, 0);
    }
    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (checkGrounded())
            {
                if (nagativeGravity == false)
                {
                nagativeGravity = true;
                flip.flipY = true;
                player.gravityScale = -gravityPower;
                }
                else
                {
                nagativeGravity = false;
                flip.flipY = false;
                player.gravityScale = gravityPower;
                }
            }

        }
    }
}
