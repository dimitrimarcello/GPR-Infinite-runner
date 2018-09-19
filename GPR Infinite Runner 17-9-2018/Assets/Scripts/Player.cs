using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D player;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(player.transform.up * 200);
        }        
        if(player.position.y < -3.4f)
        {
            player.position = new Vector2(player.position.x, -3.4f);
        }
        if (player.position.y < -5.5f)
        {
            player.position = new Vector2(player.position.x, -5.5f);
        }
    }

}
