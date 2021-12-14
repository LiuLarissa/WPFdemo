using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;
using System.Windows;

namespace HealthCheckWpfDemo
{
    [ValueConversion(typeof(TreeNode),typeof(ContextMenu))]
    public class TreeViewContextMenu: IValueConverter
    {
        public static ContextMenu bloodContextMenu;
        //public static ContextMenu cancerContextMenu;
        public static ContextMenu blooditemContextMenu;
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TreeNode node = value as TreeNode;
            if (node == null)
                return null;

            if (node.id == 1)
                return bloodContextMenu;
            if (node.pid == 1)
                return blooditemContextMenu;
            //if (node.id == 2)
            //   return cancerContextMenu;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
