using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "CharacterScriptableObj", menuName = "ScriptableObjs/Character")]
public class CharacterScriptableObj : ScriptableObject
{
    [SerializeField]
    GameObject startingWeapon;
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }

    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    [SerializeField]
    float recovery;
    public float Recovery { get => recovery; set => recovery = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private string data = "";
    public Dictionary<int, Dictionary<string, string>> playerProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();

    void Awake() {
        StreamReader reader = new StreamReader("Assets/CSVs/levels.csv");
        properties = new List<string>(reader.ReadLine().Split(','));
        

        data = reader.ReadLine();
        Debug.Log(data);
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            playerProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                playerProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close();
        Debug.Log(playerProperties.Count);
        MaxHealth = float.Parse(playerProperties[0]["playerHP"]);
        Recovery = float.Parse(playerProperties[0]["recovery"]);
        MoveSpeed = float.Parse(playerProperties[0]["playerMoveSpd"]);
    }
}
