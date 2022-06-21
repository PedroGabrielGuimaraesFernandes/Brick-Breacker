using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<PowerUp> powerUpList;
    public List<PowerUpTrigger> powerUpPrefabList;

    public GameObject paddle;
    public GameObject ball;

    public GameManager gameManager { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        powerUpList.AddRange(gameObject.GetComponentsInChildren<PowerUp>());
        paddle = FindObjectOfType<BarMovement>().gameObject;
        ball = FindObjectOfType<BallMovement>().gameObject;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IPowerUp GetPowerUp(PowerUpID powerUpID)
    {
        for (int i = 0; i < powerUpList.Count; i++)
        {
            if(powerUpList[i].id == powerUpID)
            {
                return powerUpList[i];
            }
        }
        return null;
    }

#region Cuida do spawn dos power ups //tem que ser revisto ainda

    public void SpawnPowerUp(Vector3 position){
        float randomValue = Random.Range(0, 100);
        if(randomValue <= 10)
        {
        Debug.Log("SpawnPowerUp");
            SpawnPowerUp(GetRandomPowerUp(), position);
        }
    }

    private void SpawnPowerUp(PowerUpTrigger powerUp, Vector3 position)
    {
        PowerUpTrigger powerUpTrigger = Instantiate(powerUp.gameObject, position, Quaternion.identity).GetComponent<PowerUpTrigger>();
        powerUpTrigger.powerUpManager = this;
    }

    public PowerUpTrigger GetRandomPowerUp()
    {
        int powerUpValue = Random.Range(0, powerUpPrefabList.Count);        
        return powerUpPrefabList[powerUpValue];
    }
#endregion

}
