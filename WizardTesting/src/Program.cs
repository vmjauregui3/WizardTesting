using System;

namespace WizardTesting
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new WizardTesting())
                game.Run();
        }
    }
}
