using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    Rigidbody2D Platform;
    public float speed = 0.05f;

    private void Awake()
    {
        Platform = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Platform.position = new Vector2(Platform.position.x - speed, Platform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }

}
