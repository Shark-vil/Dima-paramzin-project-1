using System;
using System.Collections;
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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Model.Data> allowDublicateButtons = new List<Model.Data>();
        List<Model.Data> allowButtons = new List<Model.Data>();
        List<Model.DataNumber> allowButtonsIndex = new List<Model.DataNumber>();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Происходит при нажатии на кнопку в твблице
        /// </summary>
        private void _Action_DataGrid_ButtonElement_AddNumber(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// Добавляет кнопку в таблицу
        /// </summary>
        private void _Action_Button_AddTextToDataGrid_Click(object sender, RoutedEventArgs e)
        {
            // Проверка на то, что поле с текстом не пустое
            if (_Action_TextBox_UserText.Text.Length != 0)
            {
                bool isExists_ButtonData = false;
                int newIndex = 0;

                for (int i = 0; i < allowButtonsIndex.Count; i++)
                {
                    Model.DataNumber ButtonData = allowButtonsIndex[i];
                    if (ButtonData.Text == _Action_TextBox_UserText.Text)
                    {
                        isExists_ButtonData = true;
                        newIndex = ButtonData.Index = ButtonData.Index++;
                        break;
                    }
                }

                if (!isExists_ButtonData)
                    allowButtonsIndex.Add(new Model.DataNumber { Index = 0, Text = _Action_TextBox_UserText.Text });



                bool isExists_Button = false;

                for (int i = 0; i < allowButtons.Count; i++)
                {
                    Model.Data Button = allowButtons[i];
                    if (Button.ButtonContent == _Action_TextBox_UserText.Text)
                    {
                        MessageBox.Show(Button.ButtonContent);
                        isExists_Button = true;
                        allowDublicateButtons = allowButtons.GetRange(0, allowButtons.Count);
                        allowDublicateButtons[i].ButtonContent = _Action_TextBox_UserText.Text + $" {newIndex}";
                        MessageBox.Show(allowDublicateButtons[i].ButtonContent);
                        MessageBox.Show(Button.ButtonContent);
                        break;
                    }
                }

                if (!isExists_Button)
                    allowButtons.Add(new Model.Data { Id = allowButtons.Count + 1,
                        ButtonContent = _Action_TextBox_UserText.Text });



                Task.Factory.StartNew(async () =>
                {
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        _Action_DataGrid_ButtonsList.ItemsSource = null;
                        _Action_DataGrid_ButtonsList.ItemsSource = allowDublicateButtons;
                    });
                });
            }
        }

        /// <summary>
        /// Очищает таблицу
        /// </summary>
        private void _Action_Button_ClearToDataGrid_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
