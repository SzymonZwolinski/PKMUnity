using System;
using UnityEngine;

public abstract class BaseUnit : Component
{
		// Public properties
	public uint Id { get; protected set; }
	public Guid UniqueId { get; protected set; }
	public uint HealthPoints { get; set; }
	public uint Attack { get; set; }
	public uint SpecialAttack { get; set; }
	public uint Defence { get; set; }
	public uint SpecialDefence { get; set; }
	public uint Speed { get; set; }
	public uint Stamina { get; set; }
	public bool IsAlive { get; set; }
	public Types FirstType { get; set; }
	public Types? SecondaryType { get; set; }
	public uint Level { get; set; }
	public float BaseExperiencePointsToNextLevel { get; set; }
	public float ExperiencePointsToNextLevel { get; set; }
	public float ExperiencePoints { get; set; }
	public uint HealthPointsLearned { get; set; }
	public uint AttackLearned { get; set; }
	public uint SpecialAttackLearned { get; set; }
	public uint DefenceLearned { get; set; }
	public uint SpecialDefenceLearned { get; set; }
	public uint SpeedLearned { get; set; }
	public uint StaminaLearned { get; set; }
	public bool HasBeenSeen { get; set; }
	public bool HasBeenCaught { get; set; }
	public HoldItem HeldItem { get; set; }
	public float ExperiencePointsWorth { get; set; }

	// Protected properties
	protected float ExperiencePointsRequirementMultiplier { get; set; }

	// TODO: Add Available moves list and unknown moves

	// Private fields


	// Constructors

	protected BaseUnit()
	{

	}

	protected BaseUnit(
		uint id,
		uint healthPoints,
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
		float experiencePointsRequirementMultiplier)
	{
		UniqueId = Guid.NewGuid();
		Id = id;
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
	}

	// Methods
	protected void CalculateExperiencePoints(float gainedExperiencePoints)
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
		var overExceedingExperiencePoints = ExperiencePoints - ExperiencePointsToNextLevel;

		ExperiencePointsToNextLevel *= ExperiencePointsRequirementMultiplier;
		ExperiencePoints = 0 + overExceedingExperiencePoints;
		Level += 1;

		if (Level == 100)
		{
			ExperiencePoints = 0;
		}
	}
}
