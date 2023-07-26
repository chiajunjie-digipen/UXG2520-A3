using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObj", menuName = "ScriptableObjs/Enemy")]
public class EnemyScriptableObj : ScriptableObject //jj
{
    //base stats for enemies //jj
    /*[SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float damage;
    public float Damage { get => damage; private set => damage = value; }

    [SerializeField]
    float enemy_xp;
    public float Exp { get => enemy_xp; private set => enemy_xp = value; }*/

    //csv stores data now

    [SerializeField]
    int enemy_id;
    public int enemyid { get => enemy_id; private set => enemy_id = value; }
}
