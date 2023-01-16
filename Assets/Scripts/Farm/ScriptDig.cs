
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDig : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private Sprite dig;
    [SerializeField] private Sprite carrot;


    [SerializeField] private int digTime;

    private int initialDigTime;

    // Start is called before the first frame update
    private void Start()
    {
        initialDigTime = digTime;
    }



    public void Onhitt()
    {
        digTime--;
    
        if(digTime <= initialDigTime / 2)
        {
            spriteRender.sprite = dig;
        }
        if(digTime <= 0)
        {
           spriteRender.sprite = carrot;
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dig"))
        {

            Onhitt();
        }
    }
}
