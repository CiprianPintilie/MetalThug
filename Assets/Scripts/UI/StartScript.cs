using UnityEngine;

public class StartScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return))
	    {
	        GameObject.FindWithTag("Player").GetComponent<PlayerControlsScript>().enabled = true;
            gameObject.SetActive(false);
	    }
	}
}
