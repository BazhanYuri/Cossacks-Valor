using Zenject;


public interface IDatabase : IInitializable
{
    public SaveData CurrentSave { get; }
    public SlotSavesHandler CurrentSlot { get;}

    void SaveCurrentSave();
    public void SetCurrentSave(string saveName);
    void Save(string fileName, object save);
    object Load(string fileName);
}
