using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[CreateAssetMenu(fileName = "WeaponScriptableObj", menuName = "ScriptableObjs/Weapons")]
public class WeaponScriptableObj : ScriptableObject
{

    //weapon base stats //jj
    [SerializeField]
    float damage;
    public float Damage { get => damage; set => damage = value; }

    [SerializeField]
    float speed;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration { get => cooldownDuration; set => cooldownDuration = value; }

    [SerializeField]
    int pierce;
    public int Pierce { get => pierce; private set => pierce = value; }

    [SerializeField]
    int weapon_id;
    public int weaponid { get => weapon_id; private set => weapon_id = value; }

    [SerializeField]
    GameObject prefab;
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    
    private string data = "";
    public Dictionary<int, Dictionary<string, string>> weaponProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();

    void Awake() {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/CSVs/weaponStats.csv");
        properties = new List<string>(reader.ReadLine().Split(','));

        data = reader.ReadLine();
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            weaponProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                weaponProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close(); 
        
        Damage = float.Parse(weaponProperties[weapon_id]["weaponAtk"]);
        Speed = float.Parse(weaponProperties[weapon_id]["weaponAtkSpd"]);
        CooldownDuration = float.Parse(weaponProperties[weapon_id]["cooldown"]);
    }

}
