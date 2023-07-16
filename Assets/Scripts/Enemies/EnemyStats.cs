using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObj enemyData;

    //current stats
    public float currentMoveSpeed;
    float currentHealth;
    float currentDamage;
    public int enemyId;
    List<string> properties = new List<string>();

    private string data = "";
    public Dictionary<int, Dictionary<string, float>> enemyProperties = new Dictionary<int, Dictionary<string, float>>();
    float XPdrop;

    void Awake()
    {
        /*currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;*/

        enemyId = enemyData.enemyid;
        
        StreamReader reader = new StreamReader("Assets/CSVs/enemyStats.csv");
        properties = new List<string>(reader.ReadLine().Split(','));

        data = reader.ReadLine();
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            enemyProperties.Add(int.Parse(dataList[0]), new Dictionary<string, float>());
            int counter = 0;
            foreach(string property in properties) {
                enemyProperties[int.Parse(dataList[0])].Add(property, float.Parse(dataList[counter]));
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close();

        currentMoveSpeed = enemyProperties[enemyId]["enemyMoveSpd"];
        currentHealth = enemyProperties[enemyId]["enemyHP"];
        currentDamage = enemyProperties[enemyId]["enemyAtk"];



    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
