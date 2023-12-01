using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AttackPanelHandler : MonoBehaviour
{
	public Button FirstAttackBtn;
	public Button SecondAttackBtn;
	public Button ThirdAttackBtn;
	public Button FourthAttackBtn;

	private BaseUnit CurrentPlayerUnit;

	private void OnEnable()
	{
		var userTeam = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<UserTeam>();

		CurrentPlayerUnit = userTeam.Team.FirstOrDefault();

		UpdateButtons();
	}

	private void UpdateButtons()
	{
		FirstAttackBtn.GetComponentInChildren<Text>().text =
			CurrentPlayerUnit.FirstAttack is null ?
			"---" :
			$"{CurrentPlayerUnit.FirstAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.FirstAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.FirstAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.FirstAttack.Type}";

		SecondAttackBtn.GetComponentInChildren<Text>().text =
			CurrentPlayerUnit.SecondAttack is null ?
			"---" :
			$"{CurrentPlayerUnit.SecondAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.SecondAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.SecondAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.SecondAttack.Type}";

		ThirdAttackBtn.GetComponentInChildren<Text>().text =
			CurrentPlayerUnit.ThirdAttack is null ?
			"---" :
			$"{CurrentPlayerUnit.ThirdAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.ThirdAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.ThirdAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.ThirdAttack.Type}";

		FourthAttackBtn.GetComponentInChildren<Text>().text =
			CurrentPlayerUnit.FourthAttack is null ?
			"---" :
			$"{CurrentPlayerUnit.FourthAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.FourthAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.FourthAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.FourthAttack.Type}";

	}

	public void SelectAttack(Button clickedButton)
	{
		var enemy = GameObject
			.FindGameObjectWithTag("Enemy")
			.GetComponent<UnitTypeMarker>()
			.UnitType;
			
		if (clickedButton.Equals(FirstAttackBtn))
		{
			FightHandler.Attack(CurrentPlayerUnit.FirstAttack, CurrentPlayerUnit, enemy);
		}

		if (clickedButton.Equals(SecondAttackBtn))
		{
			FightHandler.Attack(CurrentPlayerUnit.SecondAttack, CurrentPlayerUnit, enemy);
		}

		if (clickedButton.Equals(ThirdAttackBtn))
		{
			FightHandler.Attack(CurrentPlayerUnit.ThirdAttack, CurrentPlayerUnit, enemy);
		}

		if (clickedButton.Equals(FourthAttackBtn))
		{
			FightHandler.Attack(CurrentPlayerUnit.FourthAttack, CurrentPlayerUnit, enemy);
		}

		Debug.Log("Attack should be executed");
	}
}
