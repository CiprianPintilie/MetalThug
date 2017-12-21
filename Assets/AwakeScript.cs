using UnityEngine;

public class AwakeScript : MonoBehaviour
{
    public MonoBehaviour[] ScriptsToActivate;

    private Renderer _renderer;

    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
    }

	// Update is called once per frame
	void Update () {
	    if (_renderer.isVisible)
	    {
	        for (int i = 0; i < ScriptsToActivate.Length; i++)
	        {
            
            }
	    }
	}
}
