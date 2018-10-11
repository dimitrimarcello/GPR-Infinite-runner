using UnityEngine;
using System.Collections;

public class BGscroll : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeX;
    private float newPosition;
    private Transform camera;

    private Vector3 startPosition;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        startPosition = new Vector3(camera.position.x - 2, startPosition.y, startPosition.z);
    }

    void Update()
    {
        newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + new Vector3(1, 0, startPosition.z) * newPosition;
    }
}