using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class BlueCoins : MonoBehaviour
{
    // private int scoreGain = 0;

    // //oncollition enter to check when the player hits the robot
    // void OnCollisionEnter(Collision collision)
    // {
    //     if( collision.gameObject.tag == "Player")
    //     {
    //         if(GameManager.Instance != null)
    //         {
    //             GameManager.Instance.score += scoreGain;
    //             GameManager.Instance.UpdateScore(0);
    //         }

    //         Destroy(gameObject);
    //     }
    // }

     Vector3 rotationAxis;
    float rotationSpeed;
    AnimationCurve curve;

    private int scoreGain = 10;

    Vector3 intialPosition;

    public int score;
    public Text MyText;
    // Start is called before the first frame update
    void Start()
    {
        intialPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.score += scoreGain;
                GameManager.Instance.UpdateScore(10);
            }

            Destroy(gameObject);
        }
    }
}