using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class scoreScript : MonoBehaviour
{
    public int score;
    public Text MyText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreText = GameObject.Find("scoreText");
        GameManager.Instance.UpdateScore(score);
        MyText.text = "Score: " + GameManager.Instance.score.ToString();

    }
}