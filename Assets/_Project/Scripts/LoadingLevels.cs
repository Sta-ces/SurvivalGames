using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevels : MonoBehaviour {

    public void Restart()
    {
        LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void LoadLevel(string _nameLevel)
    {
        LoadLevel(SceneManager.GetSceneByName(_nameLevel).buildIndex);
    }

    public void LoadLevel(int _idLevel)
    {
        LevelLoader(_idLevel);
    }

    public static void LevelLoader(int _idLevel)
    {
        SceneManager.LoadScene(_idLevel);
    }

    public void QuitApplication()
    {
        ApplicationQuit();
    }

    public static void ApplicationQuit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        PausedGame();
    }

    public static void PausedGame()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
    }
}
