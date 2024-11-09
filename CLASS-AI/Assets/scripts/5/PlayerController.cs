using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public DifficultyManager difficultyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Simulacao de pontuacao e mortes
        if (Input.GetKeyDown(KeyCode.Space)) // Simula ganhar pontos
        {
            difficultyManager.playerScore += 10;
            Debug.Log("Pontuacao: " + difficultyManager.playerScore);
        }

        if (Input.GetKeyDown(KeyCode.K)) //Simula a morte do jogador
        {
            difficultyManager.playerDeaths++;
            Debug.Log("Mortes: " + difficultyManager.playerDeaths);
        }
    }
}
