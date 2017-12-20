using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{

    public float MaxHealth;
    public float CurrentHealth;
    public int Points;

    private bool _hit;
    private float _timeUnhit;
    private Renderer _enemyRenderer;
    private GameObject _score;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        _enemyRenderer = gameObject.GetComponent<Renderer>();
        _score = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
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
        {
            _score.GetComponent<Text>().text = int.Parse(_score.GetComponent<Text>().text) + Points + "";
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        _enemyRenderer.material.color = Color.red;
        _hit = true;
        _timeUnhit = 0;
        gameObject.GetComponent<AudioSource>().Play();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.tag.Equals("Player")) return;
        collider.gameObject.GetComponent<PlayerHealthScript>().TakeDamage(MaxHealth);
        Destroy(gameObject);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
