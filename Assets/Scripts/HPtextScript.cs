using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPtextScript : MonoBehaviour
{
    // jj

    TMP_Text hp;
    PlayerStats ps;
    void Start()
    {
        hp = GetComponent<TMP_Text>();
        ps = FindObjectOfType<PlayerStats>();
        Debug.Log(Application.persistentDataPath);
    }

    void Update()
    {
        hp.text = ps.currentHealth.ToString() + "/" + ps.maxHealth.ToString();
    }
}
