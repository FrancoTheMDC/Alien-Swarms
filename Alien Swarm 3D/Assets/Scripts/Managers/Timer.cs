using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public int timer = 0;

    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine("timeLapse");
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = "" + timer;

        if (timer <= 0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
            timer = 0;
        }
    }

    IEnumerator timeLapse()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            timer--;
        }
    }

    public void nextGame1()
    {
        SceneManager.LoadScene("Level 02");
    }

    public void nextGame2()
    {
        SceneManager.LoadScene("Level 03");
    }
}
