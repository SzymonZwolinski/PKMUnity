using UnityEngine;

public class FightingUIHandler : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject FightingPanel;

    private GameObject CurrentActivePanel;

	public void ActivateFightingPanel()
    {
        MainPanel.SetActive(false);
        FightingPanel.SetActive(true);

        CurrentActivePanel = FightingPanel;
    }

    public void ActivateMainPanel()
    {        
        CurrentActivePanel.SetActive(false);
        MainPanel.SetActive(true);

        CurrentActivePanel = MainPanel;
    }

}
