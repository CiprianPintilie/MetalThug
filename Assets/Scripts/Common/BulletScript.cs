using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float BulletSpeed;
    public float AttackSpeed;
    public float Damage;
    public int Direction;

    private Transform _bulletTransform;
    private Renderer _bulletRenderer;

    // Use this for initialization
    void Start()
    {
        _bulletTransform = gameObject.transform;
        _bulletRenderer = gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        _bulletTransform.Translate(_bulletTransform.right * BulletSpeed * Direction * Time.deltaTime);
        if (!_bulletRenderer.isVisible)
            Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player") && gameObject.tag.Equals("PlayerBullet")
            || collider.tag.Equals("Enemy") && gameObject.tag.Equals("EnemyBullet")
            || collider.tag.Equals("PlayerBullet") && gameObject.tag.Equals("EnemyBullet")
            || collider.tag.Equals("EnemyBullet") && gameObject.tag.Equals("PlayerBullet")
            || collider.tag.Equals("MainCamera")) return;
        if (collider.tag.Equals("Player") && gameObject.tag.Equals("EnemyBullet"))
        {
            var playerScript = collider.gameObject.GetComponent<PlayerHealthScript>();
            playerScript.TakeDamage(Damage);
        }
        if (collider.tag.Equals("Enemy") && gameObject.tag.Equals("PlayerBullet"))
        {
            var enemyScript = collider.gameObject.GetComponent<EnemyHealthScript>();
            enemyScript.TakeDamage(Damage);
        }
        Destroy(gameObject);
    }
}
