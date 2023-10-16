using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeamHandler : MonoBehaviour
{
	public Text PlayerTeamUnitNameBar;
	public Text PlayerTeamUnitHealtBar;

	private GameObject Player;
	private BaseUnit CurrentPlayerUnit;

	private void OnEnable()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		var userTeam = Player.GetComponentInChildren<UserTeam>();

		CurrentPlayerUnit = userTeam.Team.FirstOrDefault();

		UpdateNameBar();
		UpdateHealtBar();
	}

	private void UpdateNameBar()
	{
		
		PlayerTeamUnitNameBar.text = CurrentPlayerUnit.Name;
	}

	private void UpdateHealtBar()
	{
		PlayerTeamUnitHealtBar.text = $"{CurrentPlayerUnit.HealthPoints}/{CurrentPlayerUnit.MaxHealthPoints}";
	}
}
