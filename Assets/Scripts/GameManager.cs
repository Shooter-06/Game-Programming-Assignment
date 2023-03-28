using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int score;
    public Text MyText;

    public static GameManager Instance {
        get {
            if(instance==null) {
                instance = new GameManager();
            }
 
            return instance;
        }
    }
    
    void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    void Start()
    {
        // Grab the score gameobject and get the Text component on that game object.
        GameObject.FindGameObjectsWithTag("scoreTag");
        MyText.text = "";
    }
 
    public void UpdateScore(int scoreCheck)
    {
        score =+ score ;
        MyText.text = "Score: " + score;
        
    }

    // public void LoadLastScene()
    // {
    //     PlayerPrefs.SetInt("FinalScore", score);
    //     SceneManager.LoadScene("LastScene");
    // }

    public void ResetLevel()
    {
        score = 0;
        SceneManager.LoadScene(1);
    }

    // private void UpdateFinalScoreText()
    // {
    //     int finalScore = PlayerPrefs.GetInt("FinalScore");
    //     MyText.text = "Final Score: " + finalScore.ToString();
    // }
}
