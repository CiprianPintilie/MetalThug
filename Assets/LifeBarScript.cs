using UnityEngine;

public class LifeBarScript : MonoBehaviour
{

    public void SetLife(float rapport)
    {
        GetComponent<RectTransform>().localScale = new Vector2(rapport, 1);
    }
}
