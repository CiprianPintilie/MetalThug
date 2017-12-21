using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public float DropRate;
    public float HealthAmount;
    public float ScorePoints;

    private PlayerHealthScript _playerHealthScript;
    private PlayerControlsScript _playerControlsScript;
    private GameObject _score;
    private bool _triggered;

    void Start()
    {
        var playerGameObject = GameObject.FindWithTag("Player");
        _playerHealthScript = playerGameObject.GetComponent<PlayerHealthScript>();
        _playerControlsScript = playerGameObject.GetComponent<PlayerControlsScript>();
        _score = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player") && !_triggered)
        {
            switch (gameObject.tag)
            {
                case "Bonus_health":
                    if (_playerHealthScript.MaxHealth - _playerHealthScript.CurrentHealth <= 0)
                        AddScore();
                    else if (_playerHealthScript.MaxHealth - _playerHealthScript.CurrentHealth <= HealthAmount)
                        _playerHealthScript.CurrentHealth = _playerHealthScript.MaxHealth;
                    else
                        _playerHealthScript.CurrentHealth += HealthAmount;
                    break;
                case "Bonus_weapon":
                    if (_playerControlsScript.CurrentWeapon + 1 < _playerControlsScript.Weapons.Length)
                        _playerControlsScript.ChangeWeapon(_playerControlsScript.CurrentWeapon + 1);
                    AddScore();
                    break;
                case "Bonus_score":
                    AddScore();
                    break;      
            }
            //Prevent collider to trigger twice sometimes since player have two colliders
            _triggered = true;
            Destroy(gameObject);
        }
    }

    private void AddScore()
    {
        _score.GetComponent<Text>().text = int.Parse(_score.GetComponent<Text>().text) + ScorePoints + "";
    }
}
