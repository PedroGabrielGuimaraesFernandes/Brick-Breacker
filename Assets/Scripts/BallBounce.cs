using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

    private Rigidbody2D rig;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rig.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float speed = lastVelocity.magnitude;
        Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rig.velocity = direction * Mathf.Max(speed, 0);
    }
}
