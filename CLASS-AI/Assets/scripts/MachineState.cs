using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineState : MonoBehaviour
{

    private enum State
    {
        Patrulhar,
        Dormir,
        Pular,
        Perseguir,
        Atacar
    }


    [SerializeField] private State currentState;

    // Dicionário que define as transições permitidas
    private Dictionary<State, List<State>> stateTransitions = new Dictionary<State, List<State>>();


    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Patrulhar; // Estado inicial

        // Definindo transições válidas
        stateTransitions[State.Patrulhar] = new List<State> { State.Dormir, State.Pular, State.Perseguir };
        stateTransitions[State.Dormir] = new List<State> { State.Patrulhar }; // Pode voltar apenas para Patrulhar
        stateTransitions[State.Pular] = new List<State> { State.Patrulhar }; // Pode voltar apenas para Patrulhar
        stateTransitions[State.Perseguir] = new List<State> { State.Patrulhar }; // Pode voltar apenas para Patrulhar

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrulhar:
                Patrulhar();
                break;
            case State.Dormir:
                Dormir();
                break;
            case State.Pular:
                Pular();
                break;
            case State.Perseguir:
                Perseguir();
                break;
        }

    }
    private void Patrulhar()
    {
        Debug.Log("Patrulhando...");

        if (Input.GetKeyDown(KeyCode.D) && CanTransitionTo(State.Dormir))
        {
            ChangeState(State.Dormir);
        }
        else if (Input.GetKeyDown(KeyCode.P) && CanTransitionTo(State.Perseguir))
        {
            ChangeState(State.Perseguir);
        }

    }

    private void Dormir()
    {
        Debug.Log("Dormir...");

        //// Espera 3 segundos
        StartCoroutine(DormirCorrotina());

        if (Input.GetKeyDown(KeyCode.E) && CanTransitionTo(State.Patrulhar))
        {
            ChangeState(State.Patrulhar);
        }
    }

    private void Pular()
    {
        Debug.Log("Pular...");

        if (Input.GetKeyDown(KeyCode.E) && CanTransitionTo(State.Patrulhar))
        {
            ChangeState(State.Patrulhar);
        }
    }

    private void Perseguir()
    {
        Debug.Log("Perseguir...");
        if (Input.GetKeyDown(KeyCode.E) && CanTransitionTo(State.Patrulhar) )
        {
            ChangeState(State.Patrulhar);
        }
    }


    private void ChangeState(State newState)
    {
        currentState = newState;
        Debug.Log("Mudou para o estado: " + currentState);
    }

    private IEnumerator DormirCorrotina()
    {
        yield return new WaitForSeconds(3);
        currentState = State.Patrulhar; // Volta a Patrulhar após dormir
    }

    private bool CanTransitionTo(State newState)
    {
        return stateTransitions[currentState].Contains(newState);
    }


}
