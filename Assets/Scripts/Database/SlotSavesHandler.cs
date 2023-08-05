using System;

    [Serializable]
	public class SlotSavesHandler
	{
        public GameSaveSlotSave gameSave;
        
        public SlotSavesHandler()
        { 
            gameSave = new GameSaveSlotSave();
        }
    }

    
    [Serializable]
    public class GameSaveSlotSave
    {
        public InventoryItemData[] inventoryItemsData;


        public GameSaveSlotSave()
        {
            inventoryItemsData = new InventoryItemData[5];
            for (int i = 0; i < inventoryItemsData.Length; i++)
            {
                inventoryItemsData[i] = new InventoryItemData(UnityEngine.Random.Range(0, 3), i, UnityEngine.Random.Range(0, 3));
            }
        }
    }
    [Serializable]
    public class InventoryItemData
    {
        public int index;
        public int xPos;
        public int yPos;

        public InventoryItemData(int index, int xPos, int yPos)
        {
            this.index = index;
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }

    [Serializable]
    public class SaveData
    {
        public string currentSave;
    }