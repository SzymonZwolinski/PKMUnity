using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TeamHandler : MonoBehaviour
{
	private const string separator = " - ";
	private bool IsInventoryOpen = false;
    private List<BaseUnit> units;

    public GameObject TeamPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        units = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UserTeam>().Team;
        RefrestTeamPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            units = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UserTeam>().Team;

            IsInventoryOpen = !IsInventoryOpen;

            if(IsInventoryOpen)
            {
                OpenTeamPanel();
                return;
            }

            CloseTeamPanel();
        }
    }

    public void OpenTeamPanel()
    {
        TeamPanel.SetActive(true);

        RefrestTeamPanel();
	}

    public void RefrestTeamPanel()
    {
		for (int i = 0; i < 6; i++)
		{
			var slot = TeamPanel.transform.Find($"Team{i + 1}Slot").gameObject;
			SetSlotContent(i, slot);
		}
	}
    private void SetSlotContent(int position, GameObject slot)
    {

        if (units.Count > position && 
            units[position] is not null)
        {
            var moveDownBttn = slot.transform.Find("MoveDown");
            var moveUpBttn = slot.transform.Find("MoveUp");

            if(moveDownBttn != null &&
                units.Count-1 != position)
            {
                moveDownBttn.gameObject.SetActive(true);
            }

            if (moveUpBttn != null)
            {
                moveUpBttn.gameObject.SetActive(true); 
            }

            var unitInSlot = units[position];
            var nameField = slot.transform.Find("Name").GetComponent<Text>();
            var typesField = slot.transform.Find("Types").GetComponent<Text>(); 
            var hpField = slot.transform.Find("HP").GetComponent<Text>();

            var firstAttackField = slot.transform.Find("1Attack").GetComponent<Text>();
			var secondAttackField = slot.transform.Find("2Attack").GetComponent<Text>();
			var thirdField = slot.transform.Find("3Attack").GetComponent<Text>();
			var fourthField = slot.transform.Find("4Attack").GetComponent<Text>();

			nameField.text = unitInSlot.Name;
            typesField.text = $"{unitInSlot.FirstType} {(unitInSlot.SecondaryType.HasValue ? "|" : ' ') } {unitInSlot.SecondaryType}";
            hpField.text = $"{unitInSlot.HealthPoints} / {unitInSlot.MaxHealthPoints}";

            firstAttackField.text = $"{(unitInSlot.FirstAttack is not null ? $"{unitInSlot.FirstAttack.Name}{separator}{unitInSlot.FirstAttack.Type}" : ' ')}";
			secondAttackField.text = $"{(unitInSlot.SecondAttack is not null ? $"{unitInSlot.SecondAttack.Name}{separator}{unitInSlot.SecondAttack.Type}" : ' ')}";
			thirdField.text = $"{(unitInSlot.ThirdAttack is not null ? $"{unitInSlot.ThirdAttack.Name}{separator}{unitInSlot.ThirdAttack.Type}" : ' ')}";
			fourthField.text = $"{(unitInSlot.FourthAttack is not null ? $"{unitInSlot.FourthAttack.Name}{separator}{unitInSlot.FourthAttack.Type}" : ' ')}";
  		}     
	}

    private void CloseTeamPanel()
    {
        TeamPanel.SetActive(false);
    }
 }
