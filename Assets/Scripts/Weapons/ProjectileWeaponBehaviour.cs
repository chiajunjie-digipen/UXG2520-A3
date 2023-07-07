using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    // base script for projectiles (bow and spear)

    protected Vector3 direction;
    public float destroyAfterSeconds;

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
}
