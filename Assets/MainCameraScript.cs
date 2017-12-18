using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{

    public float CameraSpeed;
    
    private Transform _playerTransform;

	// Use this for initialization
	void Start ()
	{
	    _playerTransform = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.localPosition.x < _playerTransform.position.x && Input.GetAxis("Horizontal") > 0)
	        transform.Translate(transform.right * Time.deltaTime * CameraSpeed);
	}
}
