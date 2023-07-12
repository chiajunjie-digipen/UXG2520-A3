using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GetDaValuez : MonoBehaviour
{
    // Start is called before the first frame update

    private string data = "";
    void Start()
    {
        StreamReader reader = new StreamReader("Assets/CSVs/itemEffects.csv");
        
        while (data != null){
            data = reader.ReadLine();
            Debug.Log(data.Split(',')[0]);
        }
        
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
