
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPanelUpdate : MonoBehaviour
{
	public Text Title;
	public Text Description;

	private ItemBase currentItem;
	private PlayerItems playerItems;

	private void OnEnable()
	{
		playerItems = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<PlayerItems>();

		currentItem = playerItems.GetFirstItem();
		UpdateTextFields();
	}

	public void NextItem()
	{
		currentItem = playerItems.NextItem();
		UpdateTextFields();
	}

	public void PrevItem()
	{
		currentItem = playerItems.PreviousItem();
		UpdateTextFields();
	}

	public void UseItem()
	{

		var playerUnit = GameObject
			.FindGameObjectWithTag("Player")
			.GetComponentInChildren<UserTeam>()
			.Team
			.FirstOrDefault();
		var enemy = GameObject
            .FindGameObjectWithTag("Enemy")
            .GetComponent<UnitTypeMarker>()
            .UnitType;

        var hasItemUseageSucceded = currentItem.TryToUseItem(playerUnit);

		if (hasItemUseageSucceded)
		{
			FightHandler.EnemyOnlyAttack(enemy, playerUnit);
			return;
		}
		ItemUseFail();
	}

	private void UpdateTextFields()
	{
		ResetDescColour();

        Title.text = currentItem?.name.ToString() ?? "";
		Description.text = currentItem?.Description ?? "---";
	}

	private void ItemUseFail()
	{
		Description.text = "Item cannot be used";
		Description.color = Color.red;
	}

	private void ResetDescColour()
		=> Description.color = Color.black;
}
