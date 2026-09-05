using System;
using System.IO; 
using UnityEngine;

public class GenFiles_Main 
{
    
    public static void GenFile(string path)
    {

        try
        {
            File.Create(path).Close(); 
        } 
        catch (Exception FileGenFail)
        {
            Debug.Log($"[:3] {FileGenFail}");
        } 

    }

    public static void GenDirectory(string path)
    {

        try
        {
            Directory.CreateDirectory(path); 
        }
        catch (Exception DirectoryFailGen)
        {
            Debug.Log($"[:3] {DirectoryFailGen}");
        } 

        
    }

}



public class RosaryFileSer : MonoBehaviour
{
    public static int testnumber = 0;
    public static string Testname = "RosaryMusicalOrchesta.CS"; 

    private void Awake()
    {
        SaveFileStart.SaveSerial(); 
        SaveManager.WriteJson( SaveFileStart.saveFilePath,testnumber,Testname); 
        SaveManager.LoadData (SaveFileStart.saveFilePath);
    }

}

public class SaveFileStart
{
            //Upath: Universal File Path in application context
        public static string Upath = AppContext.BaseDirectory; 

        //UnityPath: Universal File Path in unity context
            //All platforms or device
        public static string UnityPath = Application.persistentDataPath; 
            //AssetFolder
        public static string UnityPathAssets = Application.dataPath; 
            //readonly Directory
        public static string UnityPathRO = Application.streamingAssetsPath; 

        //SaveDirectoyName
        public static string SaveJsonName = "StringSaveNameData.json"; 

        //Directory and File Json Paths
        public static string DirectoryPath = Path.Combine(UnityPathAssets, "RMO_SaveFilesDirectory");
        public static string saveFilePath = Path.Combine(DirectoryPath, SaveJsonName);

    public static void SaveSerial()
    {

  
        if (!Directory.Exists(DirectoryPath))
        {
            GenFiles_Main.GenDirectory(DirectoryPath); 
        }

        if (!File.Exists(saveFilePath))
        {
            GenFiles_Main.GenFile(saveFilePath);
        }
    }
}

[System.Serializable]
public class GameData
{
    public int score; 
    public string playername; 
}

public class SaveManager : MonoBehaviour
{

    public static void WriteJson(string path, int score, string Pname)
    {
        GameData Serdata = new GameData();
        Serdata.score = score; 
        Serdata.playername =Pname ;

        string jsonstring = JsonUtility.ToJson(Serdata, true); 

        File.WriteAllText(path,jsonstring);




       
    }

    public static GameData LoadData( string path)
    {

        if (!File.Exists(path))
        {
            return  new GameData {score = 0, playername = "RMO"};
        }
        string jsonDeserialize = File.ReadAllText(path); 
        
        GameData ChargeData = JsonUtility.FromJson<GameData>(jsonDeserialize); 

        return ChargeData; 

    }
}
