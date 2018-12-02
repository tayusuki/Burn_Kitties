using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Load : MonoBehaviour {


    internal static string loadPath = "save.dat";
    public string LevelSelectName;

    void Awake()
    {
        if (!File.Exists(Application.dataPath + "/Save Data/" + loadPath))
        {
            gameObject.SetActive(false);
        }
    }

	public void OnClick () {
        LoadNow();
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelSelectName);

	}

    void LoadNow()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = new FileStream(Application.dataPath + "/Save Data/" + loadPath, FileMode.Open, FileAccess.Read))
        {
            for (int i = 0; i < GameManager.levels.Length; i++)
            {
                GameManager.levels[i] = (bool)binaryFormatter.Deserialize(fileStream);
            }
        }
    }
}
