﻿using System.Collections.Generic;
using UnityEngine;
using Jalomieli.Debug;
using Jalomieli.Extensions;

public class PlayerCharacterChange : MonoBehaviour, ICharacterChangeHandler
{
	private Dictionary<int, Color> powerLevelToColor = new Dictionary<int, Color>()
	{
		{0, new Color(0f, 1f, 0f)},
		{1, new Color(0f, 0f, 1f)},
		{2, new Color(1f, 0f, 0f)}
	};
	void Start()
	{
		OnPowerLevelChange(gameObject.DemandComponent<Character>());
	}
	public void OnPowerLevelChange(Character character) 
	{
		var powerLevel = character.GetPowerLevel();
		Color color;
		powerLevelToColor.TryGetValue(powerLevel, out color);
		Assert.NotNull(color);
		GetComponent<SpriteRenderer>().color = color;
	}
}