
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveSystem
{
 public static void SaveGame (Ball ball)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.fun";
        Debug.Log("kayıtedildi");
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(ball);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame()
    {
        string path = Application.persistentDataPath + "/game.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not Found in" + path);
            return null;
        }
    }
}
