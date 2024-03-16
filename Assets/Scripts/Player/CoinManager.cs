using TMPro;
using UnityEngine;

/// <summary>
/// controls coin count in UI and takes care of the total coins balance
/// </summary>
public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinCounterText;
    
    [SerializeField] private Rigidbody2D rb;
    private int coinsCollected = 0;
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

    private static void AddCoinsToTotal()
    {
        
    }
}
