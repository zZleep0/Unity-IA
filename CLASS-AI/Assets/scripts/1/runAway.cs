using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class runAway : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;

    [SerializeField] private Transform stalker = null;

    [SerializeField] private float travelCost = 5f;




    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;

    //    // Calculando a direção do stalker em relação ao objeto atual
    //    Vector3 direction = (stalker.position - transform.position).normalized;
    //    // Direção normalizada

    //    // Calculando a magnitude da direção
    //    float magnitude = direction.magnitude; // Magnitude da direção


    //    // Imprimindo a magnitude no console
    //    print(magnitude); // Imprimindo a magnitude


    //    Gizmos.DrawLine(transform.position, transform.position + direction);
    //}

    // Start is called before the first frame update

    void Start()
    {

        if (agent == null)
        {
            if (!TryGetComponent(out agent))
            {
                Debug.LogWarning(name + "precisa colocar um navmesh agent");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (stalker == null)
            return;

        Vector3 directionNormalized = (stalker.position - transform.position).normalized;

        directionNormalized = Quaternion.AngleAxis(Random.Range(0, 179), Vector3.up) * directionNormalized;


        MoveToPos(transform.position - (directionNormalized * travelCost));

    }

    private void MoveToPos(Vector3 position)
    {
        agent.SetDestination(position);
        agent.isStopped = false;
    }

}
