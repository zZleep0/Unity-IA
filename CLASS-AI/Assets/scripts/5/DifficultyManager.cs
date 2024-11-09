using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public int playerScore = 0;
    public int playerDeaths = 0;

    public float enemyHealthMultiplier = 1.0f;
    public int difficultyLevel = 1;



    // Update is called once per frame
    void Update()
    {
        AdjustDifficulty();
    }

    public void AdjustDifficulty()
    {
        if (playerScore >= difficultyLevel * 100)
        {
            difficultyLevel++;
            enemyHealthMultiplier += 0.5f; //Aumenta a saude do inimigo
            NotifyEnemies(); //Notifica os inimigos
            Debug.Log("Dificuldade aumentada! Nivel: " + difficultyLevel);
        }

        else if (playerDeaths > difficultyLevel * 3)
        {
            difficultyLevel = Mathf.Max(1, difficultyLevel - 1);
            enemyHealthMultiplier = Mathf.Max(1.0f, enemyHealthMultiplier - 0.5f); //Reduz a saude dos inimigos
            NotifyEnemies(); // Notifica os inimigos
            Debug.Log("Dificultade reduzida! Nível: " + difficultyLevel);
        }
    }

    public void NotifyEnemies()
    {
        foreach (var enemy in Object.FindObjectsByType<EnemyController>(FindObjectsSortMode.None))
        {
            enemy.UpdateHealth(); //Atualiza a saúde dos inimigos
        }
    }
}
