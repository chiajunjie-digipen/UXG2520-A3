using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LevelGetter : MonoBehaviour
{
    // Start is called before the first frame update

    
    private string data = "";
    public Dictionary<int, Dictionary<string, float>> levelProperties = new Dictionary<int, Dictionary<string, float>>();
    List<string> properties = new List<string>();
    public int currentLevel = 1;
    public int playerHP;
    void Start()
    {   
        StreamReader reader = new StreamReader("Assets/CSVs/levels.csv");
        // reads properties
        properties = new List<string>(reader.ReadLine().Split(','));
        //foreach(string property in properties) {Debug.Log(property);}
        // stores level properties in accordance
        data = reader.ReadLine();
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            levelProperties.Add(int.Parse(dataList[0]), new Dictionary<string, float>());
            int counter = 0;
            foreach(string property in properties) {
                levelProperties[int.Parse(dataList[0])].Add(property, float.Parse(dataList[counter]));
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close();
        foreach(KeyValuePair<int, Dictionary<string, float>> attributes in levelProperties) {
            Debug.Log(attributes.Key);
            foreach(KeyValuePair<string, float> attribute in attributes.Value) {
                Debug.Log(attribute.Key + " " + attribute.Value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = (int)levelProperties[currentLevel]["playerHP"];
    }
}
