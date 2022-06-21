using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplier : PowerUp, IPowerUp
{
    [SerializeField]
    private GameObject ballPrefab;

    public override void Effect()
    {
        Debug.Log(gameObject.name + " fez seu efeito");
        Instantiate(ballPrefab, powerUpManager.ball.transform.position, Quaternion.identity);
    }

    
}
