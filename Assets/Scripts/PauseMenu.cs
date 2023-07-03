using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject canvasPause;


    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        canvasPause.SetActive(false);      
        Time.timeScale =1f;
        isPaused= false;
    }
    public void Pause()
    {
        canvasPause.SetActive(true);   
        Time.timeScale = 0f;
        isPaused= true;
    }
    public void GoMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        FindObjectOfType<ChangeChar>().ResetChar();
        SceneManager.LoadScene("MainMenu");
        
    }
}
