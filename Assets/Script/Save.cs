using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save {

    //Should be called when a level is completed

	internal static void SaveNow()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        if (!Directory.Exists(Application.dataPath + "/Save Data"))
        {
            Directory.CreateDirectory(Application.dataPath + "/Save Data");
        }

        using (FileStream fileStream = new FileStream(Application.dataPath + "/Save Data/" + Load.loadPath, FileMode.Create, FileAccess.Write))
        {
            for (int i = 0; i < GameManager.levels.Length; i++)
            {
                binaryFormatter.Serialize(fileStream, GameManager.levels[i]);
            }
        }
    }
}
