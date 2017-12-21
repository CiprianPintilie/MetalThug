using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{

    private bool _playerFinished;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Return) && _playerFinished)
	    {
	        SceneManager.LoadScene("Level1");
	    }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            //WIN
            _playerFinished = true;
            var canvasTransform = GameObject.Find("Canvas").transform;
            var winPanel = canvasTransform.GetChild(5).gameObject;
            winPanel.transform.GetChild(2).GetComponent<Text>().text = canvasTransform.GetChild(2).gameObject.GetComponent<Text>().text;
            winPanel.SetActive(true);
            collider.gameObject.SetActive(false);
        }
    }
}
