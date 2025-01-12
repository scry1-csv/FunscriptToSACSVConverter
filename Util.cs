using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunscriptToSACSVConverter
{
    public static class Util
    {
        public static void ShowMessageBoxTopMost(string message) => MessageBox.Show(message, "結果", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

        public static void ShowErrorMessageBoxTopMost(string message) => MessageBox.Show(message, "エラー", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

    }
}
