using System;
using System.Collections.Generic;
using System.Text;

namespace WizardTesting
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);
    public static class GameCommands
    {
        public static PassObject PassProjectile;
        public static PassObject PassCreature;
        public static PassObject PassSpawnPoint;
    }
}
