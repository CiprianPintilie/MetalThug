﻿using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public float Damage;
    public int Direction;

    private Transform _bulletTransform;

	// Use this for initialization
	void Start ()
	{
	    _bulletTransform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		_bulletTransform.Translate(_bulletTransform.right * Speed * Direction * Time.deltaTime);
	}
}