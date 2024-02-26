using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startingMovementSpeed;
    private float movementSpeed;
    [SerializeField] private float roationSpeed;

    [SerializeField] private float startingElevation;
    private Rigidbody2D rb;

    private void Awake()
    {
        transform.position = new Vector3(0, startingElevation, 0);
        movementSpeed = startingMovementSpeed;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; //deactivate gravity
    }

    void FixedUpdate()
    {
        //old system
        float newY = transform.position.y;
        movementSpeed = startingMovementSpeed + (transform.position.x / 100) * Time.fixedDeltaTime;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            newY = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0)).y;
        }
        rb.MovePosition(new Vector2(transform.position.x + movementSpeed * Time.deltaTime, newY));

        //movementSpeed = startingMovementSpeed + (transform.position.x / 100);
        //if (Input.touchCount > 0)
        //{
        //    Touch t = Input.GetTouch(0);
        //    Debug.Log(Camera.main.ScreenToWorldPoint(t.position));
        //    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(t.position);
        //    Vector3 angle = worldPoint - transform.position;

        //} 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DeathBehavior db = gameObject.GetComponent<DeathBehavior>();
        db.die(collision.gameObject);
    }
}
