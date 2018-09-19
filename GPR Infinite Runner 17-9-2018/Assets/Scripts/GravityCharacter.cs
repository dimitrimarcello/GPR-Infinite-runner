using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCharacter : MonoBehaviour {

    Rigidbody2D player;
    bool nagativeGravity = false;
    public float gravityPower = 1;
    public int rotateSpeed = 0;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Controls();
    }
    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(nagativeGravity == false)
            {
                player.gravityScale = -gravityPower;
                transform.up = Vector3.Lerp(transform.up, 12, rotateSpeed * Time.deltaTime);
                nagativeGravity = true;
            }
            else
            {
                nagativeGravity = false;
                player.gravityScale = gravityPower;
            }
        }
    }
}
