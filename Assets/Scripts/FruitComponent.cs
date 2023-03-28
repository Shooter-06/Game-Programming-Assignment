using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitComponent : MonoBehaviour
{
    private int scoreGain = 20;
    
    //onCollition enter to check when the player hits the robot
    void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.tag == "Player")
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.score += scoreGain;
                GameManager.Instance.UpdateScore(scoreGain);
            }

            Destroy(gameObject);
        }
    }
}
