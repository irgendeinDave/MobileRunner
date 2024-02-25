using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// apply random panel drift in start screen
/// </summary>
public class Panel : MonoBehaviour
{
    [SerializeField] private float panelDriftSpeed;
    private Vector2 driftDirection = Vector2.zero;

    private void Start()
    {
        driftDirection = new Vector2(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    private float timer;
    private void Update()
    {
        transform.Translate(driftDirection * panelDriftSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        if (timer > 5)
        {
            driftDirection *= -1;
            timer = 0;
        }
    }
}
