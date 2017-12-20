using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyNoFollow : MonoBehaviour {

    public float Speed;
    public bool randomMove;
    public int DirectionX;
    public int DirectionY;

    private Transform _enemyTransform;
    private Animator _enemyAnimator;

    public bool canGoHorizontal;
    public bool canGoVertical;

    public float RangeMove;
    public Vector2 INITposition;

    public float minX;
    public float minY;

    public float maxX;
    public float maxY;

    // Use this for initialization
    void Start () {
        DirectionX = -1;
        DirectionY = -1;

        INITposition = gameObject.transform.position;

        minX = INITposition.x - RangeMove;
        minY = INITposition.y - RangeMove;

        maxX = INITposition.x + RangeMove;
        maxY = INITposition.y + RangeMove;
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
        if (randomMove)
        {
            canGoHorizontal = randomBoolean();
            canGoVertical = randomBoolean();
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
        if (canGoHorizontal)
        {
            gameObject.transform.Translate(gameObject.transform.right * Speed * DirectionX * Time.deltaTime);
        }
        if(canGoVertical)
        {
            gameObject.transform.Translate(gameObject.transform.up * Speed * DirectionY * Time.deltaTime);
        }

    }

    private void SetDirection()
    {
        if (canGoHorizontal)
        {
            if(gameObject.transform.position.x < minX + 1 || gameObject.transform.position.x > maxX)
            {
                DirectionX *= -1;
            }

        }

        if (canGoVertical)
        {
            if (gameObject.transform.position.y < minY + 1 || gameObject.transform.position.y > maxY - 1)
            {
                DirectionY *= -1;
            }
        }

        if(DirectionX < 0)
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
        DirectionX *= -1;
        DirectionY *= -1;
    }
}
