using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{

    public float MaxHealth;
    public float CurrentHealth;

    private bool _hit;
    private float _timeUnhit;
    private Renderer _enemyRenderer;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        _enemyRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUnhit += Time.deltaTime;
        if (_hit && _timeUnhit >= 0.15)
        {
            _enemyRenderer.material.color = Color.white;
            _hit = false;
        }

        if (CurrentHealth <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        _enemyRenderer.material.color = Color.yellow;
        _hit = true;
        _timeUnhit = 0;
    }
}
