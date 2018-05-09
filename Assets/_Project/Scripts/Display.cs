using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Display : SimpleSingleton<Display> {

	[Header("GameOver")]
	public UnityEvent GameOver;

	[Header("Winner")]
	public UnityEvent Winner;

	[Header("Pause")]
	public UnityEvent Pause;

	[Header("Scoring")]
	public Text m_Score;
	public Text m_Pieces;
	public Text m_ScoreGameOverText;
	public Text m_HighscoreGameOverText;
	public Text m_ScoreWinnerText;
	public Text m_HighscoreWinnerText;


	public void SetDisplayGameOver(){
		GameOver.Invoke();
	}
	public void SetDisplayWinner(){
		Winner.Invoke();
	}
	public void SetDisplayPause(){
		Pause.Invoke();
	}

	public void DisplayAllScoring(){
		SetDisplayPieces();
		SetDisplayScore();
		SetDisplayHighScore();
	}

	public void SetDisplayPieces(){ SetDisplayPieces (Score.Instance.GetPieces); }
	public void SetDisplayPieces(int _pieces){ SetDisplayPieces (_pieces.ToString()); }
	public void SetDisplayPieces(string _pieces){
		if (m_Pieces != null)
			m_Pieces.text = _pieces;
	}

	public void SetDisplayScore(){ SetDisplayScore(Score.Instance.GetScore); }
	public void SetDisplayScore(int _score){ SetDisplayScore(_score.ToString()); }
	public void SetDisplayScore(string _score){
		if (m_Score != null)
			m_Score.text = _score;
		
		if (m_ScoreGameOverText != null)
			m_ScoreGameOverText.text = _score;
		
		if (m_ScoreWinnerText != null)
			m_ScoreWinnerText.text = _score;
	}

	public void SetDisplayHighScore(){ SetDisplayHighScore(Score.Instance.GetHighscore); }
	public void SetDisplayHighScore(int _highscore){ SetDisplayHighScore(_highscore.ToString()); }
	public void SetDisplayHighScore(string _highscore){
		if (m_HighscoreGameOverText != null)
			m_HighscoreGameOverText.text = _highscore;

		if (m_HighscoreWinnerText != null)
			m_HighscoreWinnerText.text = _highscore;
	}

	public void CharacterDead(){
		SetDisplayPieces(Score.Instance.GetPieces);
		SetDisplayGameOver();
	}


	private void OnEnable(){
		SetDisplayPieces(Score.Instance.GetPieces);
		DisplayAllScoring();
	}
}
