using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject playChoosePanel;
    public GameObject MenuPanel;
    public GameObject aboutPanel;

    void Start()
    {
        playChoosePanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    public void playGame()
    {
        playChoosePanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void about()
    {
        aboutPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void level1Game()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void level2Game()
    {
        SceneManager.LoadScene("Level 02");
    }

    public void level3Game()
    {
        SceneManager.LoadScene("Level 03");
    }
    public void backToMain()
    {
        MenuPanel.SetActive(true);
        playChoosePanel.SetActive(false);
        aboutPanel.SetActive(false);
    }
}
