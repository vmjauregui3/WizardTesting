﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class Stat
    {
        public float BaseValue;
        protected List<float> flatModifiers;
        protected List<float> percentAddModifiers;
        protected List<float> percentMultiplyModifiers;

        protected float value;
        public float Value
        {
            get { return value; }
        }

        public Stat(float baseValue)
        {
            BaseValue = baseValue;
            value = BaseValue;
            flatModifiers = new List<float>();
            percentAddModifiers = new List<float>();
            percentMultiplyModifiers = new List<float>();
        }

        public virtual void UpdateValue()
        {
            value = CalculateFinalValue();
        }

        public void AddModifier(float mod, StatModifierType type)
        {
            switch(type)
            {
                case StatModifierType.Flat:
                    flatModifiers.Add(mod);
                    break;
                case StatModifierType.PercentAdd:
                    percentAddModifiers.Add(mod);
                    break;
                case StatModifierType.PercentMultiply:
                    percentMultiplyModifiers.Add(mod);
                    break;
            }
            UpdateValue();
        }

        public void RemoveModifier(float mod, StatModifierType type)
        {
            switch (type)
            {
                case StatModifierType.Flat:
                    flatModifiers.Remove(mod);
                    break;
                case StatModifierType.PercentAdd:
                    percentAddModifiers.Remove(mod);
                    break;
                case StatModifierType.PercentMultiply:
                    percentMultiplyModifiers.Remove(mod);
                    break;
            }
            UpdateValue();
        }

        protected float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            foreach (float mod in flatModifiers)
            {
                finalValue += mod;
            }

            foreach (float mod in percentAddModifiers)
            {
                sumPercentAdd += mod;
            }
            finalValue *= (1 + sumPercentAdd);

            foreach (float mod in percentMultiplyModifiers)
            {
                finalValue *= mod;
            }
            
            return (float)Math.Round(finalValue, 4);
        }
    }
}


