using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void SaveGame(Level lvl)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file,lvl);
        file.Close();
        Debug.Log("Saved");
    }
}
