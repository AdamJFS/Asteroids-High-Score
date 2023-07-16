using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{

    public CharacterDatabase characterDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;
    void Start()
    {
       
        if (!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
        

    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.characterCount)
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.characterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", selectedOption);
    }


    private void UpdateCharacter(int selectedOption)
    {
        CharacterSelection character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
        nameText.text = nameText.text.ToUpper();
    }


}
