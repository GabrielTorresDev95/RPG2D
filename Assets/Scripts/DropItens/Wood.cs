using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;


    private float timeCount;


    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    //colisao para identificar se a tag player quando ela derrubara a arvore o get component sera chamado de outro script para idenficar que a madeira apareceu e eo destroy some ao player passar em cima dele.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerItens>().totalWood++;
            Destroy(gameObject);

        }
    }
}
