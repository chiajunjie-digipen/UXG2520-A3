using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // base script for projectiles
    public WeaponScriptableObj weaponData;

    protected Vector3 direction;
    public float destroyAfterSeconds;

    //current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    public void DirectionChecker(Vector4 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector4 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left facing
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if (dirx == 0 && diry < 0) //down facing
        {
            rotation.z = -180f;
        }
        else if (dir.x == 0 && dir.y > 0) //up facing
        {
            rotation.z = -360f;
        }
        else if (dir.x > 0 && dir.y > 0) //rightup facing
        {
            rotation.z = -45f;
        }
        else if (dir.x > 0 && dir.y < 0) //rightdown facing
        {
            rotation.z = -135f;
        }
        else if (dir.x < 0 && dir.y > 0) //leftup facing
        {
            rotation.z = -315f;
        }
        else if (dir.x < 0 && dir.y < 0) //leftdown facing
        {
            rotation.z = -225f;
        }



        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); //quaternion /= vector3
    }

    public void DirectionChecker2(Vector4 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector4 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left facing
        {
            scale.x *= -1;
            scale.y *= -1;
        }
        else if (dirx == 0 && diry < 0) //down facing
        {
            rotation.z = -135f;
        }
        else if (dir.x == 0 && dir.y > 0) //up facing
        {
            rotation.z = 45f;
        }
        else if (dir.x > 0 && dir.y > 0) //rightup facing
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) //rightdown facing
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0) //leftup facing
        {
            rotation.z = -270f;
        }
        else if (dir.x < 0 && dir.y < 0) //leftdown facing
        {
            rotation.z = -180f;
        }
        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        //ref script from collider and deal damage using TakeDamage()
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); //use currentDamage in case of dmg multipliers
            ReducePierce();
        }
    }

    void ReducePierce()  //destroy projectile when hitting x amount of times/ pierce reaches 0
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
