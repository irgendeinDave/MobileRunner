using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadPreviousScore : MonoBehaviour
{
    private void Start()
    {
        TMP_Text text = gameObject.GetComponent<TMP_Text>();
        text.text = "Score:\n" + ScoreManager.loadScore().ToString();
    }
}
