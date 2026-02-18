using System;

namespace DesignPatternChallenge.Composite
{
    public class MenuItem : MenuComponent
    {
        public string Url { get; private set; }
        public bool IsActive { get; set; }

        public MenuItem(string title, string url, string icon = "") : base(title, icon)
        {
            Url = url;
            IsActive = true;
        }

        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} → {Url}");
        }

        public override int CountItems()
        {
            return 1;
        }
    }
}
