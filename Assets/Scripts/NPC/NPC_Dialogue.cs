using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    bool playerHit;
    public DialogueSet dialogue;

    private List<string> sentences = new List<string>();


    void Start()
    {
        NPCinfo();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialoguesControl.instance.Speech(sentences.ToArray());
        }
       
        
    }


    void NPCinfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }
 
    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit= true;
        }
        else
        {
            playerHit= false;
 
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

}
