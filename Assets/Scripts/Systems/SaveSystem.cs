using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LavaProject.Inventory;
using UnityEngine;

namespace LavaProject.Systems
{
    public class SaveSystem
    {
        private InventoryEndless _inventory;

        public SaveSystem(InventoryEndless inventory)
        {
            _inventory = inventory;
        }
        
        public void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream file = File.Create(Application.persistentDataPath + "/SaveData.dat");
            InventorySaveData saveData = new InventorySaveData();
            foreach (var item in _inventory.GetAllItems())
            {
                saveData.Data.Add(item.Info.Id, item.State.Amount);
            }
            bf.Serialize(file, saveData);
            file.Close();
            Debug.Log("Game data saved!");
        }

        public void LoadData()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/SaveData.dat", FileMode.Open);
                InventorySaveData saveData = (InventorySaveData)bf.Deserialize(file);
                file.Close();
                foreach (var item in saveData.Data)
                {
                    _inventory.Add(this, item.Key, item.Value);
                }
                Debug.Log("Game data loaded!");
            }
        }
        
        public static void ResetSave()
        {
            if (File.Exists(Application.persistentDataPath + "/SaveData.dat"))
            {
                File.Delete(Application.persistentDataPath + "/SaveData.dat");
                Debug.Log("Data reset complete!");
            }
            else
            {
                Debug.LogError("No save data to delete.");
            }
        }
    }
}