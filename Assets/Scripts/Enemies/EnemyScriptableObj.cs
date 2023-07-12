using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObj", menuName = "ScriptableObjs/Enemy")]
public class EnemyScriptableObj : ScriptableObject
{
    //base stats for enemies
    public float moveSpeed;
    public float maxHealth;
    public float damage;
}
