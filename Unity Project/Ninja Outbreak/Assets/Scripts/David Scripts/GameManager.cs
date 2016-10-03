using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour {
    public int currentSave;
    public SaveData save;

    void Start() {
        DontDestroyOnLoad(transform.gameObject);
    }


    void Update() {

    }
    public void SaveGame() {
        print("save " + currentSave );
        save.lastSave = currentSave;
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + currentSave.ToString() + ".xml", FileMode.Create);
        serializer.Serialize(stream, save);
        stream.Close();
    }
    public void LoadGame(int saveNumber) {
        if(File.Exists(Application.dataPath + "/Saves/save_file" + saveNumber.ToString() + ".xml")) {
            currentSave = saveNumber;
            save.lastSave = saveNumber;
            print("load " + currentSave);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + saveNumber.ToString() + ".xml", FileMode.Open);
            save = serializer.Deserialize(stream) as SaveData;
            stream.Close();
        }
        else {
            print("No file");
        }

    }
    public void ContinueGame() {
        currentSave = save.lastSave;
        print("Continue " + save.lastSave);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + save.lastSave.ToString() + ".xml", FileMode.Open);
        save = serializer.Deserialize(stream) as SaveData;
        stream.Close();
    }
}
[System.Serializable]
public class SaveData {
    public int lastSave;
    public int scene;
    public int checkPoint;
}
