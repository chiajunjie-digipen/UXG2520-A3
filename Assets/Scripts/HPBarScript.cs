using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    // Start is called before the first frame update
    Slider hp;
    PlayerStats ps;
    void Start()
    {
        hp = GetComponent<Slider>();
        ps = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        hp.maxValue = ps.maxHealth;
        hp.value = ps.currentHealth;
    }
}
