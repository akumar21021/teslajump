using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public float highScore;
    
    public static HighScore Instance;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        highScore = Mathf.Clamp(highScore, transform.position.y, highScore);
        highScore = Convert.ToInt32(highScore);
    }
    
}
