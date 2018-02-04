using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text m_ScoreText;

    public static int Score = 0;

    public static void AddScore(int _addScore)
    {
        Score += _addScore;
    }


    private void LateUpdate()
    {
        DisplayScore();
    }


    private void DisplayScore()
    {
        m_ScoreText.text = Score.ToString();
    }
}
