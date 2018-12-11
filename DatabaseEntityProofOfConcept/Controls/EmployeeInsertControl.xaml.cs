using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseEntityProofOfConcept.Controls
{
    public partial class EmployeeInsertControl : UserControl
    {
        #region Fields & Properties
        private Company _selectedCompany;
        public Company SelectedCompany
        {
            get { return _selectedCompany; }
            set
            {
                if (_selectedCompany != value)
                {
                    _selectedCompany = value;
                }
            }
        }
        #endregion

        #region Routed Events
        public event RoutedEventHandler CompanySelectionChanged
        {
            add { AddHandler(CompanySelectionChangedEvent, value); }
            remove { RemoveHandler(CompanySelectionChangedEvent, value); }
        }
        public static readonly RoutedEvent CompanySelectionChangedEvent = EventManager.RegisterRoutedEvent(
            "CompanySelectionChanged", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(EmployeeInsertControl));
        #endregion

        #region Dependency Properties
        public string EmployeeName
        {
            get { return (string)GetValue(EmployeeNameProperty); }
            set { SetValue(EmployeeNameProperty, value); }
        }
        public static readonly DependencyProperty EmployeeNameProperty =
            DependencyProperty.Register("EmployeeName", typeof(string), typeof(EmployeeInsertControl), new PropertyMetadata(string.Empty));

        public string EmployeeSurname
        {
            get { return (string)GetValue(EmployeeSurnameProperty); }
            set { SetValue(EmployeeSurnameProperty, value); }
        }
        public static readonly DependencyProperty EmployeeSurnameProperty =
            DependencyProperty.Register("EmployeeSurname", typeof(string), typeof(EmployeeInsertControl), new PropertyMetadata(string.Empty));

        public string EmployeeAge
        {
            get { return (string)GetValue(EmployeeAgeProperty); }
            set { SetValue(EmployeeAgeProperty, value); }
        }
        public static readonly DependencyProperty EmployeeAgeProperty =
            DependencyProperty.Register("EmployeeAge", typeof(string), typeof(EmployeeInsertControl), new PropertyMetadata(string.Empty));

        public string EmployeePosition
        {
            get { return (string)GetValue(EmployeePositionProperty); }
            set { SetValue(EmployeePositionProperty, value); }
        }
        public static readonly DependencyProperty EmployeePositionProperty =
            DependencyProperty.Register("EmployeePosition", typeof(string), typeof(EmployeeInsertControl), new PropertyMetadata(string.Empty));

        public IEnumerable Companies
        {
            get { return (IEnumerable)GetValue(CompaniesProperty); }
            set { SetValue(CompaniesProperty, value); }
        }
        public static readonly DependencyProperty CompaniesProperty =
            DependencyProperty.Register("Companies", typeof(IEnumerable), typeof(EmployeeInsertControl), new PropertyMetadata(null));
        #endregion

        #region Constructor
        public EmployeeInsertControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Methods
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseSelectionChangedEvent();
        }

        private void RaiseSelectionChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(EmployeeInsertControl.CompanySelectionChangedEvent);
            RaiseEvent(newEventArgs);
        }
        #endregion
    }
}
