using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text m_ScoreText;
    public Text m_HighScoreText;

    public static int Score = 0;
    public static int Highscore = 0;

    public static void AddScore(int _addScore)
    {
        Score += _addScore;
    }

    public void ResetScore()
    {
        Score = 0;
    }


    private void Awake()
    {
        Highscore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("HighScore", Highscore);
        m_HighScoreText.text = Highscore.ToString();
    }

    private void LateUpdate()
    {
        DisplayScore();
        if ( Score > Highscore )
            SetHighscore();
    }


    private void DisplayScore()
    {
        m_ScoreText.text = Score.ToString();
    }

    private void SetHighscore()
    {
        Highscore = Score;
        PlayerPrefs.SetInt("HighScore", Highscore);
        m_HighScoreText.text = Highscore.ToString();
    }
}
