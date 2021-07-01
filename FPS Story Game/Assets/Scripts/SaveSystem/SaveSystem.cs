using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void Save(Player player) {

        Save save = new Save(player);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fStream = new FileStream(Application.persistentDataPath + "/Save.svf", FileMode.Create);

        bf.Serialize(fStream, save);
        fStream.Close();

    }

    public static Save Load() {

        string path = Application.persistentDataPath + "/Save.svf";

        if(File.Exists(path)) {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fStream = new FileStream(path, FileMode.Open);
            Save save = (Save)bf.Deserialize(fStream);

            fStream.Close();

            return save;

        } else {

            Debug.LogError("Save File not found in path: " + path);

            return null;

        }

    }
    
}