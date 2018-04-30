using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUnlock : MonoBehaviour {

	public List<Button> m_Levels;

	void LateUpdate(){
		for (int level = 0; level < Levels.Instance.LevelsAdventure; level++) {
			if(level < m_Levels.Count)
				m_Levels[level].interactable = true;
		}
	}
}
