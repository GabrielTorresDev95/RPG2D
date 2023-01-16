using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private ScriptPlayer player;
    private Animator anim;

    void Start()
    {

        player = GetComponent<ScriptPlayer>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        onMove();
        onRun();
    }

    #region Movement

    void onMove()
    {

        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
                    
            }
            else
            {       
                anim.SetInteger("transition", 1);
            }


        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }
        if(player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }
        if(player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }



    void onRun()
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
