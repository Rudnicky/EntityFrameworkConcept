using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseEntityProofOfConcept.Controls
{
    public partial class CompanyDisplayControl : UserControl
    {
        #region Dependency Properties
        public IEnumerable Companies
        {
            get { return (IEnumerable)GetValue(CompaniesProperty); }
            set { SetValue(CompaniesProperty, value); }
        }
        public static readonly DependencyProperty CompaniesProperty =
            DependencyProperty.Register("Companies", typeof(IEnumerable), typeof(CompanyDisplayControl), new PropertyMetadata(null));
        #endregion

        #region Constructor
        public CompanyDisplayControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}
