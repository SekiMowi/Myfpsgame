using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //variables
    public GameObject pauseMenu;

    public void Update()
    {
        //Shows pause menu if Esc is pressed
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
            Debug.Log("Pause");
        }
            
    }
    public void Pause()
    {
        //Hides cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    //Resume button
    public void Resume()
    {
        //Shows cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
    }
    //Mainmenu button
    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
