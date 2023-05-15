using Microsoft.Win32;
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

namespace Learn
{
    /// <summary>
    /// Логика взаимодействия для OtherPhotosWindow.xaml
    /// </summary>
    public partial class OtherPhotosWindow : Window
    {
        LearnEntities db = new LearnEntities();

        int _parentId;

        public OtherPhotosWindow(int parentId)
        {
            InitializeComponent();
            _parentId = parentId;
            PhotosList.ItemsSource = db.OtherPhotos.ToList().FindAll(x => x.ServicesId == parentId);
        }

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opFD = new OpenFileDialog();
                opFD.ShowDialog();
                var imag = opFD.FileName;
                string dest = "C:/Users/79393/source/repos/Learn/Photos/" + System.IO.Path.GetFileName(imag);
                Image image = new Image();
                var bi = new BitmapImage(new Uri(dest));
                var newItem = new OtherPhotos();
                newItem.Id = db.OtherPhotos.ToList().Count + 1;
                newItem.ServicesId = _parentId;
                newItem.Photo = opFD.SafeFileName;
                db.OtherPhotos.Add(newItem);
                db.SaveChanges();


                PhotosList.ItemsSource = db.OtherPhotos.ToList().FindAll(x => x.ServicesId == _parentId);
            }
            catch (Exception ex)
            {

            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new EditCreateWindow(db.Services.ToList().Find(x => x.Id == _parentId), true).Show();
        }
    }
}
