using System.Collections;
using UnityEngine;

public class FlyingMovingEnnemyScript : MonoBehaviour {

    public float Speed;
    public bool RandomMove;
    
    public bool CanGoHorizontal;
    public bool CanGoVertical;
    public float RangeMove;

    private int _directionX;
    private int _directionY;
    private Vector2 _iniTposition;
    private float _minX;
    private float _minY;
    private float _maxX;
    private float _maxY;

    // Use this for initialization
    void Start()
    {
        _directionX = -1;
        _directionY = -1;

        _iniTposition = gameObject.transform.position;

        _minX = _iniTposition.x - RangeMove;
        _minY = _iniTposition.y - RangeMove;

        _maxX = _iniTposition.x + RangeMove;
        _maxY = _iniTposition.y + RangeMove;
        RandomMovement();
    }

    // Update is called once per frame
    void Update()
    {
        SetDirection();
        Move();
        Debug.Log(gameObject.transform.position);
    }

    IEnumerator RandomMovement()
    {
        if (RandomMove)
        {
            CanGoHorizontal = randomBoolean();
            CanGoVertical = randomBoolean();
        }

        yield return new WaitForSeconds(5);

        RandomMovement();
    }

    private bool randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }

    private void Move()
    {
        if (CanGoHorizontal)
        {
            gameObject.transform.Translate(gameObject.transform.right * Speed * _directionX * Time.deltaTime);
        }
        if (CanGoVertical)
        {
            gameObject.transform.Translate(gameObject.transform.up * Speed * _directionY * Time.deltaTime);
        }

    }

    private void SetDirection()
    {
        if (CanGoHorizontal)
        {
            if (gameObject.transform.position.x < _minX + 1 || gameObject.transform.position.x > _maxX)
            {
                _directionX *= -1;
            }

        }

        if (CanGoVertical)
        {
            if (gameObject.transform.position.y < _minY + 1 || gameObject.transform.position.y > _maxY - 1)
            {
                _directionY *= -1;
            }
        }

        if (_directionX < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _directionX *= -1;
        _directionY *= -1;
    }
}
