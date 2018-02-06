using UnityEngine;
using Rewired;

public class PauseMenu : MonoBehaviour {

    public Canvas m_MenuInGame;
    public Canvas m_MenuDeath;

    public static bool IsPaused = false;


    private void Update()
    {
        CharacterControlerGames character = FindObjectOfType<CharacterControlerGames>();
        if ( character != null )
        {
            Player input = CharacterControlerGames.PlayerInput;
            if (input.GetButtonDown("Pause"))
                Paused();
            if (input.GetButtonDown("Cancel") && m_MenuInGame.gameObject.activeSelf)
                Paused();
        }
        else
        {
            DeathMenu();
        }

        IsPaused = m_MenuInGame.gameObject.activeSelf;
    }


    private void Paused()
    {
        m_MenuInGame.gameObject.SetActive(!m_MenuInGame.gameObject.activeSelf);
        LoadingLevels.PausedGame();
    }

    private void DeathMenu()
    {
        if ( !m_MenuDeath.gameObject.activeSelf )
        {
            m_MenuDeath.gameObject.SetActive(!m_MenuDeath.gameObject.activeSelf);
            LoadingLevels.PausedGame();
        }
    }
}
