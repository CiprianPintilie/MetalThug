using System;
using UnityEngine;

public class PlayerControlsScript : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public float FallForce;

    private Transform _playerTransform;
    private Rigidbody2D _playerRigidBody;
    private bool _isGrounded;
    private bool _jumpOrder;

    // Use this for initialization
    void Start()
    {
        _playerTransform = gameObject.transform;
        _playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        _isGrounded = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
            _jumpOrder = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Horizontal"))
        {
            _playerTransform.Translate(_playerTransform.right * Input.GetAxis("Horizontal") * Speed);
        }
        if (_jumpOrder)
        {
            _playerRigidBody.velocity += Vector2.up * JumpForce;
            _jumpOrder = false;
        }
        if (_playerRigidBody.velocity.y < 0 && !_isGrounded)
        {
            _playerRigidBody.velocity += Vector2.up * Physics.gravity.y * FallForce;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        //if (!collider.tag.Equals("Spawn1") && !collider.tag.Equals("Spawn2"))
        _isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if (!collider.tag.Equals("Spawn1") && !collider.tag.Equals("Spawn2"))
        _isGrounded = true;
    }
}
