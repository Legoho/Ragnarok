using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterHandler : MonoBehaviour
{

    // List of all player characters in the scene
    public List<CharacterSeriali> allPlayerCharacters = new List<CharacterSeriali>();

    // List of currently selected player characters
    public List<CharacterSeriali> selectedCharacters = new List<CharacterSeriali>();

    private Vector2 boxStart;
    private Vector2 boxEnd;
    private bool isSelecting = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleBoxSelection();
        HandleSelectAll();
        HandleSingleClick();
    }



    void HandleBoxSelection()
    {
        // Start box selection
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            isSelecting = true;
            boxStart = Input.mousePosition;
        }

        // End box selection
        if (Input.GetMouseButtonUp(1) && isSelecting)
        {
            isSelecting = false;
            boxEnd = Input.mousePosition;
            SelectCharactersInBox(boxStart, boxEnd);
        }
    }

    void HandleSelectAll()
    {
        // Select all on Backspace
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            selectedCharacters.Clear();
            selectedCharacters.AddRange(allPlayerCharacters);
        }
    }

    void HandleSingleClick()
    {
        // Single click selection (on GameObject)
        if (Input.GetMouseButtonDown(1) && !isSelecting && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var character = hit.collider.GetComponent<CharacterSeriali>();
                if (character != null)
                {
                    selectedCharacters.Clear();
                    selectedCharacters.Add(character);
                }
            }
        }
    }

    void SelectCharactersInBox(Vector2 start, Vector2 end)
    {
        selectedCharacters.Clear();
        Rect selectionRect = new Rect(
            Mathf.Min(start.x, end.x),
            Mathf.Min(start.y, end.y),
            Mathf.Abs(start.x - end.x),
            Mathf.Abs(start.y - end.y)
        );

        foreach (var character in allPlayerCharacters)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(character.transform.position);
            if (selectionRect.Contains(screenPos, true))
            {
                selectedCharacters.Add(character);
            }
        }
    }

    void OnGUI()
    {
        if (isSelecting)
        {
            var rect = new Rect(
                Mathf.Min(boxStart.x, Input.mousePosition.x),
                Screen.height - Mathf.Max(boxStart.y, Input.mousePosition.y),
                Mathf.Abs(boxStart.x - Input.mousePosition.x),
                Mathf.Abs(boxStart.y - Input.mousePosition.y)
            );
            GUI.color = new Color(0, 0.5f, 1, 0.2f);
            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            GUI.color = Color.white;
        }
    }
}  