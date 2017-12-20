using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            collider.gameObject.transform.position = gameObject.transform.Find("exitube").gameObject.transform.position;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
