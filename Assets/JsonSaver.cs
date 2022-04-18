using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using UnityEngine;

public class JsonSaver
{
    public void SaveToFile(int[,] field, int lvl)
    {
        JObject _fieldObj = new JObject();
        JArray rowArray = new JArray();
        
        for (int i = 0; i < field.GetLength(1); i++)
        {
            JObject rowObj = new JObject();
            string row = string.Empty;
            for (int j = 0; j < field.GetLength(0); j++)
            {
                row += ($"{field[j, i]} ");
            }
            rowArray.Add(row);
        }

        _fieldObj["Field"] = rowArray;

        string json = _fieldObj.ToString();
        File.WriteAllText($"{Application.dataPath}\\Level{lvl}.json",json);
    }

}
