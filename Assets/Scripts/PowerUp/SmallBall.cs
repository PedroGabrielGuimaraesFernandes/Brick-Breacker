using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : PowerUp, IPowerUp
{
    public static float effectTimer = 10f;

    public override void Effect()
    {
        Debug.Log(gameObject.name + " fez seu efeito");
        effectTimer = 5f;
        if (powerUpManager.ball.transform.localScale.x > 0.75f)
        {
            powerUpManager.ball.transform.localScale = new Vector3(powerUpManager.ball.transform.localScale.x - 0.25f, powerUpManager.ball.transform.localScale.y - 0.25f, powerUpManager.ball.transform.localScale.z);
            StartCoroutine(ShrinkBallTimer());
        }
    }

    public void ReturnToNormal()
    {
        if (powerUpManager.ball.transform.localScale.x == 0.75f)
            powerUpManager.ball.transform.localScale = Vector3.one;
        StopCoroutine(ShrinkBallTimer());
    }

    private IEnumerator ShrinkBallTimer()
    {
        Debug.Log("Ball shrinked for " + effectTimer);
        yield return new WaitForSeconds(1f);
        while (effectTimer > 0)
        {
            effectTimer--;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("ball voltou ao normal");
        ReturnToNormal();
    }
}
