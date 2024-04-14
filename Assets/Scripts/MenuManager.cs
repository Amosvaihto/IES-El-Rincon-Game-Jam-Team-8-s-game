using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Settings ()
    {
        
        SceneManager.LoadScene("Asetukset", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    public void Continue() 
    {
        SceneManager.LoadScene("Continue");
    }

}
