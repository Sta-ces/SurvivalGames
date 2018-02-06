using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour {

    public Canvas m_MenuInGame;

    public static bool IsPaused = false;


    private void Update()
    {
        Player input = CharacterControlerGames.PlayerInput;
        if ( input.GetButtonDown("Pause") )
            Paused();
        if ( input.GetButtonDown("Cancel") && m_MenuInGame.gameObject.activeSelf )
            Paused();

        IsPaused = m_MenuInGame.gameObject.activeSelf;
    }

    private void Paused()
    {
        m_MenuInGame.gameObject.SetActive(!m_MenuInGame.gameObject.activeSelf);
        LoadingLevels.PausedGame();
    }
}
