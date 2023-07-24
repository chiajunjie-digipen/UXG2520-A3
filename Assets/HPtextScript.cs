using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPtextScript : MonoBehaviour
{
    // Start is called before the first frame update

    TMP_Text hp;
    PlayerStats ps;
    void Start()
    {
        hp = GetComponent<TMP_Text>();
        ps = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = ps.currentHealth.ToString() + "/" + ps.maxHealth.ToString();
    }
}
