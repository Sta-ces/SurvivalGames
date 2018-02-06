using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour {

    public Canvas m_MenuInGame;


    private void Update()
    {
        Player input = CharacterControlerGames.PlayerInput;
        if ( input.GetButtonDown("Pause") )
            Paused();
        if ( input.GetButtonDown("Cancel") && m_MenuInGame.gameObject.activeSelf )
            Paused();
    }

    private void Paused()
    {
        m_MenuInGame.gameObject.SetActive(!m_MenuInGame.gameObject.activeSelf);
        LoadingLevels.PausedGame();
    }
}
