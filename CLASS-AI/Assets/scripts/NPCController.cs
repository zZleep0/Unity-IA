using System.Collections;
using UnityEngine;

public enum NPCState
{
    Patrolling,
    Jumping,
    Sleeping
}

public class NPCController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed = 2f;
    public float jumpForce = 5f;
    private int currentPoint = 0;
    private NPCState currentState = NPCState.Patrolling;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (currentState)
        {
            case NPCState.Patrolling:
                Patrol();
                break;
            case NPCState.Jumping:
                // Você pode adicionar lógica de pulo aqui, se necessário.
                break;
            case NPCState.Sleeping:
                // Lógica para estado de dormir, se necessário.
                break;
        }
    }

    void Patrol()
    {
        Transform target = patrolPoints[currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        currentState = NPCState.Sleeping; // Mudar para o estado de dormir
        StartCoroutine(Sleep());
    }

    private IEnumerator Sleep()
    {
        yield return new WaitForSeconds(3); // Tempo de sono
        currentState = NPCState.Patrolling; // Volta a patrulhar
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }
}
