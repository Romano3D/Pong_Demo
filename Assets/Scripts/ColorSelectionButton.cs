using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionButton : MonoBehaviour
{
    public Button uiButton;
    public Image paddleRefence; // imagem q será alterada
    public Sprite newSprite;    // nova imagem que o botão vai aplicar
    public Sprite newSpriteHit;

    public int spriteIndex;



    public bool isPlayerSprite = false;

    //  public bool isColorPlayer = false;

    public void Start()
    {
        uiButton.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        paddleRefence.sprite = newSprite;
       // paddleRefence.color = uiButton.colors.normalColor;

        if (isPlayerSprite )
        //if (isColorPlayer)
        {
            SaveController.Instance.SetSpritePlayer(newSprite, newSpriteHit); 
             //SaveController.Instance.colorPlayer = paddleRefence.color;
        }
        else
        {
            SaveController.Instance.SetSpriteEnemy(newSprite, newSpriteHit);
            // SaveController.Instance.colorEnemy = paddleRefence.color;

        }
    }
}