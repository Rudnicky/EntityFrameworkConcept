using DatabaseEntityProofOfConcept.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DatabaseEntityProofOfConcept.Behaviors
{
    public class SelectionChangedBehavior
    {
        #region SelectionChanged Behavior
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
        #endregion

        #region Combobox SelectionChanged
        public static readonly DependencyProperty ComboBoxSelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached("ComboBoxSelectionChangedCommand", typeof(ICommand), typeof(SelectionChangedBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(ComboBoxSelectionChangedCommandChanged)));

        private static void ComboBoxSelectionChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var comboBox = (ComboBox)d;
            if (comboBox != null)
            {
                comboBox.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

        private static void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            if (comboBox != null)
            {
                ICommand command = GetComboBoxSelectionChangedCommand(comboBox);
                if (command != null)
                {
                    command.Execute(comboBox.SelectedItem);
                }
            }
        }

        public static void SetComboBoxSelectionChangedCommand(UIElement element, ICommand value)
        {
            element.SetValue(ComboBoxSelectionChangedCommandProperty, value);
        }

        public static ICommand GetComboBoxSelectionChangedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(ComboBoxSelectionChangedCommandProperty);
        }
        #endregion

        #region Code-Specific Combobox SelectionChanged
        public static readonly DependencyProperty EmployeeComboBoxSelectionChangedCommandProperty =
            DependencyProperty.RegisterAttached("EmployeeComboBoxSelectionChangedCommand", typeof(ICommand), typeof(SelectionChangedBehavior),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(EmployeeComboBoxSelectionChangedCommandChanged)));

        private static void EmployeeComboBoxSelectionChangedCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var userControl = (EmployeeInsertControl)d;
            if (userControl != null)
            {
                userControl.CompanySelectionChanged += Container_CompanySelectionChanged;
            }
        }

        private static void Container_CompanySelectionChanged(object sender, RoutedEventArgs e)
        {
            var userControl = (EmployeeInsertControl)sender;
            if (userControl != null)
            {
                ICommand command = GetEmployeeComboBoxSelectionChangedCommand(userControl);
                if (command != null)
                {
                    command.Execute(userControl.SelectedCompany);
                }
            }
        }

        public static void SetEmployeeComboBoxSelectionChangedCommand(UIElement element, ICommand value)
        {
            element.SetValue(EmployeeComboBoxSelectionChangedCommandProperty, value);
        }

        public static ICommand GetEmployeeComboBoxSelectionChangedCommand(UIElement element)
        {
            return (ICommand)element.GetValue(EmployeeComboBoxSelectionChangedCommandProperty);
        }
        #endregion
    }
}
