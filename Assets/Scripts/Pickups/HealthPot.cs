using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour, ICollectible
{
    //public int healthToRestore; //shar
    public void Collect()
    {
        PlayerStats ps = FindObjectOfType<PlayerStats>();
        ps.RestoreHealth(float.Parse(FindObjectOfType<MultiplierHandler>().multiplierProperties[ps.currentLevel]["recovery"]));
        Destroy(gameObject);
    }
}
