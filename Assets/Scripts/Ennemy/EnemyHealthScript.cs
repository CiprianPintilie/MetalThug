using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyHealthScript : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    public int Points;
    public GameObject[] DropBonuses;
    public GameObject DeathExplosion;

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

        if (CurrentHealth <= 0 || transform.position.y < -20)
            Die();
    }

    private void Die()
    {
        _score.GetComponent<Text>().text = int.Parse(_score.GetComponent<Text>().text) + Points + "";
        for (int i = 0; i < DropBonuses.Length; i++)
        {
            //Allways initialise a new one because of randomness problems
            var rnd = new Random();
            var bonusDropRate = DropBonuses[i].GetComponent<ItemScript>().DropRate;
            var randomValue = rnd.Next(0, 100);
            if (bonusDropRate >= randomValue)
                Instantiate(DropBonuses[i], gameObject.transform.position, gameObject.transform.rotation);
        }
        Instantiate(DeathExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        gameObject.GetComponent<AudioSource>().Play();
        CurrentHealth -= damage;
        _enemyRenderer.material.color = Color.red;
        _hit = true;
        _timeUnhit = 0;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (!collider.gameObject.tag.Equals("Player")) return;
        collider.gameObject.GetComponent<PlayerHealthScript>().TakeDamage(MaxHealth);
        Destroy(gameObject);
    }
}
