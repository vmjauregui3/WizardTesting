using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class StatModifier
    {
        public readonly float Value;
        public readonly StatModifierType Type;

        public StatModifier(float value, StatModifierType type)
        {
            Value = value;
            Type = type;
        }

    }
}
