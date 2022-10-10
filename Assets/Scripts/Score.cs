using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_FontAsset theFont;
    //declaring variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreValueText;
    public GameObject highScoreText;
    public Player pScript;
    public float scoreValue;
    public int highScore;

    void Start()
    {
        scoreText.font = theFont;
        highScoreValueText.font = theFont;
        //deactivate the highscore text
        highScoreText.SetActive(false);
        //save the highscore amount
        highScore = PlayerPrefs.GetInt("saveScore");
        //fetch the text component
        scoreText = GetComponent<TextMeshProUGUI>();
        //initial score value is 0
        scoreValue = 0;
    }

    void Update()
    {
        //fetching the Player's script to check boolean gameOver variable
        if (pScript.gameOver == false)
        {
            //multiplying increment's seconds per machine time
            scoreValue += Time.deltaTime * 5;
            //updating score value
            scoreText.text = "score: " + (int)scoreValue;

            if (scoreValue > highScore)
            {
                //saving the highscore only if higher than the previous one saved
                PlayerPrefs.SetInt("saveScore", (int)scoreValue);
            }
        }

        //fetching the Player's script to check boolean gameOver variable
        if (pScript.gameOver == true)
        {

            //displaying the highscore value if higher than previous one saved
            if (scoreValue > highScore)
            {
                //displaying highscore text
                highScoreText.SetActive(true);
                //displaying highscore value
                highScoreValueText.text = "new highscore! " + (int)scoreValue;
            }
        }
    }
}
