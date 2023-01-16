using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rig;
   
    private Vector2 _direction;
    private float initialSpeed;
    public float runSpeed;
    private bool _isRolling;
    private bool _isRunning;
    private bool _isCutting;
    public int handlinObj;
    public bool _isDiging;
    public bool _isWatering;

    //o get e o set a baixo me possibilita acessar essa variavel direction de outro script. 
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; } 
    }

    public bool isRunning 
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDigging
    {
        get { return _isDiging; }
        set { _isDiging = value; }
    }
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    private void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlinObj = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlinObj = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlinObj = 3;
        }



        OnInput();
        OnRun();
        onRolling();
        onCutting();
        OnDigging();
        OnWatering();


    }

    private void FixedUpdate()
    {
      
        OnMove();

    }


    #region Moviment
    void onCutting()
    {

        //handliobj lógica para identificação do teclado alpha para identificar qual método utilo
        if (handlinObj == 1)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                isCutting = true;
                speed = 0f;

            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
    }


    void OnDigging()
{
        if(handlinObj == 2)
        { 
            if (Input.GetKeyDown(KeyCode.F))
            {
                speed = runSpeed;
                _isDiging = true;
            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                speed = initialSpeed;
                _isDiging = false;
            }
        }
}
    void OnWatering()
    {
        if (handlinObj == 3)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {

                isWatering = true;
                speed = 0f;

            }
            if (Input.GetKeyUp(KeyCode.F))
            {
                isWatering = false;
                speed = initialSpeed;
            }
        }
    }



    //Método void para dar inicio a movimentação dos boneco pelo teclado AWSD OU setinhas: <-, /\, ->, \/
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
        
        void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }



    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }

        
    }

    void onRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRolling= true;
        }
        else
        {
            isRolling= false;
        }
    }





    #endregion
}

