using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace FunscriptToSACSVConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new() { Filter = "funscript|*.funscript;" };

            bool? result = dlg.ShowDialog();

            if (result == true)
                OpenFile(dlg.FileName);
        }

        private void OpenFile(string path)
        {
            if (Path.GetExtension(path) == ".funscript")
            {
                var csv = ScriptConverter.ConvertScript(path);
                SACSV.WriteCsv(csv);
                Util.ShowMessageBoxTopMost("変換完了");
            }
            else
                Util.ShowErrorMessageBoxTopMost("対応していないファイル形式です");
        }

        private void Window_PreviewDragOver(object sender, DragEventArgs e)
        {
            // ドラッグされているのがファイルなら許容、それ以外なら不許可
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string[]? dropped = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (dropped is null)
            {
                Util.ShowErrorMessageBoxTopMost("ドラッグ&ドロップの処理に失敗しました！");
                return;
            }

            if (dropped.Length == 1)
                OpenFile(dropped[0]);
            else
                Util.ShowErrorMessageBoxTopMost("開けるのは同時に一つのファイルだけです！");
        }

    }
}