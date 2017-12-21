using System;
using UnityEngine;

public class BomberEnemyScript : MonoBehaviour
{

    public float Speed;
    public GameObject Bomb;

    private GameObject _barrel;
    private Transform _playerTransform;
    private bool _bombDropped;
    private Renderer _enemyRenderer;

    // Use this for initialization
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _barrel = gameObject.transform.GetChild(0).gameObject;
        _enemyRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemyRenderer.isVisible && transform.position.x + 20 > _playerTransform.position.x)
            Destroy(gameObject, 1);

        transform.Translate(transform.right * Speed * Time.deltaTime);
        if (_playerTransform != null && !_bombDropped)
        {
            if (Math.Abs(transform.position.x - _playerTransform.position.x) < 0.5)
            {
                Instantiate(Bomb, _barrel.transform.position, _barrel.transform.rotation);
                _bombDropped = true;
            }
        }
    }
}
