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

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<IItem> items;
        private List<IItem> filteredItems;
        private IShop shop;

        /*
         * Методы LINQ в проекте:
         * 1. Where - используется для фильтрации элементов коллекции на основе заданного условия.
         * 2. ToList - преобразует результат в List<T>.
         * Это принудительное выполнение ленивого запроса и материализация результатов в список.
         * 3. Sum - вычисляет сумму значений в коллекции.
         * 4. GroupBy - группирует элементы коллекции по ключу.
         * 5. Select -  проецирует каждый элемент последовательности в новую форму.
         * В данном проекте он проецирует группы элементов в анонимные объекты,
         * содержащие ключ группы (Installation) и количество элементов в группе (Count).
         * 6. Count - вычисляет количество элементов в коллекции.
         */

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            InitializeFilterFields();
        }

        private void InitializeData()
        {
            // инициализация данных
            shop = new Shop();
            shop.SetItems(new List<IItem>
            {
                new HumidifierItem("Tion", "IQ200", 30, InstallationEnum.OUTDOOR, 46, 17, 17200),
                new HumidifierItem("Ballu", "asp-80", 30, InstallationEnum.WALL_MOUNTED, 24, 615, 16711),
                new HumidifierItem("Tion", "Lite", 20, InstallationEnum.WALL_MOUNTED, 48, 900, 33700),
                new HumidifierItem("Tion", "O2 Base", 30, InstallationEnum.WALL_MOUNTED, 52, 1450, 40650),
                new HumidifierItem("Electrolux", "EAP-2050D", 50, InstallationEnum.DESKTOP, 21, 36, 18171)
            });

            items = shop.GetItems(); // Метод получения всех товаров из магазина
            if (items == null)
            {
                items = new List<IItem>();
            }
            filteredItems = new List<IItem>(items);
            itemsDataGrid.ItemsSource = filteredItems;
        }

        private void InitializeFilterFields()
        {
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "Vendor" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "Model" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "AreaCoverage" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "Installation" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "MaxNoiseLevel" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "Power" });
            filterFieldComboBox.Items.Add(new ComboBoxItem { Content = "Price" });
        }

        // фильтрация и сортировка
        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e) // кнопка фильтрации
        {
            string selectedField = ((ComboBoxItem)filterFieldComboBox.SelectedItem)?.Content.ToString();
            string criteria = ((ComboBoxItem)filterCriteriaComboBox.SelectedItem)?.Content.ToString();
            string filterValue = filterTextBox.Text;

            if (string.IsNullOrEmpty(filterValue))
            {
                InitializeData();
                //itemsDataGrid.ItemsSource = filteredItems;
                return;
                InitializeData();
            }
            
            if (string.IsNullOrEmpty(selectedField) || string.IsNullOrEmpty(criteria))
            {
                MessageBox.Show("Заполните все поля фильтра.");
                return;
            }

            /*
             выражение items.Where(...) создает запрос, который будет выполнен только тогда,
            когда к нему будет обращение, например, при вызове метода ToList().
            Только в этот момент выполняется фактический перебор и фильтрация элементов.
             */
            filteredItems = items.Where(item =>
            {
                object fieldValue = item.GetType().GetProperty(selectedField).GetValue(item, null);
                switch (criteria)
                {
                    case "Содержит":
                        return fieldValue.ToString().Contains(filterValue);
                    case "Не содержит":
                        return !fieldValue.ToString().Contains(filterValue);
                    case "Равно":
                        return fieldValue.ToString() == filterValue;
                    case "Не равно":
                        return fieldValue.ToString() != filterValue;
                    case "Больше":
                        if (double.TryParse(fieldValue.ToString(), out double fieldValueDouble1) &&
                            double.TryParse(filterValue, out double filterValueDouble1))
                        {
                            return fieldValueDouble1 > filterValueDouble1;
                        }
                        return false;
                    case "Меньше":
                        if (double.TryParse(fieldValue.ToString(), out double fieldValueDouble2) &&
                            double.TryParse(filterValue, out double filterValueDouble2))
                        {
                            return fieldValueDouble2 < filterValueDouble2;
                        }
                        return false;
                    default:
                        return false;
                }
            }).ToList();

            itemsDataGrid.ItemsSource = filteredItems;
        }

        // кнопка для подсчёта суммы

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            decimal totalCost = filteredItems.Sum(item => item.Price);
            MessageBox.Show($"Суммарная стоимость товаров: {totalCost}");
        }

        /*
         * В этом коде, выражение filteredItems.GroupBy(item => item.Category) создает запрос на группировку,
         * который выполняется при обращении к результатам, например, при вызове Select(...) и переборе результирующего списка в string.Join(...).
         * Группировка и подсчет выполняются только в момент обращения к результатам, демонстрируя ленивые вычисления.
         */

        private void CountByTypeButton_Click(object sender, RoutedEventArgs e) // кнопка для подсчёта каждого типа товара
        {
            var itemCounts = filteredItems.GroupBy(item => item.Installation)
                                          .Select(group => new { Installation = group.Key, Count = group.Count() });

            string message = string.Join(Environment.NewLine, itemCounts.Select(ic => $"Тип: {ic.Installation}, Количество: {ic.Count}"));
            MessageBox.Show(message);
        }


    }
}
