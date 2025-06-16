using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public EnemyController[] enemies; // Array of enemies in the combat area
    public PlayerController[] playerCharacters; // Reference to the player controller
    private Dictionary<CharacterSeriali,float> charactersInitiativeInCombat; // Array of characters in combat
    public bool anyEnemyInCombat = false;
    public bool combatState = false; // This variable can be used to toggle combat state

    public int currentCharIndex = 0;
    public int currentTurnIndex = 0;
    private bool firstCharacterTurn = true; // Flag to check if it's the first character's turn

    public List<CharacterSeriali> initiativeOrder = new List<CharacterSeriali>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charactersInitiativeInCombat = new Dictionary<CharacterSeriali, float>();
        enemies = FindObjectsByType<EnemyController>(FindObjectsSortMode.None); // Specify the required argument
        playerCharacters = FindObjectsByType<PlayerController>(FindObjectsSortMode.None); // Specify the required argument

    }

// Update is called once per frame
void Update()
    {
        foreach(EnemyController enemy in enemies)
        {
            if (enemy.PlayerDetected && !enemy.combatState)
            {
                enemy.combatState=true;
                anyEnemyInCombat = true;
                enemy.GetComponent<MovementController>().movementUsedThisTurn =
                    enemy.GetComponent<CharacterSeriali>().character.Speeds[0] * enemy.GetComponent<MovementController>().gridSize;
                Debug.Log("enemy's turn is over: " + enemy.GetComponent<MovementController>().IsTurnOver);
                InitiativeTracking(enemy.GetComponent<CharacterSeriali>());
                enemy.GetComponent<MovementController>().agent.ResetPath(); // Reset movement for player characters
            }
            if (enemy.combatState && !combatState)
            {
                foreach (PlayerController player in playerCharacters)
                {
                    player.combatState = true;
                    InitiativeTracking(player.GetComponent<CharacterSeriali>());
                    player.GetComponent<MovementController>().movementUsedThisTurn =
                        player.GetComponent<CharacterSeriali>().character.Speeds[0] * player.GetComponent<MovementController>().gridSize;
                    Debug.Log("player's turn is over: " + player.GetComponent<MovementController>().IsTurnOver);
                    player.GetComponent<MovementController>().agent.ResetPath(); // Reset movement for player characters
                }
                combatState = true;
                firstCharacterTurn = true; // Reset the flag for the first character's turn
            }
        }
        initiativeOrder = charactersInitiativeInCombat.Keys.ToList();

        if (combatState && charactersInitiativeInCombat.Count > 1)
        {
            CharacterSeriali currentChar = initiativeOrder[currentCharIndex];
            MovementController movementController;
            bool isTurnOver = false;

            if (firstCharacterTurn)
            {
                currentChar.GetComponent<MovementController>().ResetMovement(); // Reset movement for the first character
                firstCharacterTurn = false;
            }


                movementController = currentChar.GetComponent<MovementController>();
                isTurnOver = movementController.IsTurnOver;
                if (isTurnOver)
                {
                    currentCharIndex++; // Move to the next character in the initiative order
                    if ((currentCharIndex >= initiativeOrder.Count))
                    {
                        currentCharIndex = 0;
                        currentTurnIndex++;
                    }
                     
                    currentChar = initiativeOrder[currentCharIndex]; // Update currentChar to the next character
                    currentChar.GetComponent<MovementController>().ResetMovement(); // Reset movement for the next character
                }
        }
        
    }

    public void InitiativeTracking(CharacterSeriali character)
    {
        charactersInitiativeInCombat.Add(character, Random.Range(1, 20) + character.currentInitiative);
        // Sort characters by initiative
        charactersInitiativeInCombat = charactersInitiativeInCombat.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        Debug.Log("Initiative Tracking: " + character.characterName + " rolled " + charactersInitiativeInCombat[character]);

    }
}
