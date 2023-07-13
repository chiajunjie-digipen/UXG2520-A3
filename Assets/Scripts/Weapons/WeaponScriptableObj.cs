using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObj", menuName = "ScriptableObjs/Weapons")]

public class WeaponScriptableObj : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    
    //weapon base stats
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    float speed;
    public float Speed { get => speed; private set => speed = value; }

    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }

    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }
}
