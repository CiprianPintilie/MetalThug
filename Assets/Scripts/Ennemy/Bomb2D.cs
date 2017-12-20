using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberScript : MonoBehaviour
{

    public GameObject bomb;
    public float radius = 5f;
    public float upforce = 7f;
    public float power = 20f;


    // Use this for initialization
    void Start()
    {
        Vector2 ExplosionPosition = bomb.transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ExplosionPosition, radius);
        foreach (Collider2D hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, ExplosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}