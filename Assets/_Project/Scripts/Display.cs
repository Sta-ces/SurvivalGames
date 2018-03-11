using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : Singleton<Display> {

	[Header("GameOver")]
	public GameObject m_GameOverPanel;

	[Header("Winner")]
	public GameObject m_WinnerPanel;

	[Header("Pause")]
	public GameObject m_PausePanel;

	[Header("Scoring")]
	public Text m_ScoreText;


	public void SetDisplayGameOver(bool _active){ m_GameOverPanel.SetActive(_active); }
	public void SetDisplayWinner(bool _active){ m_WinnerPanel.SetActive(_active); }
	public void SetDisplayPause(){ m_PausePanel.SetActive(!m_PausePanel.activeSelf); }
	public void SetDisplayScore(int _score){ SetDisplayScore(_score.ToString()); }
	public void SetDisplayScore(string _score){ m_ScoreText.text = _score; }

	public void CharacterDead(){
		SetDisplayScore(Score.Instance.GetScore());
		SetDisplayGameOver(true);
	}
}
