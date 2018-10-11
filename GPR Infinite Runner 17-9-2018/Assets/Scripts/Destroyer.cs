using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public AudioClip oofSound;
    private AudioSource soundSource;
    [SerializeField]
    private GameObject Player;
    private Transform cameraPos;
    [SerializeField]
    private MainMenu menu;

    private void Update()
    {
        CheckLocation();
    }

    private void Awake()
    {
        menu = GameObject.FindGameObjectWithTag("Manager").GetComponent<MainMenu>();
        soundSource = GetComponent<AudioSource>();
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    private void CheckLocation()
    {
        if (Player.transform.position.x <= (cameraPos.position.x - 12.22f))
        {
            soundSource.Play();
            menu.RetryGame("GameOverScreen");
        }
    }
}
