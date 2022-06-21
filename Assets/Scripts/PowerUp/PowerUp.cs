using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour, IPowerUp
{

    public PowerUpManager powerUpManager {  get; private set; }

    protected Rigidbody2D rig;    

    public PowerUpID id;

    public PowerUpID GetID()
    {
        return id;
    }

    protected void Start()
    {
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    public abstract void Effect();
}

public enum PowerUpID
{
    EnlargePaddle,
    ShrinkPaddle,
    BallMultiplier,
    SmallBall,
    NewLife
}
