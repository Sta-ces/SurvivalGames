using UnityEngine;

public class Score : SimpleSingleton<Score> {

    public int GetScore(){ return m_score; }
    public int GetHighscore(){ return m_highscore; }

    public void AddScore(int _addScore = 1){
        m_score += _addScore;

        if ( m_score > m_highscore ){
            SetHighscore();
        }
    }
    public void ResetScore(){
        m_score = 0;
        m_highscore = PlayerPrefs.GetInt("HighScore");
    }
    public void SetHighscore(){
        m_highscore = m_score;
        PlayerPrefs.SetInt("HighScore", m_highscore);
    }


    private int m_score = 0;
    private int m_highscore = 0;
}
