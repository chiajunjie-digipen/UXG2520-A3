using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WeaponController : MonoBehaviour //jj
{
    [Header("Weapon Stats")]
    public WeaponScriptableObj weaponData;
    float currentCooldown;

    protected PlayerMovement pm;
    // for weapon controllers and stuff

    private string data = "";
    public Dictionary<int, Dictionary<string, string>> enemyProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/CSVs/weaponStats.csv");
        properties = new List<string>(reader.ReadLine().Split(','));

        data = reader.ReadLine();
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            enemyProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                enemyProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close(); 
        
        weaponData.Damage = float.Parse(enemyProperties[weaponData.weaponid]["weaponAtk"]);
        weaponData.Speed = float.Parse(enemyProperties[weaponData.weaponid]["weaponAtkSpd"]);
        weaponData.CooldownDuration = float.Parse(enemyProperties[weaponData.weaponid]["cooldown"]);

        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration; //set cd to cd duration

    }

    // Update is called once per frame
    protected virtual void Update() //shar
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            Attack();
        } 
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
