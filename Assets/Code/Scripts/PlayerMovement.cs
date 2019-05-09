using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed = 150;
    [SerializeField]
    private float RunSpeed = 250;

    [SerializeField]
    private Sprite _playerLeft, _playerDown, _playerUp;

    private Vector3 _movement;
    private float _currentSpeed;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _sr;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentSpeed = Speed;
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();

        _sr.sprite = _playerDown;
    }

    void Update()
    {


        _movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        _movement.Normalize();
        if(_movement != Vector3.zero)
        {
            UpdateSpriteDependingOnDirection();

        }
        _currentSpeed = Input.GetButton("Run") ? RunSpeed : Speed;
        

        _animator.SetFloat("Speed",_movement.magnitude);
        _rb.velocity = _movement*Time.deltaTime*_currentSpeed;
       




    }

    void UpdateSpriteDependingOnDirection()
    {
        Vector3 dir = _movement;
        _sr.flipX = false;

        if (dir.x > 0.1f)
        {
            _sr.sprite = _playerLeft;
            _sr.flipX = true;
        }
        else if(dir.x < -0.1f)
        {
            _sr.sprite = _playerLeft;
            _sr.flipX = false;
        }
        else if(dir.y > 0.1f)
        {
            _sr.sprite = _playerUp;
         
        }
        else if(dir.y < -0.1f)
        {
            _sr.sprite = _playerDown;
           
        }


    }
}
