using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    private static int highscore = 0;

    [SerializeField] private TMP_Text scoreUIText;


    private void Update()
    {
        score = Mathf.RoundToInt(transform.position.x / 2);
        scoreUIText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            saveHighscore();
        }
    }

    #region Store in PlayerPrefs
    public static void saveScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
    public static int loadScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public static void saveHighscore()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }
    public static int loadHighscore()
    {
        return PlayerPrefs.GetInt("highscore", 0);
    }
    #endregion
}
