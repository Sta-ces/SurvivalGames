using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Display : SimpleSingleton<Display> {

	public EventSystem m_RewiredEventSystem;

	[Header("GameOver")]
	public GameObject m_GameOverPanel;
	public GameObject m_FirstButtonGameOver;

	[Header("Winner")]
	public GameObject m_WinnerPanel;
	public GameObject m_FirstButtonWinner;

	[Header("Pause")]
	public GameObject m_PausePanel;
	public GameObject m_FirstButtonPause;

	[Header("Scoring")]
	public Text m_ScoreGameOverText;
	public Text m_ScoreWinnerText;


	public void SetDisplayGameOver(bool _active){
		m_GameOverPanel.SetActive(_active);
		if( m_GameOverPanel.activeSelf )
			SetFirstSelected( m_FirstButtonGameOver );
	}
	public void SetDisplayWinner(bool _active){
		m_WinnerPanel.SetActive(_active);
		if( m_WinnerPanel.activeSelf )
			SetFirstSelected( m_FirstButtonWinner );
	}
	public void SetDisplayPause(){
		m_PausePanel.SetActive(!m_PausePanel.activeSelf);
		if( m_PausePanel.activeSelf )
			SetFirstSelected( m_FirstButtonPause );
	}
	public void SetDisplayScore(int _score){ SetDisplayScore(_score.ToString()); }
	public void SetDisplayScore(string _score){
		m_ScoreGameOverText.text = _score;
		m_ScoreWinnerText.text = _score;
	}
	public void SetFirstSelected(GameObject _firstButton){
		m_RewiredEventSystem.SetSelectedGameObject(_firstButton);
	}

	public void CharacterDead(){
		SetDisplayScore(Score.Instance.GetScore());
		SetDisplayGameOver(true);
	}
}
