using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PortraitHandler : MonoBehaviour
{
    public CharacterSeriali[] characters;
    public Image[] portraits;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        characters = new CharacterSeriali[playerObjects.Length];
        for (int i = 0; i < playerObjects.Length; i++)
        {
            characters[i] = playerObjects[playerObjects.Length - 1 - i].GetComponent<CharacterSeriali>();
        }

        characters = characters.OrderBy(c =>
        {
            var match = Regex.Match(c.name, @"^(\d+)");
            return match.Success ? int.Parse(match.Groups[1].Value) : int.MaxValue;
        }).ToArray();


        GameObject[] portraitObjects = GameObject.FindGameObjectsWithTag("Portrait");
        portraits = new Image[portraitObjects.Length];
        for (int i = 0; i < portraitObjects.Length; i++)
        {
            portraits[i] = portraitObjects[portraitObjects.Length-1-i].GetComponent<Image>();
        }
        // Assign character icons to portraits
        for (int i = 0; i < characters.Length; i++)
        {
            portraits[i].sprite = characters[i].character.characterIcon;
        }
    }

    
}
