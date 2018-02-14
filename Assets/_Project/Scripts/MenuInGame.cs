using UnityEngine;

public class MenuInGame : MonoBehaviour {

    public Canvas m_MenuInGame;
    public Canvas m_MenuDeath;


    private void Update()
    {
        CharacterControlerGames character = FindObjectOfType<CharacterControlerGames>();
        if ( character != null )
        {
            if (CharacterControlerGames.PlayerInput.GetButtonDown("Pause"))
                Paused();
            if (CharacterControlerGames.PlayerInput.GetButtonDown("Cancel") && m_MenuInGame.gameObject.activeSelf)
                Paused();
        }
        else
        {
            DeathMenu();
        }
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
