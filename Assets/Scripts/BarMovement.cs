using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{

    private Rigidbody2D rig;
    private Vector2 direction;

    public float speed = 30f;

    public float maxBounceAngle = 75f;

    private bool stopMov = false;

    private void Awake()
    {
        //initalPosition = transform.position;
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stopMov)
        {
            MoveBar();
        }
    }

    private void MoveBar()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            direction = Vector2.right;
        } else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }

        rig.AddForce(direction * speed);
    }

    public void StopPaddle()
    {
        stopMov = true;
        rig.velocity = Vector2.zero;
    }

    public void ResetPaddle()
    {
        rig.velocity = Vector2.zero;
        transform.position = new Vector2(0f, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallMovement ball = collision.gameObject.GetComponent<BallMovement>();

            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            //direção atual da bola
            float currentAngle = Vector2.SignedAngle(Vector2.up,ball.Rig.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.Rig.velocity = rotation * Vector2.up * ball.Rig.velocity.magnitude; 
        }
    }
}
