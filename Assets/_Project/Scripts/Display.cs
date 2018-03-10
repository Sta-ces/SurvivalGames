using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : Singleton<Display> {

	[Header("GameOver")]
	public GameObject m_GameOverPanel;

	[Header("Scoring")]
	public Text m_ScoreText;


	public void SetDisplayGameOver(bool _active){ m_GameOverPanel.SetActive(_active); }
	public void SetDisplayScore(int _score){ SetDisplayScore(_score.ToString()); }
	public void SetDisplayScore(string _score){ m_ScoreText.text = _score; }


	private void Update(){
		if( !CharacterControler.Instance.gameObject.activeSelf ){
			SetDisplayScore(Score.Instance.GetScore());
			SetDisplayGameOver(true);
		}
	}
}
