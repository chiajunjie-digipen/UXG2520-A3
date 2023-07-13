using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObj", menuName = "ScriptableObjs/Enemy")]
public class EnemyScriptableObj : ScriptableObject
{
    //base stats for enemies
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    float damage;
    public float Damage { get => damage; private set => damage = value; }
}
