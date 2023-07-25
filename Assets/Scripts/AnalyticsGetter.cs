using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class AnalyticsGetter : MonoBehaviour //jj
{
    //private string data = "";
    //public Dictionary<int, Dictionary<string, string>> resultProperties = new Dictionary<int, Dictionary<string, string>>();
    //List<string> properties = new List<string>();
    public TMP_Text analytics;

    // Start is called before the first frame update
    void Start()
    {
        analytics = GetComponent<TMP_Text>();
        string filePath = Path.Combine(Application.persistentDataPath, "saveData.csv");
        StreamReader sr = new StreamReader(filePath);
            string data = "";
            string chaser = "";
            while(data!=null){
                chaser = data;
                data = sr.ReadLine();
            }
        List<string> chaserList = new List<string>(chaser.Split(","));
        analytics.text = string.Empty;
        analytics.text += "Session ID: " + chaserList[0] + "\n";
        analytics.text += "Enemies Killed: " + chaserList[1] + "\n";
        analytics.text += "Time Spent: " + chaserList[2] + "\n";
        analytics.text += "XP Gained: " + chaserList[3] + "\n";
    }
}
