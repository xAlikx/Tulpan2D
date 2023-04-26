using System.Collections.Generic;

public abstract class AttributeConfiguration
{
	public Dictionary<CharacterAction, List<float>> Multipliers { get; set; }
	public Dictionary<CharacterAction, int> Modifiers { get; set; }
}