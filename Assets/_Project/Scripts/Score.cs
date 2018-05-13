using UnityEngine;

public class Score : SimpleSingleton<Score> {

	private static int score = 0;
    public int GetScore{
		get{ return score; }
		set{ score = value; }
	}

    public int GetHighscore{
		get{ return PlayerPrefs.GetInt("HighScore", 0); }
		set{ PlayerPrefs.SetInt("HighScore", value); }
	}

	public int GetPieces{
		get{ return PlayerPrefs.GetInt ("Pieces", 0); }
		set{ PlayerPrefs.SetInt("Pieces", value); }
	}

    public void AddScore(int _addScore = 1){
		Score.Instance.GetScore += _addScore;

		if ( Score.Instance.GetScore > Score.Instance.GetHighscore )
			Score.Instance.GetHighscore = Score.Instance.GetScore;

        if ( Score.Instance.GetScore % Difficulties.Instance.HowMuchKilled == 0 )
        	Difficulties.Instance.GrowDifficulties();
	}

	public void AddPieces(int _addPieces = 1){
		Score.Instance.GetPieces += _addPieces;
	}

    public void ResetScore(){
		Score.Instance.GetScore = 0;
    }
}
