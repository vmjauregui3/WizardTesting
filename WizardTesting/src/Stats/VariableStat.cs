using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class VariableStat : Stat
    {
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
            valueMax = baseValue;
        }

        public override void UpdateBaseValue()
        {
            valueMax = (float)Math.Truncate(CalculateFinalValue());
        }

        public void SetValue(float val)
        {
            value = val;
        }

        public void AddValue(float val)
        {
            value += val;
        }
    }
}
