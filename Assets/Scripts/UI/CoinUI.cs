using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("coins", 0).ToString();
    }
}
