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

    public static void ResetScore()
    {
        Score = 0;
    }

    public void SetScoreReset(){
        ResetScore();
    }


    private void Awake()
    {
        Highscore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("HighScore", Highscore);
        m_HighScoreText.text = Highscore.ToString();
    }

    private void LateUpdate()
    {
        if ( Score > Highscore )
            SetHighscore();
            
        DisplayScore();
    }



    private void SetHighscore()
    {
        Highscore = Score;
        PlayerPrefs.SetInt("HighScore", Highscore);
        m_HighScoreText.text = Highscore.ToString();
    }
    
    private void DisplayScore()
    {
        m_ScoreText.text = Score.ToString();
    }
}
