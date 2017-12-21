using UnityEngine;

public class Explosion : MonoBehaviour {

    void Start()
    {
        AudioSource[] audios = gameObject.GetComponents<AudioSource>();
        int clipPick = Random.Range(0, 4);
        audios[clipPick].Play();
    }

    void FixedUpdate()
    {
        Destroy(gameObject, 1f);
    }
}
