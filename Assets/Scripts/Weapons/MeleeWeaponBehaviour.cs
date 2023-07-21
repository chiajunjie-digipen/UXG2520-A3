using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObj weaponData;

    public float destroyAfterSeconds;

    [SerializeField] protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage * 
        float.Parse(GameObject.Find("Scaling").GetComponent<MultiplierHandler>().
        multiplierProperties[GameObject.Find("Player").
        GetComponent<PlayerStats>().
        currentLevel]["damageMultiplier"]);


        

        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //use currentDamage in case of dmg multipliers

        }
    }

    
}
