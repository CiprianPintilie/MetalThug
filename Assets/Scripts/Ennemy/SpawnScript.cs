using UnityEngine;
using Random = System.Random;

public class SpawnScript : MonoBehaviour
{

    public int SpawnRate;
    public float RandomTimer;
    public GameObject EnemyToSpawn;

    private float _timer;

	// Update is called once per frame
	void Update ()
	{
	    _timer += Time.deltaTime;
	    if (_timer >= RandomTimer)
	    {
	        var rnd = new Random();
	        var rndValue = rnd.Next(0, 100);
	        if (SpawnRate >= rndValue)
	        {
	            Instantiate(EnemyToSpawn, gameObject.transform.position, Quaternion.identity);
	        }
	        _timer = 0;
	    }
	}
}
