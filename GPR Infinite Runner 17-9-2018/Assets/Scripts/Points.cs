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
    [SerializeField]
    Text highScoreText;
    float scoreFloat;
    float highScore;
    //this script calculates the distance from start to end and converts it to points. also a playerprefs has been created to save highscore local 
    private void Update()
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        scoreFloat = Vector3.Distance(start.position, player.position);
        if (scoreFloat > highScore)
            PlayerPrefs.SetFloat("highscore", scoreFloat);
        score.text = "Score: " + Mathf.Round(scoreFloat);
        highScoreText.text = "High Score: " + Mathf.Round(highScore); 
    }

}
