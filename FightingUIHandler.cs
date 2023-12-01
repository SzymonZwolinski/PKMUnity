using UnityEngine;

public class FightingUIHandler : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject FightingPanel;
    public GameObject ItemPanel;

    private GameObject CurrentActivePanel;

	public void ActivateFightingPanel()
    {
        MainPanel.SetActive(false);
        FightingPanel.SetActive(true);

        CurrentActivePanel = FightingPanel;
    }

    public void ActivateItemPanel()
    {
		MainPanel.SetActive(false);
		ItemPanel.SetActive(true);

		CurrentActivePanel = ItemPanel;
	}    

    public void ActivateMainPanel()
    {        
        CurrentActivePanel.SetActive(false);
        MainPanel.SetActive(true);

        CurrentActivePanel = MainPanel;
    }

}
