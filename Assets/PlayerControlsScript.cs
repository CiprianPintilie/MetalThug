using UnityEngine;

public class PlayerControlsScript : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public float FallForce;
    public GameObject[] Weapons;
    public int CurrentWeapon;

    private Transform _playerTransform;
    private Rigidbody2D _playerRigidBody;
    private bool _isGrounded;
    private bool _jumpOrder;
    private bool _shootOrder;
    private GameObject _barrel;
    private Animator _playerAnimator;

    // Use this for initialization
    void Start()
    {
        _playerTransform = gameObject.transform;
        _playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        _barrel = gameObject.transform.GetChild(0).gameObject;
        _isGrounded = true;
        _playerAnimator = gameObject.GetComponent<Animator>();
        CurrentWeapon = 0;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
            _jumpOrder = true;
        if (Input.GetButtonDown("Fire1"))
            _shootOrder = true;
        if (Input.GetButtonUp("Fire1"))
            _shootOrder = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerTransform.Translate(_playerTransform.right * Input.GetAxis("Horizontal") * Speed);
        if (_shootOrder)
        {
            Instantiate(Weapons[CurrentWeapon], _barrel.transform.position, _barrel.transform.rotation);
        }
        if (_jumpOrder)
        {
            _playerRigidBody.velocity += Vector2.up * JumpForce;
            _jumpOrder = false;
        }
        if (_playerRigidBody.velocity.y < 0 && !_isGrounded)
            _playerRigidBody.velocity += Vector2.up * Physics.gravity.y * FallForce;
        SetAnimationState();
    }

    private void SetAnimationState()
    {
        //TODO: Standing shooting animation and barrel reposition + bullet direction when turn around

        if (!_isGrounded && _playerAnimator.GetInteger("State") > 0)
            _playerAnimator.SetInteger("State", 3);
        else if (!_isGrounded && _playerAnimator.GetInteger("State") < 0)
            _playerAnimator.SetInteger("State", -3);
        else if (Input.GetAxis("Horizontal") > 0)
            _playerAnimator.SetInteger("State", 2);
        else if (Input.GetAxis("Horizontal") < 0)
            _playerAnimator.SetInteger("State", -2);
        else if (Input.GetAxis("Horizontal") == 0 && _playerAnimator.GetInteger("State") > 0)
            _playerAnimator.SetInteger("State", 1);
        else if (Input.GetAxis("Horizontal") == 0 && _playerAnimator.GetInteger("State") < 0)
            _playerAnimator.SetInteger("State", -1);
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
