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
		FirstAttackBtn.GetComponent<Text>().text =
			$"{CurrentPlayerUnit.FirstAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.FirstAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.FirstAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.FirstAttack.Type}";

		SecondAttackBtn.GetComponent<Text>().text =
			$"{CurrentPlayerUnit.SecondAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.SecondAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.SecondAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.SecondAttack.Type}";

		ThirdAttackBtn.GetComponent<Text>().text =
			$"{CurrentPlayerUnit.ThirdAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.ThirdAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.ThirdAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.ThirdAttack.Type}";

		FourthAttackBtn.GetComponent<Text>().text =
			$"{CurrentPlayerUnit.FourthAttack.Name}\n" +
			$"Dmg: {(CurrentPlayerUnit.FourthAttack.Kind == AttackKind.Special ? CurrentPlayerUnit.FourthAttack.Damage.ToString() : "---")}\n" +
			$"Type: {CurrentPlayerUnit.FourthAttack.Type}";

	}
}
