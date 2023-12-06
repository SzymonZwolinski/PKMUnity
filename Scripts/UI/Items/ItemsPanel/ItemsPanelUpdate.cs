
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

	private void UpdateTextFields()
	{
		Title.text = currentItem?.name.ToString() ?? "";
		Description.text = currentItem?.Description ?? "---";
	}
}
