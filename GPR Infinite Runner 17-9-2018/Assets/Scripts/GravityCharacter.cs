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
    [SerializeField]
    float catchupSpeed;
    RaycastHit2D hit;
    Transform cameraPos;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        adjustSpeed();
        Controls();
    }
    void adjustSpeed()
    {
        if(transform.position.x < cameraPos.position.x - 3.36f)
        {
            movementSpeed = catchupSpeed;
        }
        else if(transform.position.x >= cameraPos.position.x - 3.36f)
        {
            movementSpeed = 8;
        }
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
