using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour {

    public float MaxHealth;
    public float CurrentHealth;
    public GameObject LifeBar;

    private LifeBarScript _lifeBarScript;

    // Use this for initialization
    void Start ()
    {
        CurrentHealth = MaxHealth;
        _lifeBarScript = LifeBar.GetComponent<LifeBarScript>();
    }
	
	// Update is called once per frame
	void Update () {
		_lifeBarScript.SetLife(CurrentHealth / MaxHealth);

	    if (CurrentHealth <= 0)
            Destroy(gameObject);
	}
}
