using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    //Play Button
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        KillManager.kills = 0;
    }
    //Exit Button
    public void ExitGame()
    {
        Application.Quit();
        
    }
    //Controls Button
    public void Controls()
    {
        SceneManager.LoadScene(3);
    }
}
