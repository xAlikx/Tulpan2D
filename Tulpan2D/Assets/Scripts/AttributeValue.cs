using System.Collections.Generic;
using System.Linq;

public class AttributeValue
{
	private const float c_defaultValue = 100;
	private Dictionary<CharacterAction, List<float>> _multipliers = new();
	private Dictionary<CharacterAction, int> _modifiers = new();
	public float Value { get; private set; }

	public AttributeValue()
	{
		Value = c_defaultValue;
	}
    
	public AttributeValue(AttributeConfiguration configuration)
	{
		Value = c_defaultValue;
		_multipliers = configuration.Multipliers;
		_modifiers = configuration.Modifiers;
	}
    
	public void ReduceFromAction(CharacterAction action)
	{
		Value += _modifiers[action] * _multipliers[action].Sum();
	}
}