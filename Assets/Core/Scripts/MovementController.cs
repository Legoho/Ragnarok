using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{

    public NavMeshAgent agent;
    public float gridSize = 1.0f;
    public float movementUsedThisTurn = 0f;

    public bool combatState = false; // This variable can be used to toggle combat state
    public bool IsTurnOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void ResetMovement()
    {
        movementUsedThisTurn = 0f;
    }
}
