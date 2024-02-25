using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] Sprite[] backgroundImages;

    void Start()
    {       
        gameObject.GetComponent<SpriteRenderer>().sprite = backgroundImages[Random.Range(0, backgroundImages.Length)];  
    }

}
