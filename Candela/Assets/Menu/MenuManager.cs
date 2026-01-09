using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu")]
    public string gameScene;

    [Header("Sound Settings")]
    public Image soundIcon;
    public Sprite muteButton;
    public Sprite unmuteButton;
    bool isMuted = false;
    public void Mute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            soundIcon.sprite = unmuteButton;
        }
        else
        {
            soundIcon.sprite = muteButton;
        }            
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
