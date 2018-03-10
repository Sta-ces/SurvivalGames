using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : Singleton<Display> {

	[Header("GameOver")]
	public GameObject m_GameOverPanel;

	[Header("Scoring")]
	public Text m_ScoreText;


	public void DisplayGameOver(bool _active){ m_GameOverPanel.SetActive(_active); }
	public void DisplayScore(int _score){ DisplayScore(_score.ToString()); }
	public void DisplayScore(string _score){ m_ScoreText.text = _score; }


	private void Update(){
		if( !CharacterControler.Instance.gameObject.activeSelf ){
			DisplayScore(Score.Instance.GetScore());
			DisplayGameOver(true);
		}
	}
}
