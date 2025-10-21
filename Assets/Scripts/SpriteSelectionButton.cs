using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Sprite newSprite;
    public bool isPlayerSprite = false;

    private void Start()
    {
        uiButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        string spriteName = newSprite.name; // nome do arquivo do sprite

        if (isPlayerSprite)
            PlayerPrefs.SetString("SelectedPlayerSprite", spriteName);
        else
            PlayerPrefs.SetString("SelectedEnemySprite", spriteName);

        PlayerPrefs.Save(); //  garante que o dado é gravado no disco
        Debug.Log($"Sprite salvo: {spriteName}");
    }
}
