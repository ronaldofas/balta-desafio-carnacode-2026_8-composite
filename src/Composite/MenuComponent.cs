using System;

namespace DesignPatternChallenge.Composite
{
    public abstract class MenuComponent
    {
        public string Title { get; protected set; }
        public string Icon { get; protected set; }

        public MenuComponent(string title, string icon = "")
        {
            Title = title;
            Icon = icon;
        }

        public abstract void Render(int indent = 0);
        public abstract int CountItems();

        public virtual void Add(MenuComponent component)
        {
            throw new NotSupportedException("This component does not support adding children.");
        }

        public virtual void Remove(MenuComponent component)
        {
            throw new NotSupportedException("This component does not support removing children.");
        }
    }
}
