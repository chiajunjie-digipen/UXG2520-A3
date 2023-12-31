using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.IO;

public class MultiplierHandler : MonoBehaviour
{
    // jj
    private string data = "";
    public Dictionary<int, Dictionary<string, string>> multiplierProperties = new Dictionary<int, Dictionary<string, string>>();
    List<string> properties = new List<string>();
    int level;
    void Start()
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/CSVs/levels.csv");
        properties = new List<string>(reader.ReadLine().Split(','));
        data = reader.ReadLine();
        
        while(data != null) {
            List<string> dataList = new List<string>(data.Split(','));
            multiplierProperties.Add(int.Parse(dataList[0]), new Dictionary<string, string>());
            int counter = 0;
            foreach(string property in properties) {
                multiplierProperties[int.Parse(dataList[0])].Add(property, dataList[counter]);
                counter++;
            }
            data = reader.ReadLine();
        }
        reader.Close(); 
        
    }

    void Update()
    {
        
    }
}
