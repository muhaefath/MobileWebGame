using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem  {

    public static void SavePlayer(AllGameManager player) {

        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path , FileMode.Create);

        PlayerData data = new PlayerData(player);

        formater.Serialize(stream,data);

        Debug.Log(data.RukoSelect[0]);
        Debug.Log(data.DayCount);
        stream.Close();
    }


    public static PlayerData loadPlayer() {

        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerData data = formater.Deserialize(stream) as PlayerData;

            Debug.Log(data.RukoSelect[0]);
            Debug.Log(data.DayCount);
            stream.Close();

            return data;
        }
        else {
            Debug.LogError("save not found");
            return null;
        }

    }
}
