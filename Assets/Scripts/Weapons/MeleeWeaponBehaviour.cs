using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObj weaponData; //shar

    public float destroyAfterSeconds;

    [SerializeField] protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake() //jj
    {
        PlayerStats ps = FindObjectOfType<PlayerStats>(); // there is only one player and this is technically spaghetti code i hate myself too
        currentDamage = weaponData.Damage * 
        float.Parse(GameObject.Find("Scaling").GetComponent<MultiplierHandler>().
        multiplierProperties[ps.currentLevel]["damageMultiplier"]); // multiplies damage by level
        
        if (ps.isStrengthened){
            currentDamage *= float.Parse(GameObject.Find("Scaling").GetComponent<MultiplierHandler>().multiplierProperties[ps.currentLevel]["strengthenPotionMultiplier"]);
        }


        

        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }
    // Start is called before the first frame update
    protected virtual void Start() //shar
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
