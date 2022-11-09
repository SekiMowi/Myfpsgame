using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    //Variables
    public TextMeshProUGUI killsText;
    public TextMeshProUGUI timeText;
    private TimeSpan timePlaying;//timespan for end time

    public int kills;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        kills = KillManager.kills;
        time = Timer.time;
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
    void Update()
    {
        //Shows kills on end screen
        killsText.text = "Kills: " + kills;
        //Makes cursor visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator UpdateTimer()
    {
        timePlaying = TimeSpan.FromSeconds(time);//Gives time to TimeSpan
        string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss");//Formats the time to readable time
        timeText.text = timePlayingStr;//shows time on end screen
        yield return null;
    }
}
