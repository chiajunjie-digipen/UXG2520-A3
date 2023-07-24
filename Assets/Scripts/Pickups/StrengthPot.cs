using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPot : MonoBehaviour, ICollectible
{
    public void Collect() //jj
    {
        PlayerStats ps = FindObjectOfType<PlayerStats>();
        ps.Strengthen(float.Parse(FindObjectOfType<MultiplierHandler>().multiplierProperties[ps.currentLevel]["strengthenDuration"]));
        Destroy(gameObject);
    }
}
