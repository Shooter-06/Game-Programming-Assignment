using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthScript : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth= MaxHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth-= amount;

        if(currentHealth<=0)
        {
            Debug.Log("The player died");
            currentHealth= MaxHealth;
            SceneManager.LoadScene(1);
        }
    }
}
