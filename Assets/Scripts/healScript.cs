using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healScript : MonoBehaviour
{

    public float health;

    public void Start()
    {
        health = 25;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealthScript>().gainHealth(health);
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }

    }
}