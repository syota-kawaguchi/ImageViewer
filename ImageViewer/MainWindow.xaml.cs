using Microsoft.Win32;
using System;
using System.IO;
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
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int lookPageIndex = 0;
        List<string> images;

        private static readonly List<string> imageExtensions = new List<string> {
            ".bmp",
            ".gif",
            ".ico",
            ".jpeg",
            ".jpg",
            ".png",
            ".tif",
            ".tiff",
        };

        private static bool isImageFile(string ext)
        {
            foreach (string extension in imageExtensions) {
                if (ext == extension) return true;
            }
            return false;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public bool LoadImage(string path) {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path)) {
                return false;
            }

            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.UriSource = new Uri(path);
            bmp.EndInit();
            Image1.Source = bmp;

            Title = System.IO.Path.GetFileName(path);

            lookPageIndex = 0;
            return true;
        }

        private void OpenImageFile(object sender, RoutedEventArgs e)
        {
            string imgFilter = string.Join(";", imageExtensions.Select(ext => $"*{ext}"));

            var dialog = new OpenFileDialog() {
                Title = "画像を選択してください",
                Filter = $"画像ファイル|{imgFilter}|すべてのファイル|*.*",
                Multiselect = true,
            };

            if (dialog.ShowDialog() == true) {
                foreach (var file in dialog.FileNames) {
                    LoadImage(file);
                }
            }
        }

        private void OpenSelectFolderDialog() {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.IsFolderPicker = true;  // フォルダーを開く設定にする
                dialog.EnsureReadOnly = true;
                dialog.AllowNonFileSystemItems = false;
                dialog.DefaultDirectory = @"D:\OMU";

                //FileNotFoundException対策
                string current = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(current);

                //フォルダを開く
                var result = dialog.ShowDialog();
                if (result == CommonFileDialogResult.Ok)
                {
                    var folderPath = dialog.FileName;
                    var files = Directory.GetFiles(folderPath);
                    images = files
                        .Where(file => isImageFile(System.IO.Path.GetExtension(file)))
                        .ToList();

                    FileViewer.ItemsSource = images;
                }
            }
        }

        private void FileViewer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (FileViewer.SelectedItems.Count == 0) return;
            
            var selectedItem = FileViewer.SelectedItems[0] as string;

            OpenImage(selectedItem);
        }

        private void OpenImage(string? path) {
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
            {
                throw new FileNotFoundException($"ファイルが見つかりませんでした。path : {path}");
            }

            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.UriSource = new Uri(path);
            bmp.EndInit();
            Image1.Source = bmp;

            Title = System.IO.Path.GetFileName(path);
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenSelectFolderDialog();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right) {
                var selectedIndex = FileViewer.SelectedIndex;
                if (selectedIndex == -1 || selectedIndex == images.Count - 1) return;

                lookPageIndex = selectedIndex + 1;
                FileViewer.SelectedIndex += 1;

                var path = images[selectedIndex];
                OpenImage(path);
            }
            else if (e.Key == Key.Left) {
                var selectedIndex = FileViewer.SelectedIndex;
                if (selectedIndex == -1 || selectedIndex == 0) return;

                lookPageIndex = selectedIndex - 1;
                FileViewer.SelectedIndex -= 1;

                var path = images[selectedIndex];
                OpenImage(path);

            }
        }
    }
}
