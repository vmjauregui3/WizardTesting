using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class VariableStat : Stat
    {
        protected float maxValue;

        protected float valueMax;
        public float ValueMax
        {
            get { return valueMax; }
        }

        public VariableStat() : base()
        {

        }

        public VariableStat(float baseValue) : base(baseValue)
        {
            maxValue = baseValue;
            value = baseValue;
        }

        public override void UpdateBaseValue()
        {
            maxValue = CalculateFinalValue();
        }
    }
}
