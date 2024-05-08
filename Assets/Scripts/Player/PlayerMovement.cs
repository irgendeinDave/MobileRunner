using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startingMovementSpeed;
    [SerializeField] private float verticalSpeed = 1f;
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

    private Vector3 newPosition;
    void FixedUpdate()
    {
        movementSpeed = startingMovementSpeed + (transform.position.x / 100) * Time.fixedDeltaTime;
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            float yDestination = Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, 0)).y;
            newPosition = transform.position + new Vector3( movementSpeed * Time.fixedDeltaTime * Time.fixedDeltaTime,
                                                            (yDestination - transform.position.y) * Time.deltaTime * verticalSpeed, 
                                                            0);
        }
        else
        {
            newPosition = new Vector3(transform.position.x + movementSpeed * Time.fixedDeltaTime, transform.position.y, 0);
        }
        Debug.Log("x speed" + movementSpeed);

        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Don't die when coin is collected
        if (collision.gameObject.CompareTag("Coin"))
            return;
        
        DeathBehavior db = gameObject.GetComponent<DeathBehavior>();
        db.die(collision.gameObject);
    }
}
