using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSec : MonoBehaviour
{
    [SerializeField] private bool detectingPlayer;
    [SerializeField] private int waterValue;
    private PlayerItens player;


    private void Start()
    {
        player = FindObjectOfType<PlayerItens>();    
    }
    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.F))
        {
            player.WaterLimit(waterValue);
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
              detectingPlayer = false;
        }
    }
}
