using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPaddle : PowerUp, IPowerUp
{
    public static float effectTimer = 5f;


    public override void Effect()
    {
        Debug.Log(gameObject.name + " fez seu efeito");
        effectTimer = 5f;
        if (powerUpManager.paddle.transform.localScale.x > 0.75f)
        {
            powerUpManager.paddle.transform.localScale = new Vector3(powerUpManager.paddle.transform.localScale.x - 0.25f, powerUpManager.paddle.transform.localScale.y, powerUpManager.paddle.transform.localScale.z);
            StartCoroutine(ShrinkPaddleTimer());
        }
    }

    public void ReturnToNormal()
    {
        if (powerUpManager.paddle.transform.localScale.x == 0.75f)
            powerUpManager.paddle.transform.localScale = Vector3.one;
        StopCoroutine(ShrinkPaddleTimer());
    }

    private IEnumerator ShrinkPaddleTimer()
    {
        Debug.Log("Paddle shrinked for " + effectTimer);
        yield return new WaitForSeconds(1f);
        while (effectTimer > 0)
        {
            effectTimer--;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Paddle voltou ao normal");
        ReturnToNormal();
    }
}
