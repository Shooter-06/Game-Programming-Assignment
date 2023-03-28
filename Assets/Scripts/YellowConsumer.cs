using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class YellowConsumer : MonoBehaviour
{
    Vector3 rotationAxis;
    float rotationSpeed;
    AnimationCurve curve;

    private int scoreGain = 50;

    Vector3 intialPosition;

    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        intialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

        transform.position = intialPosition + curve.Evaluate((Time.time % 2 ) * 0.5f) * Vector3.up * 0.2f; 
      
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            if(GameManager.Instance != null)
            {
                GameManager.Instance.score += scoreGain;
                GameManager.Instance.UpdateScore(50);
            }

            Destroy(gameObject);
        }
    }
}


