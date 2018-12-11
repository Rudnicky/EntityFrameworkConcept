using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseEntityProofOfConcept.Controls
{
    /// <summary>
    /// Interaction logic for CompanyInsertControl.xaml
    /// </summary>
    public partial class CompanyInsertControl : UserControl
    {


        public string CompanyName
        {
            get { return (string)GetValue(CompanyNameProperty); }
            set { SetValue(CompanyNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompanyName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanyNameProperty =
            DependencyProperty.Register("CompanyName", typeof(string), typeof(CompanyInsertControl), new PropertyMetadata(string.Empty));



        public string CompanyIndustry
        {
            get { return (string)GetValue(CompanyIndustryProperty); }
            set { SetValue(CompanyIndustryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CompanyIndustry.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CompanyIndustryProperty =
            DependencyProperty.Register("CompanyIndustry", typeof(string), typeof(CompanyInsertControl), new PropertyMetadata(string.Empty));



        public CompanyInsertControl()
        {
            InitializeComponent();
        }
    }
}
