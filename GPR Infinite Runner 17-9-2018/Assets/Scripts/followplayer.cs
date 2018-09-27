using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour {

    Rigidbody2D camera;
    [SerializeField]
    float cameraSpeed;

    void Start()
    {
        camera = GetComponent<Rigidbody2D>();
        camera.velocity = new Vector3(cameraSpeed, 0, 0);
    }
}
