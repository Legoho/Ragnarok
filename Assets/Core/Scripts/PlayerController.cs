using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MovementController
{
    private bool useGridMovement = false;
    private float maxMovementPerTurn => GetComponent<CharacterSeriali>().character.Speeds[0] * gridSize; // Assuming the first movement entry is the primary movement value
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        IsTurnOver = movementUsedThisTurn >= maxMovementPerTurn;
        if(IsTurnOver)
        {
            agent.ResetPath();
            agent.speed = 0f; // Stop the agent when the turn is over
            if (combatState)
            {
                Debug.Log("Player's turn is over, waiting for next turn.");
            }
            else
            {
                ResetMovement(); // Reset movement as we aren't in combat state
            }
        }
        else
        {
            agent.speed = 3.5f; // Reset to default speed when not over
        }

        if (combatState && !useGridMovement)
        {
            TurnOnGridMovement();
        }
        else if (!combatState && useGridMovement)
        {
            TurnOffGridMovement();
        }

        if (agent.hasPath && agent.remainingDistance > agent.stoppingDistance)
        {
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
            movementUsedThisTurn += distanceMoved;
        }

        lastPosition = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (useGridMovement)
                {
                    Debug.Log("Using Grid based movement");
                    Vector3 gridPoint = GetNearestGridPoint(hit.point);
                    agent.SetDestination(gridPoint);
                }
                else
                {
                    Debug.Log("Using Navmesh");
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

    private void TurnOnGridMovement()
    {
        useGridMovement = true;
        Debug.Log("Grid movement enabled");
    }

    private void TurnOffGridMovement()
    {
        useGridMovement = true;
        Debug.Log("Grid movement enabled");
    }

    private Vector3 GetNearestGridPoint(Vector3 position)
    {
        float x = Mathf.Round(position.x / gridSize) * gridSize;
        float y = position.y; // Keep the original y to stay on the NavMesh
        float z = Mathf.Round(position.z / gridSize) * gridSize;
        return new Vector3(x, y, z);
    }
}
