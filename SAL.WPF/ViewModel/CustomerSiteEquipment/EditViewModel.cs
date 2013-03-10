using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace SAL.WPF.ViewModel.CustomerSiteEquipment
{
    public class EditViewModel : ViewModelBase
    {


        #region Field

        private string _label6;

        private Visibility _textBlock6Visibility = Visibility.Hidden;
 
        #endregion

        #region Property

        public string Title { get; set; }

        public string Label1 { get; set; }
        public string Label2 { get; set; }
        public string Label3 { get; set; }
        public string Label4 { get; set; }
        public string Label5 { get; set; }

        public string Label6 
        { 
            get { return _label6; }
            set
            {
                _label6 = value;
                _textBlock6Visibility = Visibility.Visible;
            }
        }

        public string Label7 { get; set; }

        public Visibility TextBlock6Visibility
        {
            get { return _textBlock6Visibility; }
        }

        public string TextBox1 { get; set; }
        public string TextBox5 { get; set; }
        public string TextBox6 { get; set; }
        public string TextBox7 { get; set; }

        public int? ComboBox2 { get; set; }
        public int? ComboBox3 { get; set; }
        public int? ComboBox4 { get; set; }
        public int? ComboBox5 { get; set; }

        #endregion
    }
}
