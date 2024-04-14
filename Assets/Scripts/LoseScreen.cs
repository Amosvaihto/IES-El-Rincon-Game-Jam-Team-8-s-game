using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
  
    public void Quit()
    {
        Application.Quit();
    }



}

