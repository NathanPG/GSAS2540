﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is to control scores
/// </summary>
public class ScoreController : MonoBehaviour
{
    public Text HighScoreText;

    //Update playerpref of score
    public void UpdateScore(int currentscore)
    {
        string tempstring = "";
        if (PlayerPrefs.HasKey("High Score 1: "))
        {
            for (int i = 1; i <= 10; i++)
            {
                tempstring = "High Score " + i + ": ";
                if (PlayerPrefs.GetInt(tempstring) < currentscore)
                {
                    PlayerPrefs.SetInt(tempstring, currentscore);
                    return;
                }
            }
        }
        else
        {
            for(int i = 1; i<=10; i++)
            {
                tempstring = "High Score " + i + ": ";
                PlayerPrefs.SetInt(tempstring, 0);
            }
            PlayerPrefs.SetInt("High Score 1: ", currentscore);
        }

    }

    //Update the score text object
    public void DisplayScore()
    {
        string tempstring = "";
        HighScoreText.text = "";
        for (int i = 1; i <= 10; i++)
        {
            tempstring = "High Score " + i + ": ";
            HighScoreText.text += "High Score " + i + ": " + PlayerPrefs.GetInt(tempstring)+"\n";
        }
    }

}
