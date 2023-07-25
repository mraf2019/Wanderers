using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    private Character selectedCharacter;
    void Start()
    {
        Debug.Log("Start");
    }
    void Awake()
    {
        // Ensure only one instance of the CardManager exists
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void OnCharacterSelected(Character character)
    {
        if(selectedCharacter != null && selectedCharacter != character)
        {
            selectedCharacter.ResetCharacter();
            selectedCharacter.isSelected = false;
        }

        selectedCharacter = character;
    }
}
