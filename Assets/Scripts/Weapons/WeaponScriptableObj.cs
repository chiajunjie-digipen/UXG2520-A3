using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObj", menuName = "ScriptableObjs/Weapons")]

public class WeaponScriptableObj : ScriptableObject
{
    public GameObject prefab;
    //weapon base stats
    public float damage;
    public float speed;
    public float cooldownDuration;
    public int pierce;
}
