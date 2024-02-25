using UnityEngine;
using TMPro;
public class LoadHighscore : MonoBehaviour
{
    void Start()
    {
        TMP_Text t = gameObject.GetComponent<TMP_Text>();
        t.text = $"Highscore:\n{ScoreManager.loadHighscore().ToString()}";
    }

}
