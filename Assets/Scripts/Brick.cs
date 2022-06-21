using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public int health { get; private set; }

    public Sprite[] brickStates;

    public Sprite unbrekablebrickSprite; 

    public bool unbreakable;

    public int points = 100;

    private ScoreManager scoreManager;
    private PowerUpManager powerUpManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Start()
    {
        if (!unbreakable)
        {
            this.health = brickStates.Length;
            spriteRenderer.sprite = brickStates[health - 1];
        }
        else
        {
            spriteRenderer.sprite = unbrekablebrickSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }

        health--;
        if (health > 0)
        {
            spriteRenderer.sprite = brickStates[health - 1];
        }
        else
        {
            powerUpManager.SpawnPowerUp(transform.position);
            this.gameObject.SetActive(false);
        }

        scoreManager.Hit(this);



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hit();
        }
    }
}
