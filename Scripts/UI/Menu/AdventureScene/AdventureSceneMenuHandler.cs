using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AdventureSceneMenuHandler : MonoBehaviour
{
    public GameObject MenuCanva;

    private void FixedUpdate()
    {
        ShowOrHideMenu();
    }

    public async void SaveGameAsync()
    {
        await SaveHandler.SaveGameDataAsync();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ShowOrHideMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuCanva.SetActive(!MenuCanva.activeSelf);
        }
    }
}
