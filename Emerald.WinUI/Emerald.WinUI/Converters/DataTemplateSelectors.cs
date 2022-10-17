﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.WinUI.Converters
{
    public class TaskViewTemplateSelector : DataTemplateSelector
    {

        public DataTemplate String { get; set; }
        public DataTemplate Progress { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return ((Models.ITask)item is Models.StringTask) ? String : Progress;
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return ((Models.ITask)item is Models.StringTask) ? String : Progress;
        }
    }
}
