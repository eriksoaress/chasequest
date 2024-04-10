using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D _playerRb;
    public float _playerSpeed;
    private Vector2 _playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {   
        _playerRb.MovePosition(_playerRb.position + _playerDirection * _playerSpeed * Time.fixedDeltaTime);
    }
}
