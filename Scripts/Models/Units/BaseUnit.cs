using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class BaseUnit : ScriptableObject
{
	// Public properties
	[SerializeField] public Guid UniqueId;
	[SerializeField] public string Name;
	[SerializeField] public double MaxHealthPoints;
	[SerializeField] public double HealthPoints;
	[SerializeField] public uint Attack;
	[SerializeField] public uint SpecialAttack;
	[SerializeField] public uint Defence;
	[SerializeField] public uint SpecialDefence;
	[SerializeField] public uint Speed;
	[SerializeField] public uint Stamina;
	[SerializeField] public bool IsAlive;
	[SerializeField] public Types FirstType;
	[SerializeField] public Types? SecondaryType;
	[SerializeField] public uint Level;
	[SerializeField] public float BaseExperiencePointsToNextLevel;
	[SerializeField] public float ExperiencePointsToNextLevel;
	[SerializeField] public float ExperiencePoints;
	[SerializeField] public uint HealthPointsLearned;
	[SerializeField] public uint AttackLearned;
	[SerializeField] public uint SpecialAttackLearned;
	[SerializeField] public uint DefenceLearned;
	[SerializeField] public uint SpecialDefenceLearned;
	[SerializeField] public uint SpeedLearned;
	[SerializeField] public uint StaminaLearned;
	[SerializeField] public bool HasBeenSeen;
	[SerializeField] public bool HasBeenCaught;
	[SerializeField] public float ExperiencePointsWorth;
	[SerializeField] public uint SpawnRate;

	// Protected properties
	[SerializeField] protected float ExperiencePointsRequirementMultiplier;

	[SerializeField] public AttackModel FirstAttack;
	[SerializeField] public AttackModel SecondAttack;
	[SerializeField] public AttackModel ThirdAttack;
	[SerializeField] public AttackModel FourthAttack;
	protected List<string> AvailibleAttacks = new List<string>(); //TODO: Change this to some enum later

	[SerializeField] public string PrefabPath;
	// Constructors

	protected BaseUnit()
	{

	}

	protected BaseUnit(
		int healthPoints,
		uint attack,
		uint specialAttack, 
		uint defence, 
		uint specialDefence,
		uint speed, 
		uint stamina,
		bool isAlive, 
		Types firstType, 
		Types? secondaryType,
		uint level, 
		float baseExperiencePointsToNextLevel,
		float experiencePointsToNextLevel,
		float experiencePoints,
		uint healthPointsLearned,
		uint attackLearned, 
		uint specialAttackLearned, 
		uint defenceLearned,
		uint specialDefenceLearned,
		uint speedLearned,
		uint staminaLearned,
		bool hasBeenSeen,
		bool hasBeenCaught,
		HoldItem heldItem,
		float experiencePointsWorth,
		float experiencePointsRequirementMultiplier,
		uint spawnRate,
		string prefabPath)
	{
		UniqueId = Guid.NewGuid();
		MaxHealthPoints = healthPoints;
		HealthPoints = healthPoints;
		Attack = attack;
		SpecialAttack = specialAttack;
		Defence = defence;
		SpecialDefence = specialDefence;
		Speed = speed;
		Stamina = stamina;
		IsAlive = isAlive;
		FirstType = firstType;
		SecondaryType = secondaryType;
		Level = level;
		BaseExperiencePointsToNextLevel = baseExperiencePointsToNextLevel;
		ExperiencePointsToNextLevel = experiencePointsToNextLevel;
		ExperiencePoints = experiencePoints;
		HealthPointsLearned = healthPointsLearned;
		AttackLearned = attackLearned;
		SpecialAttackLearned = specialAttackLearned;
		DefenceLearned = defenceLearned;
		SpecialDefenceLearned = specialDefenceLearned;
		SpeedLearned = speedLearned;
		StaminaLearned = staminaLearned;
		HasBeenSeen = hasBeenSeen;
		HasBeenCaught = hasBeenCaught;
		HeldItem = heldItem;
		ExperiencePointsWorth = experiencePointsWorth;
		ExperiencePointsRequirementMultiplier = experiencePointsRequirementMultiplier;
		SpawnRate = spawnRate;
		PrefabPath = prefabPath;
	}

	// Methods
	public void AddExperiencePoints(float gainedExperiencePoints)
	{
		if (Level == 100)
		{
			return;
		}

		ExperiencePoints += gainedExperiencePoints;

		if (ExperiencePoints >= ExperiencePointsToNextLevel)
		{
			LevelUp();
		}
	}

	public void LevelUp()
	{
		if(Level == 100)
		{
			return;
		}
		var overExceedingExperiencePoints = ExperiencePoints - ExperiencePointsToNextLevel;

		ExperiencePointsToNextLevel *= ExperiencePointsRequirementMultiplier;
		ExperiencePoints = 0 + overExceedingExperiencePoints;
		Level += 1;

		ImproveStats();
	}

	public void Heal(int amount)
	{
		HealthPoints += amount;
		if(HealthPoints > MaxHealthPoints)
		{
			HealthPoints = MaxHealthPoints;
		}
	}	

	public List<AttackModel> GetAllAttacks()
	{
		var attackProperties = new List<AttackModel>();

		AddToListNotNullAttack(FirstAttack, attackProperties);
		AddToListNotNullAttack(SecondAttack, attackProperties);
		AddToListNotNullAttack(ThirdAttack, attackProperties);
		AddToListNotNullAttack(FourthAttack, attackProperties);


		return attackProperties;
	}

	private void AddToListNotNullAttack(AttackModel attack, List<AttackModel> attackList)
	{
		if(attack is not null)
		{
			attackList.Add(attack);
		}
	}

	protected abstract void ImproveStats();

	protected abstract ItemBase CheckIfAnyItemCouldBeDropper();
}
