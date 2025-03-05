using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Stat
    {
        public float BaseValue;
        protected List<float>[] statModifiers;

        protected float value;
        public float Value
        {
            get { return value; }
        }
        public Stat()
        {
            statModifiers = new List<float>[3];
        }

        public Stat(float baseValue) : this()
        {
            BaseValue = baseValue;
            value = BaseValue;
        }

        public virtual void UpdateValue()
        {
            value = CalculateFinalValue();
        }

        public void AddModifier(float mod, StatModifierType type)
        {
            statModifiers[(int)type].Add(mod);
            UpdateValue();
        }

        public void RemoveModifier(float mod, StatModifierType type)
        {
            statModifiers[(int)type].Remove(mod);
            UpdateValue();
        }

        protected float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statModifiers[0].Count; i++)
            {
                finalValue += statModifiers[0][i];
            }

            for (int i = 0; i < statModifiers[1].Count; i++)
            {
                sumPercentAdd += statModifiers[1][i];
            }
            finalValue *= (1 + sumPercentAdd);

            for (int i = 0; i < statModifiers[2].Count; i++)
            {
                finalValue *= (1 + statModifiers[0][i]);
            }
            
            return (float)Math.Round(finalValue, 4);
        }
    }
}
