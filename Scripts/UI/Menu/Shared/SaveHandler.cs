using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public static class SaveHandler
{
   public static async Task SaveGameDataAsync()
   {
        var playerObject = GameObject.FindGameObjectWithTag("Player");

        var playerTeam = playerObject.GetComponentInChildren<UserTeam>();
        var playerCurrTeam = JsonUtility.ToJson(playerTeam.Team);
        var playerCurrStorage = JsonUtility.ToJson(playerTeam.Storage);

        var playerItems = JsonUtility.ToJson(playerObject.GetComponentInChildren<PlayerItems>().Items);
        
        var playerPosition = JsonUtility.ToJson(GameObject.FindGameObjectWithTag("PlayerModel").transform.position);

        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json"), playerCurrTeam);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"), playerCurrStorage);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerItems.json"), playerItems);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerPosition.json"), playerPosition);
        Debug.Log(Application.persistentDataPath);
    }  

    public static async Task<LoadGameStatus> LoadGameDataAsync()
    {
        if(!DoEverySaveFileExists())
        {
            return LoadGameStatus.FileNotFound;
        }

        var playerCurrTeam = JsonUtility.FromJson<List<BaseUnit>>(await File.ReadAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json")));
        var playerCurrStorage = JsonUtility.FromJson<List<BaseUnit>>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"))));
        var playerItems = JsonUtility.FromJson<List<ItemBase>>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerItems.json"))));
        var playerPosition = JsonUtility.FromJson<Vector3>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerTeam.json"))));

        if(playerCurrTeam.Any() || playerCurrTeam is null 
            || playerCurrStorage.Any() || playerCurrStorage is null
            || playerItems.Any() || playerItems is null
            || playerPosition == null)
        {
            return LoadGameStatus.CorruptedData;
        }

        SceneChanger.StartGame();

        var playerObject = GameObject.FindGameObjectWithTag("Player");

        var playerTeam = playerObject.GetComponentInChildren<UserTeam>();
        playerTeam.Team = playerCurrTeam;
        playerTeam.Storage = playerCurrStorage;

        playerObject.GetComponent<PlayerItems>().Items = playerItems;

        playerObject.transform.position = playerPosition;

        return LoadGameStatus.Success;
    }

    public static bool DoEverySaveFileExists()
    {
        var playerTeamFile = File.Exists(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json"));
        var playerStorageFile = File.Exists(Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"));
        var playerItemsFile = File.Exists(Path.Combine(Application.persistentDataPath, "/PlayerItems.json"));
        var playerPostionFile = File.Exists(Path.Combine(Application.persistentDataPath, "/PlayerPosition.json"));

        if(playerTeamFile && playerStorageFile && playerItemsFile && playerPostionFile)
        {
            return true;
        }

        return false;
    }
}
