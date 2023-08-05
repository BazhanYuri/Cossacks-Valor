using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class DataBase : IDatabase, IInitializable
{
    private SaveData _saveHandler;

    public SaveData CurrentSave => _saveHandler;
    public SlotSavesHandler CurrentSlot { get; set; }

    public bool IsHaveSave { get; private set; }


    public void Initialize()
    {
        _saveHandler = Load("saveHandler") as SaveData;
        if (_saveHandler == null)
        {
            _saveHandler = new SaveData();
            Save("saveHandler", _saveHandler);
        }
        CurrentSlot = Load(_saveHandler.currentSave) as SlotSavesHandler;
        if (CurrentSlot == null)
        {
            CurrentSlot = new SlotSavesHandler();
        }
    }

    public void SaveCurrentSave()
    {
        Save("saveHandler", _saveHandler);
    }
    public void SetCurrentSave(string saveName)
    {
        _saveHandler.currentSave = saveName;
        Save("saveHandler", _saveHandler);
    }
    public object Load(string fileName)
    {
        object newSave = SerializationManager.Load(Application.persistentDataPath + "/saves/" + fileName + ".save");

        return newSave;
    }
    public void Save(string fileName, object save)
    {
        SerializationManager.Save(fileName, save);
    }
}


