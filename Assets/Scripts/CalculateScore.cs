using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CalculateScore : MonoBehaviour
{

    private int scoreValue = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D pass)
    {
        if (pass.gameObject.tag == "Player")
        {
            
            GameManager.instance.ChangeScore(scoreValue);
            
        }
    }
}
