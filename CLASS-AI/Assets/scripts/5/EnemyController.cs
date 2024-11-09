using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    private float baseHealth = 100f;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (difficultyManager.difficultyLevel > 2)
        {
            AttackPlayer();
        }
        else
        {
            Patrol();
        }
    }

    public void UpdateHealth()
    {
        currentHealth = baseHealth * difficultyManager.enemyHealthMultiplier;
        Debug.Log("Saude do inimigo: " + currentHealth);
    }

    void AttackPlayer()
    {
        Debug.Log("Inimigo atacando o jogador");
    }

    void Patrol()
    {
        Debug.Log("Inimigo patrulhando");
    }
}
