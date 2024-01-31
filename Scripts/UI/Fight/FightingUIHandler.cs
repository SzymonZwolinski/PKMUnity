using UnityEngine;

public class FightingUIHandler : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject FightingPanel;
    public GameObject ActionPanel;
    public GameObject ItemsPanel;
    public GameObject TeamPanel;

    private GameObject CurrentActivePanel;

	public void ActivateFightingPanel()
    {
        MainPanel.SetActive(false);
        FightingPanel.SetActive(true);

        CurrentActivePanel = FightingPanel;
    }

    public void ActivateActionPanel()
    {
		MainPanel.SetActive(false);
		ActionPanel.SetActive(true);

		CurrentActivePanel = ActionPanel;
	}    

    public void ActivateMainPanel()
    {        
        CurrentActivePanel.SetActive(false);
        MainPanel.SetActive(true);

        CurrentActivePanel = MainPanel;
    }

    public void ActivateItemsPanel()
    {
        CurrentActivePanel.SetActive(false);
        ItemsPanel.SetActive(true);

        CurrentActivePanel = ItemsPanel;
    }

    public void ActivateTeamPanel()
    {
        MainPanel.SetActive(false);
        TeamPanel.SetActive(true);

        CurrentActivePanel = TeamPanel;
    }
}
