using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    // jj
    Slider hp;
    PlayerStats ps;
    void Start()
    {
        hp = GetComponent<Slider>();
        ps = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        hp.maxValue = ps.maxHealth;
        hp.value = ps.currentHealth;
    }
}
