using Newtonsoft.Json;
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
        var jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        var playerTeam = playerObject.GetComponentInChildren<UserTeam>();
        var playerCurrTeam = Newtonsoft.Json.JsonConvert.SerializeObject(playerTeam.Team, Newtonsoft.Json.Formatting.None, jsonSettings);
        var playerCurrStorage = Newtonsoft.Json.JsonConvert.SerializeObject(playerTeam.Storage, Newtonsoft.Json.Formatting.None, jsonSettings);

        var playerItems = Newtonsoft.Json.JsonConvert.SerializeObject(playerObject.GetComponentInChildren<PlayerItems>().Items, Newtonsoft.Json.Formatting.None, jsonSettings);
        var playerPosition = JsonUtility.ToJson(GameObject.FindGameObjectWithTag("PlayerModel").transform.position);
        

        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json"), playerCurrTeam);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"), playerCurrStorage);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerItems.json"), playerItems);
        await File.WriteAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerPosition.json"), playerPosition);
   }  

    public static async Task<LoadGameStatus> LoadGameDataAsync()
    {
        var playerCurrTeam = Newtonsoft.Json.JsonConvert.DeserializeObject(await File.ReadAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json")));
        var playerCurrStorage = Newtonsoft.Json.JsonConvert.DeserializeObject(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"))));
        var playerItems = Newtonsoft.Json.JsonConvert.DeserializeObject(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerItems.json"))));
        var playerPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<Vector3>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerPosition.json"))));


        if (playerCurrTeam is null
            || playerCurrStorage is null
            || playerItems is null
            || playerPosition == null)
        {
            return LoadGameStatus.CorruptedData;
        }

        SceneChanger.StartGame();
        SceneChanger.SaveShouldBeLoaded = true;

        return LoadGameStatus.Success;
    }

    public static async Task<LoadGameStatus> LoadSaveSetParameters()
    {
        var jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        var playerCurrTeam = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaseUnit>>(await File.ReadAllTextAsync(Path.Combine(Application.persistentDataPath, "/PlayerTeam.json")), jsonSettings);
        var playerCurrStorage = Newtonsoft.Json.JsonConvert.DeserializeObject<List<BaseUnit>>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerStorage.json"))), jsonSettings);
        var playerItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ItemBase>>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerItems.json"))), jsonSettings);
        var playerPosition = Newtonsoft.Json.JsonConvert.DeserializeObject<Vector3>(await File.ReadAllTextAsync((Path.Combine(Application.persistentDataPath, "/PlayerPosition.json"))), jsonSettings);

        if (playerCurrTeam is null
           || playerCurrStorage is null
           || playerItems is null
           || playerPosition == null)
        {
            return LoadGameStatus.CorruptedData;
        }

        var playerObject = GameObject.FindGameObjectWithTag("Player");

        var playerTeam = playerObject.GetComponentInChildren<UserTeam>();
        playerTeam.Team = playerCurrTeam;
        playerTeam.Storage = playerCurrStorage;

        playerObject.GetComponentInChildren<PlayerItems>().Items = playerItems;

        var playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        var playerCharacterController = playerModel.GetComponent<CharacterController>();
        playerCharacterController.enabled = false;

        playerModel.transform.position = playerPosition;

        playerCharacterController.enabled = true;

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
