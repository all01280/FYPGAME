using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlTypes;
using System;

public class SaveAndLoad : MonoBehaviour
{
    public Vector3 savedLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
    }
    void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerInfo data = new PlayerInfo();
        data.xPos = this.gameObject.transform.position.x;
        data.yPos = this.gameObject.transform.position.y;
        data.zPos = this.gameObject.transform.position.z;
        savedLocation = this.gameObject.transform.position;

        bf.Serialize(file, data);
        file.Close();
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerInfo data = (PlayerInfo)bf.Deserialize(file);
            file.Close();

            this.gameObject.transform.position = new Vector3(data.xPos, data.yPos, data.zPos);
        }
    }

    private void OnTrifferEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SavePoint"))
        {
            Save();
            Debug.Log("Saved from SavePoint");
        }
    }
}

[Serializable]
public class PlayerInfo
{
    public float xPos;
    public float yPos;
    public float zPos;
}
