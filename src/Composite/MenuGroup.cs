using System;
using System.Collections.Generic;

namespace DesignPatternChallenge.Composite
{
    public class MenuGroup : MenuComponent
    {
        private List<MenuComponent> _children = new List<MenuComponent>();
        public bool IsActive { get; set; } = true;

        public MenuGroup(string title, string icon = "") : base(title, icon)
        {
        }

        public override void Add(MenuComponent component)
        {
            _children.Add(component);
        }

        public override void Remove(MenuComponent component)
        {
            _children.Remove(component);
        }

        public override void Render(int indent = 0)
        {
            var indentation = new string(' ', indent * 2);
            var activeStatus = IsActive ? "✓" : "✗";
            Console.WriteLine($"{indentation}[{activeStatus}] {Icon} {Title} ▼");

            foreach (var child in _children)
            {
                child.Render(indent + 1);
            }
        }

        public override int CountItems()
        {
            int count = 0;
            foreach (var child in _children)
            {
                count += child.CountItems();
            }
            return count;
        }
    }
}
