using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.1f;
    [SerializeField] Transform characterTransform;
    [SerializeField] Transform cameraTransform;
    [SerializeField] List<GameObject> obstacles;
    private GameObject previousObstacles;
    private GameObject currentObstacle;

    public static GameManager instance;

    
    public TextMeshProUGUI score;
    public static int currentScore= 0;
    
    public TextMeshProUGUI starting;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        GameManager.currentScore = 0;
    }
    
    private void Start()
    {
        StartCoroutine(CreateObstacle());

         
        
        //InvokeRepeating("CalculateScore", 1f,1f);

        
        StartCoroutine(StartGame());
    }
    private void Update()
    {
        if(currentScore > 300)
        {
            movementSpeed = 0.12f;
        }
        else if (currentScore > 500)
        {
            movementSpeed = 0.16f;
        }
        else if(currentScore > 700)
        {
            movementSpeed = 0.2f;
        }
    }

    void FixedUpdate()
    {
        cameraTransform.position = new Vector3(cameraTransform.position.x + movementSpeed, cameraTransform.position.y, cameraTransform.position.z);
        characterTransform.position = new Vector3(characterTransform.position.x + movementSpeed, characterTransform.position.y, characterTransform.position.z);
    }

    private IEnumerator CreateObstacle()
    {
        while (true)
        {
            currentObstacle = obstacles[Random.Range(0, obstacles.Count)];
            
            while (true)
            {
                if(currentObstacle == previousObstacles)
                {
                    currentObstacle = obstacles[Random.Range(0,obstacles.Count)];
                }
                if(currentObstacle != previousObstacles)
                {
                    break;
                }
            }
            currentObstacle.transform.position = new Vector3(cameraTransform.position.x + 40f, currentObstacle.transform.position.y, currentObstacle.transform.position.z);

            for (int i = 0; i < currentObstacle.transform.childCount; ++i)
            {
                currentObstacle.transform.GetChild(i).gameObject.SetActive(true);
                
            }
            previousObstacles = currentObstacle;    
            currentObstacle.gameObject.SetActive(true);
            yield return new WaitForSeconds(10f);
        }
    }
   

    public void ChangeScore(int value)
    {
        
        currentScore += value;
        score.text = currentScore.ToString();

    }
    
    private IEnumerator StartGame()
    {
        
        int i = 3;
        starting.text = "Be Soul";
        yield return new WaitForSeconds(1);
        while(i > 0f)
        {
            string string_i = i.ToString();  
            starting.text = string_i.ToString();
            i--;
            yield return new WaitForSeconds(1f);
            
        }
        starting.text = "Gooo!";
        yield return new WaitForSeconds(1);
        starting.gameObject.SetActive(false);
    }
}
