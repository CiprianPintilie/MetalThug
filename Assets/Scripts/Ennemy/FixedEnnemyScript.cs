using UnityEngine;

public class FixedEnnemyScript : MonoBehaviour
{

    public GameObject Weapon;
    public int Direction;

    private float _attackSpeed;
    private float _attackTimer;
    private GameObject _barrel;
    private Renderer _enemyRenderer;

    // Use this for initialization
    void Start()
    {
        _attackSpeed = Weapon.GetComponent<BulletScript>().AttackSpeed;
        _attackTimer = 0;
        _barrel = gameObject.transform.GetChild(0).gameObject;
        _enemyRenderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemyRenderer.isVisible) return;
        _attackTimer += Time.deltaTime;
        if (_attackTimer >= _attackSpeed)
        {
            var bullet = Instantiate(Weapon, _barrel.transform.position, _barrel.transform.rotation);
            bullet.GetComponent<BulletScript>().Direction = Direction;
            _attackTimer = 0;
        }
    }
}
