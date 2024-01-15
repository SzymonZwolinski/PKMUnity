using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveHandler : MonoBehaviour
{
    public GameObject LoadGameButton;
    public GameObject LoadGameErrorPanel;

    private void Start()
    {
        LoadGameButton.SetActive(SaveHandler.DoEverySaveFileExists());;
    }

    
    public void StartGame()
    {
        SceneChanger.StartGame();
    }

    public async void LoadGameAsync()
    {
        var loadResponse = await SaveHandler.LoadGameDataAsync();

        if(loadResponse == LoadGameStatus.Success) 
        {
            return;
        }
        if(loadResponse == LoadGameStatus.CorruptedData) 
        {
            LoadGameErrorPanel.SetActive(true);
            LoadGameErrorPanel.GetComponentInChildren<Text>().text = "Load data corrupted!";
            return;
        }
        if (loadResponse == LoadGameStatus.FileNotFound)
        {
            LoadGameErrorPanel.SetActive(true);
            LoadGameErrorPanel.GetComponentInChildren<Text>().text = "Load data not found!";
            return;
        }
    }   

      public void CloseErrorPanel()
    {
        LoadGameErrorPanel.SetActive(false);
    }
}
