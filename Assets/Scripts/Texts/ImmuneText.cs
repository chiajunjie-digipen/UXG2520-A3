using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImmuneText : MonoBehaviour
{
    public TMP_Text canvasText; //shar

    void Update()
    {
        ClearText();

        PlayerStats player = FindObjectOfType<PlayerStats>();

        if (player.invincibilityTimer > 0.5f)
        {
            canvasText.text = "You are Immune!";
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
