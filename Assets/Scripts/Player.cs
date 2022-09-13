using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    private float initialSpeed;
    private bool _isRunning;
    private bool _isCutting;
    private bool _isRolling;
    private bool _isDigging;
    private bool _isWatering;

    private Rigidbody2D rig;
    private Vector2 _direction;
    private PlayerItems playerItems;

    private int handlingObject;

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

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }

    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }

    public int HandlingObject { get => handlingObject; set => handlingObject = value; }
    public bool IsPaused { get => isPaused; set => isPaused = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();

        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                HandlingObject = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                HandlingObject = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                HandlingObject = 2;
            }

            onInput();

            OnRun();

            OnRolling();

            OnCutting();

            OnDig();

            OnWatering();
        }
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
    }

    #region Movement
    private void OnWatering()
    {
        if (HandlingObject == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.CurrentWater > 0)
            {
                _isWatering = true;

                speed = 0;
            }

            if (Input.GetMouseButtonUp(0) || playerItems.CurrentWater < 0)
            {
                _isWatering = false;

                speed = initialSpeed;
            }

            if (_isWatering)
            {
                playerItems.CurrentWater -= 0.01f;
            }
        }
        else
        {
            _isWatering = false;
        }
    }

    private void OnDig()
    {
        if (HandlingObject == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDigging = true;

                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDigging = false;

                speed = initialSpeed;
            }
        }
        else
        {
            _isDigging = false;
        }
    }

    private void OnCutting()
    {
        if (HandlingObject == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isCutting = true;

                speed = 0;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCutting = false;

                speed = initialSpeed;
            }
        }
        else
        {
            _isCutting = false;
        }
    }

    private void onInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        _direction = new Vector2(x, y);
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            isRunning = false;
        }
    }

    private void OnRolling()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }
    #endregion
}
