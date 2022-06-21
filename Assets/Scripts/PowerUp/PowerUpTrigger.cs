using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour
{
    public PowerUpManager powerUpManager;

    public PowerUpID id;

    protected Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector3.down;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            IPowerUp powerUp = powerUpManager.GetPowerUp(id);
            powerUp.Effect();
            Destroy(gameObject);
        }
    }
}
