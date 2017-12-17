using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    public float Damage;
    public int Direction;

    private Transform _bulletTransform;
    private Renderer _bulletRenderer;

	// Use this for initialization
	void Start ()
	{
	    _bulletTransform = gameObject.transform;
	    _bulletRenderer = gameObject.GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	void Update () {
		_bulletTransform.Translate(_bulletTransform.right * Speed * Direction * Time.deltaTime);

	    if (!_bulletRenderer.isVisible)
	        Destroy(gameObject, 0.5f);
	}
}
