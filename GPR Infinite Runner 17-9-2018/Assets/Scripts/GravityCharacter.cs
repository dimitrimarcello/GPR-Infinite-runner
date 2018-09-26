using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacter : MonoBehaviour {

    [SerializeField]
    LayerMask mask;
    [SerializeField]
    private float checkHeight;
    Rigidbody2D player;
    SpriteRenderer flip;
    bool nagativeGravity = false;
    public float gravityPower = 1;
    float distToGround;
    [SerializeField]
    float movementSpeed;
    RaycastHit2D hit;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        player.velocity = new Vector3(movementSpeed, 0, 0);
        Controls();
    }
    bool checkGrounded()
    {
        if(nagativeGravity == false)
        {
            hit = Physics2D.Raycast(transform.position, -Vector2.up, checkHeight, mask);
        }
        else if (nagativeGravity == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, checkHeight, mask);
        }
        
        return hit.collider == null ? false : true;
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
                    player.AddForce(-player.transform.up * 0);
                    player.gravityScale = -gravityPower;
                }
                else
                {
                    nagativeGravity = false;
                    flip.flipY = false;
                    player.AddForce(player.transform.up * 0);
                    player.gravityScale = gravityPower;
                }
            }

        }
    }
}
