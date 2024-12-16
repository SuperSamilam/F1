using DataSpace;
using SaveSystemSpace;

public class DataPersistanceManager
{
    GameData? data;

    public void NewGame(string name)
    {
        data = new GameData(name);
        
        SaveSystem.WriteData(data);
        // LoadGame(name);
    }

    public void LoadGame(string name)
    {
        data = SaveSystem.loadData(name);

        if (data == null)
            throw new ArgumentNullException();

        foreach (var dataManager in InterfaceFinder.dataPersistanceRegistry)
        {
            dataManager.loadData(data);
        }
        SaveGame();
    }

    public void SaveGame()
    {
        if (data == null)
            throw new ArgumentNullException();

        foreach (var dataManager in InterfaceFinder.dataPersistanceRegistry)
        {
            dataManager.saveData(data);
        }
        SaveSystem.WriteData(data);
    }
}