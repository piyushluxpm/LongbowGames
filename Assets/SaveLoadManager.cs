using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    
    private void Start()
    {
         LoadScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }
    }

    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open(Application.persistentDataPath + "/surv_ScoreContainer.dat", FileMode.Create);
        ScoreContainer sc = new ScoreContainer();
        sc.score = ScoreManager.score;
        bf.Serialize(fileStream, sc);
        fileStream.Close();

    }

    public void LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/surv_ScoreContainer.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.persistentDataPath + "/surv_ScoreContainer.dat", FileMode.Open);
            ScoreContainer sc = (ScoreContainer)bf.Deserialize(fileStream);
            fileStream.Close();
            ScoreManager.score = sc.score;            

        }
    }
}
[Serializable]
public class ScoreContainer
{
    public int score;
}