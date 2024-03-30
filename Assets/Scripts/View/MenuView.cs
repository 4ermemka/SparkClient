using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuView : ViewPanel
{
    [SerializeField]
    private TMP_InputField CharacterNameField;

    public Action<string> OnNewCharacterSelected;
    public Action<string> OnExistingCharacterSelected;

    public void SelectNewCharacter()
    {
        OnNewCharacterSelected?.Invoke(CharacterNameField.text);
    }

    public void SelectExistingCharacter()
    {
        OnExistingCharacterSelected?.Invoke(CharacterNameField.text);
    }

}
