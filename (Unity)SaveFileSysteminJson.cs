using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

namespace RMO_SaveFileLibrary
{
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
        //Remember put all your Starting files here:
        SaveFileStart.SaveSerial(); 
        SaveManager.WriteJson( SaveFileStart.saveFilePath, SaveFileStart.TempsaveFilePath,testnumber,Testname); 
        Items_Serial.SaveItem_Json(SaveFileStart.ItemList,SaveFileStart.TempItems); 
        SaveManager.LoadData (SaveFileStart.saveFilePath);

        //Objects are not here for tecnical reazons alreary serialize
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

            //temp

        /// <NOTE>
        /// 
        /// If the game DO NOT use extra Threads: you can use only the TempJson has universal source of Serialization
        /// 
        /// if not: use for each file diferent paths
        /// </:3>
        public static string TempJson = "StringSaveNameData.temp"; 

        public static string TempItems = "ItemsSaveNameData.temp"; 

            //json
        public static string SaveJsonName = "StringSaveNameData.json"; 

        //Directory and File Json Paths
        public static string DirectoryPath = Path.Combine(UnityPath, "RMO_SaveFilesDirectory");

        public static string ItemList = Path.Combine(DirectoryPath, "ItemList");
        public static string saveFilePath = Path.Combine(DirectoryPath, SaveJsonName);
        //TempFile path
        public static string TempsaveFilePath = Path.Combine (DirectoryPath, TempJson); 
        public static string TempSaveItemsPath = Path.Combine (DirectoryPath, TempItems);

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
    

    public static void WriteJson(string path, string temppath, int score, string Pname) //has argument: each player element need to be save
    {
        GenFiles_Main.GenFile(SaveFileStart.TempJson);
        GameData Serdata = new GameData();
        Serdata.score = score; 
        Serdata.playername =Pname ;
        
        string jsonstring = JsonUtility.ToJson(Serdata, true); 

        File.WriteAllText(temppath,jsonstring);

        if (File.Exists(path))
        {
            File.Delete(path); 
        }

        File.Move(temppath,path); 
       
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


[System.Serializable]
public struct Item_Structure
{
    //Make Sure Struct Data Type Arguments are NOT Static, they supose to be Abstract (They are Abstract by default)
    public  string Item_name; 
    public  Int64 Item_ID; 
    public  bool active; 
}

public class ItemWrapper
{
    public Item_Structure[] items; 
}

public class Items_Serial : MonoBehaviour
{

    public static List <Item_Structure> ItemList = new List<Item_Structure>(); 

    //Example of how to add and create objects and add it to List<t>
    public static void TestObject_Encapsule()
    {
        Item_Structure testobject = new Item_Structure(); 
        testobject.Item_name = "Testobject.UnityObject";
        testobject.Item_ID = 7; 
        testobject.active = false; 
        
        ItemList.Add(testobject); 
        //and make serialization using SaveITem_Json Method.

    }
    //End Of: Example of how to add and create objects and add it to List<t>
    public static void SaveItem_Json(string path, string temppath) //Add all elements need to be save has array
    {
        GenFiles_Main.GenFile(path); 
        ItemWrapper SerialList = new ItemWrapper(); 
        SerialList.items = ItemList.ToArray();
        
        string convert_Json = JsonUtility.ToJson(SerialList, true);

        File.WriteAllText(temppath,convert_Json);

        if (File.Exists(path))
        {
            File.Delete(path); 
        }

        File.Move(temppath,path); 

    }

    public static Items_Serial LoadSaveItems(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("[3] Game objects don't load, game is closeing"); 
            #if UNITY_EDITOR 
            UnityEditor.EditorApplication.isPlaying = false; 
            #else 
            Application.Quit();
            #endif
        }

        string JsonContent = File.ReadAllText(path); 

        ItemWrapper SList = JsonUtility.FromJson<ItemWrapper>(JsonContent); 

        ItemList.Clear(); 

        if (SList != null && SList.items != null)
        {
            ItemList = new List<Item_Structure>(SList.items);
        }


        return null; 

    }

    //public static void 

}
}
