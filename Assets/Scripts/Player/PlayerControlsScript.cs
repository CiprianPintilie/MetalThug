using UnityEngine;

public class PlayerControlsScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float FallForce;
    public GameObject[] Weapons;
    public int CurrentWeapon;

    private float _attackSpeed;
    private float _attackTimer;
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
        _attackTimer = 0;
        _playerTransform = gameObject.transform;
        _playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        _barrel = gameObject.transform.GetChild(0).gameObject;
        _isGrounded = true;
        _playerAnimator = gameObject.GetComponent<Animator>();
        CurrentWeapon = 0;
        ChangeAttackSpeed();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
            _jumpOrder = true;
        if (Input.GetButtonDown("Fire1"))
            _shootOrder = true;
        if (Input.GetButtonUp("Fire1"))
            _shootOrder = false;
        _attackTimer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _playerTransform.Translate(_playerTransform.right * Input.GetAxis("Horizontal") * Speed);
        if (_shootOrder && _attackTimer >= _attackSpeed)
        {
            var direction = GetDirection();
            var bullet = Instantiate(Weapons[CurrentWeapon], _barrel.transform.position, _barrel.transform.rotation);
            if (direction < 0)
                bullet.transform.Rotate(0, 0, 180);
            bullet.GetComponent<BulletScript>().Direction = direction;
            _attackTimer = 0;
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

    public void ChangeWeapon(int weaponIndex)
    {
        CurrentWeapon = weaponIndex;
        ChangeAttackSpeed();
    }

    private void ChangeAttackSpeed()
    {
        _attackSpeed = Weapons[CurrentWeapon].GetComponent<BulletScript>().AttackSpeed;
    }

    private int GetDirection()
    {
        if (_playerAnimator.GetInteger("State") < 0)
            return -1;
        return 1;
    }

    private void SetAnimationState()
    {
        //Jumping
        if (!_isGrounded && Input.GetAxis("Horizontal") > 0 || !_isGrounded && _playerAnimator.GetInteger("State") > 0)
        {
            if (_barrel.transform.localPosition.x < 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", 3);
        }
        else if (!_isGrounded && Input.GetAxis("Horizontal") < 0 || !_isGrounded && _playerAnimator.GetInteger("State") < 0)
        {
            if (_barrel.transform.localPosition.x > 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", -3);
        }
        //Standing shooting
        else if (_shootOrder && _playerAnimator.GetInteger("State") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            if (_barrel.transform.localPosition.x < 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", 4);
        }
        else if (_shootOrder && _playerAnimator.GetInteger("State") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            if (_barrel.transform.localPosition.x > 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", -4);
        }
        //Running
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (_barrel.transform.localPosition.x < 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", 2);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (_barrel.transform.localPosition.x > 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", -2);
        }
        //Standing
        else if (Input.GetAxis("Horizontal") == 0 && _playerAnimator.GetInteger("State") > 0)
        {
            if (_barrel.transform.localPosition.x < 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", 1);
        }
        else if (Input.GetAxis("Horizontal") == 0 && _playerAnimator.GetInteger("State") < 0)
        {
            if (_barrel.transform.localPosition.x > 0)
                _barrel.transform.localPosition = new Vector3(_barrel.transform.localPosition.x * -1, _barrel.transform.localPosition.y);
            _playerAnimator.SetInteger("State", -1);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        _isGrounded = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Equals("Platform"))
            _isGrounded = true;
    }
}
