using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.Behaviors
{
    public class SelectionChangedBehavior
    {
        public static readonly DependencyProperty SelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached("SelectionChangedCommand", typeof(ICommand), typeof(SelectionChangedBehavior), 
                new FrameworkPropertyMetadata(new PropertyChangedCallback(SelectionChangedCommandChanged)));

        private static void SelectionChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var container = (ListView)d;
            if (container != null)
            {
                container.SelectionChanged += Element_SelectionChanged1;
            }
        }

        private static void Element_SelectionChanged1(object sender, SelectionChangedEventArgs e)
        {
            var container = (ListView)sender;
            if (container != null)
            {
                ICommand command = GetSelectionChangedCommand(container);
                if (command != null)
                {
                    command.Execute(container.SelectedItem);
                }
            }
        }

        public static void SetSelectionChangedCommand(UIElement element, ICommand value)
        {
            element.SetValue(SelectionChangedCommandProperty, value);
        }

        public static ICommand GetSelectionChangedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(SelectionChangedCommandProperty);
        }
    }
}
