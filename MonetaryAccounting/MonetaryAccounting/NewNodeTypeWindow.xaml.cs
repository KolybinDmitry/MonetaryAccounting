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
using System.Windows.Shapes;

namespace MonetaryAccounting
{
    /// <summary>
    /// Логика взаимодействия для NewNodeTypeWindow.xaml
    /// </summary>
    public partial class NewNodeTypeWindow : Window
    {
        public string NewNodeType;
        public NewNodeTypeWindow()
        {
            InitializeComponent();

            textBoxNewNodeType.Text = string.Empty;
        }

        private void buttonNewNodeType_Click(object sender, RoutedEventArgs e)
        {
            NewNodeType = textBoxNewNodeType.Text;
            Close();
        }
    }
}
