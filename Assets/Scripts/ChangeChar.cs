using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ChangeChar : MonoBehaviour
{

    public GameObject[] characters; // karakterlerin listesi
    public static int activeCharacter = 0; // aktif karakterin indeksi
    private Vector3[] positions;     //karekterin konumunu tutan vektor


    ParticleSystem bomb;

    public GameObject gameOver;
    Canvas gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {

        gameOverCanvas = gameOver.GetComponent<Canvas>();

        bomb = GameObject.Find("Bomb").GetComponent<ParticleSystem>();
        bomb.Stop();

        positions = new Vector3[characters.Length]; 
        // karakterlerin pozisyonlarýný kaydet
        for (int i = 0; i < characters.Length; i++)
        {
            //characters[i].SetActive(false);//sonradan eklendi
            positions[i] = characters[i].transform.position;
        }
        characters[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOverCanvas.isActiveAndEnabled== false) 
        {



            if (Input.GetKeyDown(KeyCode.Q) && PauseMenu.isPaused == false)
            {
                ChangeCharacter(0);
            }
            else if (Input.GetKeyDown(KeyCode.W) && PauseMenu.isPaused == false)
            {
                ChangeCharacter(1);
            }
            else if (Input.GetKeyDown(KeyCode.E) && PauseMenu.isPaused == false)
            {
                ChangeCharacter(2);
            }
            else if (Input.GetKeyDown(KeyCode.R) && PauseMenu.isPaused == false)
            {
                ChangeCharacter(3);
            }
        }
    }



    void ChangeCharacter(int index)
    {
        // karekter deðiþtirme fonksiyonu
        if (index >= characters.Length || index < 0 || index == activeCharacter) // geçersiz indeks kontrolü
        {
            return;
        }
      // aktif karakterin pozisyonunu kaydet
        Vector3 activePos = characters[activeCharacter].transform.position;
        
        
        


        characters[index].transform.position = activePos;
        characters[activeCharacter].SetActive(false);
        characters[index].SetActive(true);



        activeCharacter = index; // yeni karakteri aktif hale getir
        bomb.transform.position = activePos;
        bomb.Play();
        

        
      }


   public void ResetChar()
    {
        activeCharacter = 0;    
    }





}
