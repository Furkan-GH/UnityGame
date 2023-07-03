using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject tutorial;


    


    public void Play_btn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit_btn()
    {
        Application.Quit();
    }
    public void Tutorial_btn()
    {
        main.SetActive(false);
        tutorial.SetActive(true);

        

    }
    public void HighScores_btn()
    {

        
        


    }
    public void Return_menu()
    {

        tutorial.SetActive(false);
        main.SetActive(true);


        TutorialText.thisText.text = "" +
            "HI, LOVELY 4SOUL PLAYERS\r\n\r\nLET'S HOW TO PLAY 4SOUL\r\nIT'S EASY. YOU CAN RUN FOREVER\r\n\r\nYOU HAVE 4 SOUL AND YOU CAN TURN INTO EACH SOUL WHENEVER YOU WANT\r\nOF COURSE, TIMING IS IMPORTANT\r\nACCORDÝNG TO OBSTACLES, YOU HAVE TO CHOOSE SOUL AND TURN INTO\r\n\r\nEVERY SOUL HAS A DIFFERENT POWER. \r\nWHEN YOU PLAY, YOU LEARN THEM \r\n\r\nNOW YOU KNOW, LET'S PLAY                 ENJOY GAMING";

    }

    
}
