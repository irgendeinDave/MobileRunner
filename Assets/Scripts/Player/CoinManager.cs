using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/// <summary>
/// controls coin count in UI and takes care of the total coins balance
/// </summary>
public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounterText;
    
    [SerializeField] private Rigidbody2D rb;
    private static int coinsCollected = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("HIT");
        if (!other.gameObject.CompareTag("Coin"))
            return;
        Destroy(other.gameObject);
        ++coinsCollected;
        UpdateCoinsUI();
    }

    private void UpdateCoinsUI()
    {
        coinCounterText.text = coinsCollected.ToString();
    }

    public static void AddCoinsToTotal()
    {
        int score = GameObject.FindWithTag("Player").GetComponent<ScoreManager>().getScore();
        Debug.Log("Score: " + score);
        int current = PlayerPrefs.GetInt("coins", 0);
        PlayerPrefs.SetInt("coins", current + Mathf.FloorToInt(.002f * coinsCollected * score * score)); // add (score²)/500 * collected coins in the round to the balance
        Debug.Log("Coins: " + PlayerPrefs.GetInt("coins"));
    }
}
