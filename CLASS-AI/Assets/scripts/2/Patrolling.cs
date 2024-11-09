using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrolling : MonoBehaviour
{

    [SerializeField] private Transform[] waypoints; // Array de pontos de patrulha
    [SerializeField] private float speed = 2f;      // Velocidade do patrulhamento
    private int targetPoint = 0;                    // Ponto alvo atual

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0; // Define o ponto alvo como zero
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == waypoints[targetPoint].position)
        {
            targetPoint = (targetPoint + 1) % waypoints.Length; 
        }

        // Atualiza a posição do NPC
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetPoint].position, speed * Time.deltaTime);
    }
}
