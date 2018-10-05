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


    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        switchColor = new Color32(255,83,54,255);
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

    //private IEnumerator FadeColor(SpriteRenderer sprites)
    //{
    //    float t = 0.015f;
    //    while (t < 1)
    //    {
    //        yield return sprites.color;
    //    }
    //}

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (checkGrounded())
            {
                if (negativeGravity == false)
                {
                    negativeGravity = true;
                    flip.flipY = true;
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
