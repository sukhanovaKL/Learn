using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для EditCreateWindow.xaml
    /// </summary>
    public partial class EditCreateWindow : Window
    {
        LearnEntities db = new LearnEntities();

        Services _service;

        bool _isEdit;

        private string _imagePath;

        public EditCreateWindow(Services service, bool isEdit)
        {
            InitializeComponent();

            _service = service;
            _isEdit = isEdit;
            EditCreateItem.DataContext = service;

            if (isEdit)
                IdLabel.Content = "Идентификатор: " + service.Id;
            else
                AddOtherPhotoButton.Visibility = Visibility.Hidden;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new MainWindow().Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(MinutesTextBox.Text) < 2400 || int.Parse(MinutesTextBox.Text) > 0)
            {
                if (_isEdit)
                {
                    if (db.Services.ToList().Find(x => x.Name == _service.Name) == null)
                    {
                        var editItem = db.Services.ToList().Find(x => x.Id == _service.Id);
                        editItem.Name = _service.Name;
                        editItem.Description = _service.Description;
                        editItem.Cost = _service.Cost;
                        editItem.Minutes = _service.Minutes;
                        editItem.Sale = _service.Sale;
                        if(_imagePath.Any())
                            editItem.Photo = _imagePath;

                        db.SaveChanges();
                    }
                }
                else
                {
                    if (db.Services.ToList().Find(x => x.Name == _service.Name) == null)
                    {
                        _service.Id = db.Services.ToList().Count + 1;
                        _service.Photo = _imagePath;
                        _service.Name = NameTextBox.Text;
                        _service.Description = DescriptionTextBox.Text;
                        _service.Cost = int.Parse(CostTextBox.Text);
                        _service.Minutes = int.Parse(MinutesTextBox.Text);
                        _service.Sale = int.Parse(SaleTextBox.Text);
                        db.Services.Add(_service);
                        db.SaveChanges();

                        _isEdit = true;
                        AddOtherPhotoButton.Visibility = Visibility.Visible;
                        IdLabel.Content = "Идентификатор: " + _service.Id;
                    }
                    else
                        MessageBox.Show("Услуга с таким названием уже есть");
                }
            }
            else
                MessageBox.Show("Длительность оказания услуги не может быть больше, чем 4 часа, а также не может принимать отрицательные значения.");
        }

        private void EditPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opFD = new OpenFileDialog();
                opFD.ShowDialog();
                var imag = opFD.FileName;
                string dest = "C:/Users/79393/source/repos/Learn/Photos/" + System.IO.Path.GetFileName(imag);
                Image image = new Image();
                var bi = new BitmapImage(new Uri(dest));
                Photo.Source = bi;
                var pr = db.Services.ToList().Find(f => f.Id == _service.Id);
                if (pr == null)
                    _imagePath = opFD.SafeFileName;
                else
                {
                    pr.Photo = opFD.SafeFileName;
                    db.SaveChanges();
                }

                EditCreateItem.DataContext = pr;
            }
            catch(Exception ex)
            {

            }
        }

        private void AddOtherPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new OtherPhotosWindow(_service.Id).Show();
        }
    }
}
