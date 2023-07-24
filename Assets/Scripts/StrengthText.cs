using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrengthText : MonoBehaviour
{
    public TMP_Text canvasText; //shar

    void Update()
    {
        ClearText();

        PlayerStats player = FindObjectOfType<PlayerStats>();

        if (player.strengthenTimer > 0f)
        {
            canvasText.text = "Damage Up!";
        }
        else
        {
            ClearText();
        }
    }

    void ClearText()
    {
        canvasText.text = null;
    }
}
