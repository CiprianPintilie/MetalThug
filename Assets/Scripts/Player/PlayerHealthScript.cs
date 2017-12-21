using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthScript : MonoBehaviour
{

    public float MaxHealth;
    public float CurrentHealth;
    public GameObject LifeBar;

    private bool _hit;
    private float _timeUnhit;
    private Renderer _playerRenderer;
    private LifeBarScript _lifeBarScript;

    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        _playerRenderer = gameObject.GetComponent<Renderer>();
        _lifeBarScript = LifeBar.GetComponent<LifeBarScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUnhit += Time.deltaTime;
        _lifeBarScript.SetLife(CurrentHealth / MaxHealth);
        if (_hit && _timeUnhit >= 0.15)
        {
            _playerRenderer.material.color = Color.white;
            _hit = false;
        }

        if (CurrentHealth <= 0 || transform.position.y < -20)
        {
            var canvasTransform = GameObject.Find("Canvas").transform;
            var gameOverPanel = canvasTransform.GetChild(4).gameObject;
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.GetChild(2).GetComponent<Text>().text = canvasTransform.GetChild(2).gameObject.GetComponent<Text>().text;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        _playerRenderer.material.color = Color.clear;
        _hit = true;
        _timeUnhit = 0;
    }
}
