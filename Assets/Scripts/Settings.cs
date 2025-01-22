using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    public void displaySettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void returnToGame()
    {
        settingsMenu.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

}
