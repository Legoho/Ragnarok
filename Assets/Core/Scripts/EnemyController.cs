using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MovementController
{
    private bool useGridMovement = false;
    private Character character;
    public float detectionRange;
    public bool PlayerDetected = false;

    private Vector3 lastPosition;

    private float maxMovementPerTurn => GetComponent<CharacterSeriali>().character.Speeds[0] * gridSize; // Assuming the first movement entry is the primary movement value



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;
        character = GetComponent<CharacterSeriali>().character; // Assuming CharacterSeriali is attached to the same GameObject
        agent = this.GetComponent<NavMeshAgent>();
        detectionRange = character.sight[0]*gridSize; // Assuming the first sight entry is the primary detection range
    }


    void Update()
    {
        IsTurnOver = movementUsedThisTurn >= maxMovementPerTurn;
        if (IsTurnOver)
        {
            agent.ResetPath();
            agent.speed = 0f; // Stop the agent when the turn is over
        }
        else
        {
            agent.speed = 3.5f; // Reset to default speed when not over
        }

        if (combatState && !useGridMovement)
        {
            TurnOnGridMovement();
        }
        else if(!combatState && useGridMovement)
        {
            TurnOffGridMovement();
        }


        if (agent.hasPath && agent.remainingDistance > agent.stoppingDistance)
        {
            float distanceMoved = Vector3.Distance(transform.position, lastPosition);
            movementUsedThisTurn += distanceMoved;
        }

        lastPosition = transform.position;

        MoveTowardsNearestPlayer();
    }

    public void ResetMovement()
    {
        movementUsedThisTurn = 0f;
    }


    private void MoveTowardsNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 0) return;

        GameObject nearestPlayer = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (GameObject player in players)
        {
            float dist = Vector3.Distance(currentPos, player.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null && minDist <= detectionRange && !PlayerDetected)
        {
            PlayerDetected = true;
        }

            if (nearestPlayer != null && PlayerDetected)
        {
            Vector3 targetPos = nearestPlayer.transform.position;
            if (useGridMovement)
            {
                targetPos = GetNearestGridPoint(targetPos);
            }
            agent.SetDestination(targetPos);
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
