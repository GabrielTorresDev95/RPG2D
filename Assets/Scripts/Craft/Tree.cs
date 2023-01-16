using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treehealth;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
    [SerializeField] private ParticleSystem leafs;
    private bool Iscut;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void Onhitter()
    {
        treehealth --;
        leafs.Play();
        anim.SetTrigger("Ishit");

        if(treehealth <= 0)
        {
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f ), 0f), transform.rotation);
            }

            anim.SetTrigger("cut");

            Iscut = true;
        }


    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("axe_collider") && !Iscut)
        {
            
            Onhitter();
        }
    }
}
