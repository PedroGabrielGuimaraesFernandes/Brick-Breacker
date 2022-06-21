using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLife : PowerUp, IPowerUp
{
    public override void Effect()
    {
        Debug.Log(gameObject.name + " fez seu efeito");
        powerUpManager.gameManager.GainALife();
    }
}
