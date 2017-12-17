using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
	        GameObject.FindWithTag("Player").GetComponent<PlayerControlsScript>().enabled = true;
            gameObject.SetActive(false);
	    }
	}
}
