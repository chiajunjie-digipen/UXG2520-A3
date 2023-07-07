using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : WeaponController
{

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Attack();
        GameObject spawnedSpear = Instantiate(prefab);
        spawnedSpear.transform.position = transform.position;
        spawnedSpear.GetComponent<SpearBehaviour>().DirectionChecker(pm.lastMovedVector);
    }
}
