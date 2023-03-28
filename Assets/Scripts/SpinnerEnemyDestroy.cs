using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerEnemyDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        if(collision.tag == "Player")
        {
            if(GameManager.Instance != null){
                GameManager.Instance.ResetLevel();  
            }  
        }
    }
}