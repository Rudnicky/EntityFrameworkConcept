using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseEntityProofOfConcept.Controls
{
    public partial class EmployeeDisplayControl : UserControl
    {
        #region Dependency Properties
        public IEnumerable Employees
        {
            get { return (IEnumerable)GetValue(EmployeesProperty); }
            set { SetValue(EmployeesProperty, value); }
        }
        public static readonly DependencyProperty EmployeesProperty =
            DependencyProperty.Register("Employees", typeof(IEnumerable), typeof(EmployeeDisplayControl), new PropertyMetadata(null));
        #endregion

        #region Constructor
        public EmployeeDisplayControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}
