using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class ShowStats : UpkeepSpell
    {
        private UI UI;
        public ShowStats(Creature owner, UI ui) : base(owner, 200, 5000, 100, 50)
        {
            UI = ui;
        }

        public ShowStats(Creature owner, UI ui, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            UI = ui;
        }

        public override void CastEffect()
        {
            UI.ToggleStatBars();
            base.CastEffect();
        }

        public override void EndEffect()
        {
            UI.ToggleStatBars();
            base.EndEffect();
        }
    }
}
