using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TutorialText : MonoBehaviour
{

    public MenuScript MenuScript;


    [SerializeField] float delay = 0.05f;
    [Multiline] public string Tutorial_text;

    public static TextMeshProUGUI thisText;


    // Start is called before the first frame update
    void Start()
    {
        thisText = GetComponent<TextMeshProUGUI>();

        StartCoroutine(WriteText());

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WriteText()
    {
        thisText.text = "";

        foreach (char i in Tutorial_text) 
        {
            thisText.text += i.ToString();

            if (i.ToString() == ".") { yield return new WaitForSeconds(0.5f); }
            else if (i.ToString() == ",") { yield return new WaitForSeconds(0.2f); }
            else { yield return new WaitForSeconds(delay); }
        }
        
        
    }

    public static void BeZero()
    {
        thisText.text = string.Empty;
    }
    public void Skip_btn()
    {
        thisText.text = string.Empty;
        thisText.text = Tutorial_text.ToString();
        StopAllCoroutines();

    }
}
