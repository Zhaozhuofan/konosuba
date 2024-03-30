using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace konosuba.Behaviors
{
    internal class MouseDragBehavior:Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += OnWindowDrag;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseLeftButtonDown -= OnWindowDrag;
        }
        private void OnWindowDrag(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(sender as Window);
            if (position.X > 0 && position.X < 1500 && position.Y > 0 && position.Y < 50)
                (sender as Window)!.DragMove();
        }
    }
}
