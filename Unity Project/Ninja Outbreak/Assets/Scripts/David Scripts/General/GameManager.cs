using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class GameManager : MonoBehaviour {
    public int currentSave;
    public SaveData save;
    public Text[] saveNames;
    public Text[] startSaveNames;
    public Text nameInput;
    public GameObject playerPref;
    public List<Transform> checkpoints = new List<Transform>();
    private Transform player;
    
    

    void Start() {

        DontDestroyOnLoad(transform.gameObject);
        for (int a = 0; a < 3; a++) {
            if (File.Exists(Application.dataPath + "/Saves/save_file" + a.ToString() + ".xml")) {
                XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
                FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + a.ToString() + ".xml", FileMode.Open);
                save = serializer.Deserialize(stream) as SaveData;
                saveNames[a].text += save.name;
                startSaveNames[a].text += save.name; 
                stream.Close();
            }
            else {
                saveNames[a].text = "empty save";
                startSaveNames[a].text = "empty save";
            }
        }
    }


    void Update() {

    }
    public void NewSave(int saveSlot) {
        print("NewSave");
        SaveData newSave = new SaveData();
        currentSave = saveSlot;
        newSave.name = nameInput.text;
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + saveSlot.ToString() + ".xml", FileMode.Create);
        serializer.Serialize(stream, newSave);
        stream.Close();

        LoadGame(currentSave);

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
            save.lastSave = currentSave ;

            print("load " + currentSave);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
            FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + saveNumber.ToString() + ".xml", FileMode.Open);
            save = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            SceneManager.LoadScene(save.scene);
           
        }
        else {
            print("No file");
        }

    }
    /*public void ContinueGame() {
        currentSave = save.lastSave;
        print("Continue " + save.lastSave);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(Application.dataPath + "/Saves/save_file" + save.lastSave.ToString() + ".xml", FileMode.Open);
        save = serializer.Deserialize(stream) as SaveData;
        stream.Close();
    }
    */
    public void OnSceneLoad() {
        print("Looking for check");
        int a = 0;
        foreach(Transform check in checkpoints) {
            if(checkpoints[a].GetComponent<CheckPoint>().myCheckPoint == save.checkPoint) {
                player = (Transform)Instantiate(playerPref, checkpoints[a].position, Quaternion.identity).transform;
                return;
            }
            else {
                a++;
            }

        }
    }
}
[System.Serializable]
public class SaveData {
    public int lastSave;
    public int scene;
    public int checkPoint;
    public string name;
}
