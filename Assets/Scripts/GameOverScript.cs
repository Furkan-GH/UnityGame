using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOverScript : MonoBehaviour
{

    //public GameObject canvasGO;

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        score.text = "Score: " + GameManager.currentScore.ToString();






    }
    public void Restart_btn()
    {
        FindObjectOfType<ChangeChar>().ResetChar();
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu_btn()
    {
        FindObjectOfType<ChangeChar>().ResetChar();
        SceneManager.LoadScene("MainMenu");
    }
}
