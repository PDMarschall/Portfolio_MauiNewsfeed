﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_MauiNewsfeed.Services
{
    public class WindowService
    {
        public Window MainWindow { get; set; }
        public WindowService()
        {
            MainWindow = Application.Current.Windows.First();
        }        
    }
}
