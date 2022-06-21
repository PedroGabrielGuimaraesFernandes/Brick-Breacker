using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public bool copy = false;

    private Rigidbody2D rig;
    [SerializeField]
    private float forceX;
    private float forceY = 1;
        
    public float speed = 100f;

    public Rigidbody2D Rig { get => rig; set => rig = value; }

    private Vector3 initalPosition;

    private void Awake()
    {
        initalPosition = transform.position;
    }

    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Invoke("LaunchBall", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchBall()
    {
        forceX = Random.Range(-1, 1f);
        Rig.AddForce(new Vector2(forceX, forceY).normalized * speed);
    }

    public void StopBall()
    {
        rig.velocity = Vector2.zero;
    }

    public void ResetBall()
    {
        rig.velocity = Vector2.zero;
        transform.position = initalPosition;
        Invoke("LaunchBall", 1f);
    }
}
