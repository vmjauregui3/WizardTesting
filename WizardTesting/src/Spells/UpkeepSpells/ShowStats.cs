using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public class ShowStats : UpkeepSpell
    {
        public ShowStats(Wizard owner) : base(owner, 200, 5000, 100, 50)
        {
            castEffect = owner.User.UI.ToggleStatBars;
            endEffect = owner.User.UI.ToggleStatBars;
        }

        public ShowStats(Wizard owner, int level, int exp) : base(owner, 200, 5000, 100, 50, level, exp)
        {
            castEffect = owner.User.UI.ToggleStatBars;
            endEffect = owner.User.UI.ToggleStatBars;
        }
    }
}
