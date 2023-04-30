using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace MonetaryAccounting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public class Node
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public int Money { get; set; }
        public bool IsIncome { get; set; }

        public Node () { }

        public Node(string name, string typeName, int money, bool isIncome = false) 
        {
            Name = name;
            TypeName = typeName;
            Money = money;
            IsIncome = isIncome;
        }

        public Node(Node node)
        {
            Name = node.Name;
            TypeName = node.TypeName;
            Money = node.Money;
            IsIncome = node.IsIncome;
        }
    }

    public partial class MainWindow : Window
    {
        public Dictionary<DateTime, List<Node>> nodes = new Dictionary<DateTime, List<Node>>();
        public HashSet<string> typesNodes = new HashSet<string>();

        public delegate void FormElementChange();
        public event FormElementChange DataGridChange;
        public event FormElementChange ComboBoxChange;

        public MainWindow()
        {
            InitializeComponent();
            textBoxMoney.Text = string.Empty;
            textBoxNodeTitle.Text = string.Empty;
            datePicker.SelectedDate = DateTime.Today;

            DataGridChange += DrawDataGrid;
            DataGridChange += SerializationNodes;

            ComboBoxChange += SerializationTypes;

            // десериализация заметок
            nodes = File.Exists("nodes.json")
                ? JsonConvert.DeserializeObject<Dictionary<DateTime, List<Node>>>(File.ReadAllText("nodes.json"))
                : new Dictionary<DateTime, List<Node>>();
            // десериализация типов заметок
            typesNodes = File.Exists("types.json")
                ? JsonConvert.DeserializeObject<HashSet<string>>(File.ReadAllText("types.json"))
                : new HashSet<string>();

            foreach (var type in typesNodes)
                comboBox.Items.Add(type);

            DataGridChange?.Invoke();
        }

        private void SerializationNodes()
        {
            // сериализация заметок
            File.WriteAllText("nodes.json", JsonConvert.SerializeObject(nodes));
        }

        private void SerializationTypes()
        {
            // сериализация типов заметок
            File.WriteAllText("types.json", JsonConvert.SerializeObject(typesNodes));
        }

        private void DrawDataGrid()
        {
            // очистка dataGrid
            dataGrid.ItemsSource = null;

            if (!nodes.ContainsKey((DateTime)datePicker.SelectedDate))
                return;

            dataGrid.ItemsSource = nodes[(DateTime)datePicker.SelectedDate];
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridChange?.Invoke();
        }

        private void buttonCreateNewNode_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на то, что comboBox не пуст
            if (comboBox.Items.Count == 0 || comboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Не выбран тип заметки", 
                    "Внимание!", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning
                    );
                return;
            }
            // Проверка на то, что имя не пусто
            if (textBoxNodeTitle.Text == string.Empty)
            {
                MessageBox.Show(
                    "Имя замтеки не может быть пустым", 
                    "Внимание!", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning
                    );
                return;
            }
            // Проверка на то, что имя не пусто
            if (textBoxMoney.Text == string.Empty || !int.TryParse(textBoxMoney.Text, out var result))
            {
                MessageBox.Show(
                    "Сумма денег должна быть числом", 
                    "Внимание!", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning
                    );
                return;
            }

            Node newNode = new Node(
                textBoxNodeTitle.Text, 
                comboBox.SelectedValue.ToString(), 
                int.Parse(textBoxMoney.Text)
                );

            if (!nodes.ContainsKey((DateTime)datePicker.SelectedDate))
                nodes.Add((DateTime)datePicker.SelectedDate, new List<Node>() { newNode });
            else
                nodes[(DateTime)datePicker.SelectedDate].Add(newNode);

            DataGridChange?.Invoke();
        }

        private void buttonNewTypeNode_Click(object sender, RoutedEventArgs e)
        {
            NewNodeTypeWindow newNodeTypeWindow = new NewNodeTypeWindow();
            newNodeTypeWindow.Owner = this;

            string newNodeType = string.Empty;

            newNodeTypeWindow.Closed += (sender1, e1) =>
            {
                newNodeType = newNodeTypeWindow.NewNodeType;

                // Проверка на то, что указанный тип НЕ пустая строка
                if (newNodeType == string.Empty)
                {
                    MessageBox.Show(
                        "Значение типа не может быть пустым",
                        "Внимание!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                    return;
                }

                // Проверка на то, что новый тип уникален
                if (typesNodes.Contains(newNodeType))
                {
                    MessageBox.Show(
                        "Этот тип заметки уже добавлен",
                        "Внимание!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning
                        );
                    return;
                }
                typesNodes.Add(newNodeType);
                comboBox.Items.Add(newNodeType);
                ComboBoxChange?.Invoke();
            };

            newNodeTypeWindow.Show();
        }

        private void buttonChangeNode_Click(object sender, RoutedEventArgs e)
        {
            var changedNode = (Node)dataGrid.SelectedItem;

            if (!typesNodes.Contains(changedNode.TypeName))
            {
                typesNodes.Add(changedNode.TypeName);
                comboBox.Items.Add(changedNode.TypeName);
                ComboBoxChange?.Invoke();
            }

            nodes.Remove((DateTime)datePicker.SelectedDate);

            foreach (var node in dataGrid.Items)
            {
                if (!nodes.ContainsKey((DateTime)datePicker.SelectedDate))
                    nodes.Add((DateTime)datePicker.SelectedDate, new List<Node>() { (Node)node });
                else
                    nodes[(DateTime)datePicker.SelectedDate].Add((Node)node);
            }

            DataGridChange?.Invoke();
        }

        private void buttonDeleteNode_Click(object sender, RoutedEventArgs e)
        {
            var node = (Node)dataGrid.SelectedItem;
            nodes[(DateTime)datePicker.SelectedDate].Remove(node);

            DataGridChange?.Invoke();
        }

        private void buttonDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            nodes.Clear();
            typesNodes.Clear();
            comboBox.Items.Clear();

            ComboBoxChange?.Invoke();
            DataGridChange?.Invoke();
        }
    }
}
