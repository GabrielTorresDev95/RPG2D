using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialoguesControl : MonoBehaviour
{

    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spn
    }




    [Header("Components")]

    public GameObject dialogObject; // Janela do Dialogo
    public Image profileSprite; // sprite do perfil
    public TextMeshProUGUI speechText;// texto da fala 
    public Text actorNameText; //nome do npc

    [Header("Settings")]

    public float typingspeed;//velocidade da fala
    public int index; //index das sentensas ou falas
    public bool isShowing;//Se a janela esa visivel
    
    private string[] sentences;



    public static DialoguesControl instance;

    //Awake é chamao antes de todos os starts() na hierarquia de execução de scripts
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentences()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }

    }

    public void NextSentence() 
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentences());
            }

            else
            {
                speechText.text = "";
                index = 0;
                dialogObject.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if(!isShowing) 
        {
            dialogObject.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentences());
            isShowing = true;
        }
    }
}
