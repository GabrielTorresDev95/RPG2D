using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class NPC : MonoBehaviour
{
    public float speed;
    private int index;
    private Vector2 target;
    private Vector2 position;
    private float initialSpeed;
    private Animator anim;


    public List<Transform> paths = new  List<Transform>();

    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }
    void Update()

    {

        if(DialoguesControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("IsWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("IsWalking", true);
        }

        //moveTowards ela é utilizada para direção atual e a direção para onde ele vai.
        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, paths[index].position) < 0.1f)
        {
            if (index < paths.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;

        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }
}
