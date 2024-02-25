using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// control positioning of the background so it follows the player
/// </summary>
public class BackgroungMovement : MonoBehaviour
{
    private Transform camera;
    private const float y = 4.6f;
    private float x;
    private const float z = .5f;

    private void Awake()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void Update()
    {
        x = camera.position.x;
        transform.position = new Vector3(x, y, z);
    }
}
