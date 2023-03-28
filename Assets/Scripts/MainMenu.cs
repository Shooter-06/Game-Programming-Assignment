using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        
    }
    // load the first screen
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void returntoTheMainMenu()
    {
        Debug.Log("MenuHit");
        SceneManager.LoadScene(0);

    }

    // load the end screen
    public void TryGame()
    {
        SceneManager.LoadScene(0);
    }

    //quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
