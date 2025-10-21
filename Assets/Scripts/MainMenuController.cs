using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    
    void Start()
    {
        SaveController.Instance.Reset();
        string lastWinner = SaveController.Instance.GetLasWinner();

        if (lastWinner != " ")
            uiWinner.text = "Ultimo vencedor: " + lastWinner;
        else
            uiWinner.text = " ";
    }

}
