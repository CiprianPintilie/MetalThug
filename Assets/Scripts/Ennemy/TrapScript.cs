using UnityEngine;

public class TrapScript : MonoBehaviour
{

    public float Damage;
    public float Interval;

    private float _timer;
    private PlayerHealthScript _playerHealthScript;

    // Use this for initialization
    void Start()
    {
        _playerHealthScript = GameObject.FindWithTag("Player").GetComponent<PlayerHealthScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player") && _timer >= Interval)
        {
            _playerHealthScript.TakeDamage(Damage);
            _timer = 0;
        }
    }
}
