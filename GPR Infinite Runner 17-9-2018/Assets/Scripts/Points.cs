using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {

    Transform player;
    [SerializeField]
    Transform start;
    [SerializeField]
    Text score;
    float scoreFloat;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        scoreFloat = Vector3.Distance(start.position, player.position);
        score.text = "Score: " + Mathf.Round(scoreFloat);
    }

}
