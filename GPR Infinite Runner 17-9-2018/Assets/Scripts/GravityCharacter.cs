using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityCharacter : MonoBehaviour {

    [SerializeField]
    LayerMask mask;
    [SerializeField]
    private float checkHeight;
    Rigidbody2D player;
    SpriteRenderer flip;
    bool negativeGravity = false;
    public float gravityPower = 1;
    float distToGround;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float catchupSpeed;
    RaycastHit2D hit;
    Transform cameraPos;
    GameObject[] chunksColor;
    Color32 switchColor;
    [SerializeField]
    Animator buttonAnime;
    [SerializeField]
    Image buttonImage;


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        switchColor = new Color32(0,255,255,255);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        adjustSpeed();
        Controls();
        SwitchEffect();
    }
    void adjustSpeed()
    {
        //this allows the character to maintain near the camera.
        if(transform.position.x < cameraPos.position.x - 7f)
        {
            buttonImage.enabled = true;
            buttonAnime.Play("usebutton");
        }
        else
        {
            buttonImage.enabled = false;
        }
        if (transform.position.x < cameraPos.position.x - 3.36f && Input.GetKeyUp(KeyCode.RightArrow) && checkGrounded())
        {
            movementSpeed = catchupSpeed;
        }
        else
        {
            movementSpeed = 8;
        }
        
    }
    bool checkGrounded()
    {
        //this should make sense it checks if the player is grounded with the use of a raycast. it checks up if player gravity is negative 
        //and down if player has positive gravity
        if(negativeGravity == false)
        {
            hit = Physics2D.Raycast(transform.position, -Vector2.up, checkHeight, mask);
        }
        else if (negativeGravity == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, checkHeight, mask);
        }
        
        return hit.collider == null ? false : true;
    }
    void SwitchEffect()
    {
        //this switches color for all front objects with the use of a for loop
        chunksColor = GameObject.FindGameObjectsWithTag("Chunks");
        if (negativeGravity == true)
        {
            for (int i = 0; i < chunksColor.Length; i++)
            {
                SpriteRenderer a;
                if (chunksColor[i].GetComponent<SpriteRenderer>() != null)
                {
                    a = chunksColor[i].GetComponent<SpriteRenderer>();
                    a.color = Color32.Lerp(Color.white, switchColor,1);
                }
            }
        }
        else
        {
            for (int i = 0; i < chunksColor.Length; i++)
            {
                SpriteRenderer a;
                if (chunksColor[i].GetComponent<SpriteRenderer>() != null)
                {
                    a = chunksColor[i].GetComponent<SpriteRenderer>();
                    a.color = Color.white;
                }
            }
        }
        
    }

    void Controls()
    {
        //this is easy it switches the gravity negative and positive with the spacebar it also flips the sprite.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (checkGrounded())
            {
                if (negativeGravity == false)
                {
                    negativeGravity = true;
                    flip.flipY = true;
                    //we had to add a force = 0; so that the switch would be instant.
                    player.AddForce(-player.transform.up * 0);
                    player.gravityScale = -gravityPower;
                }
                else
                {
                    negativeGravity = false;
                    flip.flipY = false;
                    player.AddForce(player.transform.up * 0);
                    player.gravityScale = gravityPower;
                }
            }

        }
    }
}
