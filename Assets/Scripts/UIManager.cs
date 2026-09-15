using UnityEngine;
using UnityEngine.SceneManagement;

//<summary> This script handles UI Buttons! - Zander :3 <summary>
public class UIManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject creditsMenu;

    public void ChangeSceneButton(int sceneValue)
    {
        SceneManager.LoadScene(sceneValue); //sceneValue is handled within the Unity Editor
    }

    public void SwitchSettingsButton()
    {
        //This method can be used for both Settings button and return to Menu button
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void SwitchCreditsButton()
    {
        //This method can be used for both Credits button and return to Menu button
        creditsMenu.SetActive(!creditsMenu.activeSelf);
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }
}