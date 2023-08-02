using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;
    private Character selectedCharacter;

    private void Awake()
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
            if (selectedCharacter.isSelected)
            {
                selectedCharacter.ResetCharacter();
                selectedCharacter.isSelected = false;
            }
        }

        selectedCharacter = character;
    }

    public void OnPlayButtonClick()
    {
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacter.characterId);
        SceneManager.LoadScene("UsernameAndRoom");
    }
}
