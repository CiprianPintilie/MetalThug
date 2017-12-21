using UnityEngine;

public class MovingEnnemyScript : MonoBehaviour
{
    public float Speed;
    public int Direction;

    private GameObject _objectToFollow;
    private Transform _enemyTransform;
    private Animator _enemyAnimator;
    private Renderer _enemyRenderer;
    private Transform _playerTransform;

    // Use this for initialization
    void Start ()
	{
	    _enemyTransform = gameObject.transform;
        _objectToFollow = GameObject.FindWithTag("Player");
	    _enemyAnimator = gameObject.GetComponent<Animator>();
	    _enemyRenderer = gameObject.GetComponent<Renderer>();
	    _playerTransform = GameObject.FindWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (_playerTransform != null && !_enemyRenderer.isVisible && transform.position.x > _playerTransform.position.x) return;
        SetDirection();
	    _enemyAnimator.SetInteger("State", Direction);
	    if (_objectToFollow != null && _objectToFollow.transform.localPosition.y < _enemyTransform.position.y + 2)
            _enemyTransform.Translate(_enemyTransform.right * Speed * Direction * Time.deltaTime);
    }

    private void SetDirection()
    {
        if (_objectToFollow != null && _objectToFollow.transform.localPosition.x > _enemyTransform.position.x)
            Direction = 1;
        else if (_objectToFollow != null && _objectToFollow.transform.localPosition.y > _enemyTransform.position.y + 2)
            Direction = 0;
        else
            Direction = -1;
    }
}
