using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void Save(Player player) {

        var save = new Save(player);
        var bf = new BinaryFormatter();
        var fStream = new FileStream(Application.persistentDataPath + "/Save.svf", FileMode.Create);

        bf.Serialize(fStream, save);
        fStream.Close();

    }

    public static Save Load() {

        var path = Application.persistentDataPath + "/Save.svf";

        if(File.Exists(path)) {

            var bf = new BinaryFormatter();
            var fStream = new FileStream(path, FileMode.Open);
            var save = (Save)bf.Deserialize(fStream);

            fStream.Close();

            return save;

        }
        //Debug.LogError("Save File not found in path: " + path);
        return null;
    }
}