﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Tiny
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int port = 12345;
        private KinectServer server;

        public App() {
            this.server = new KinectServer(App.port);
            this.server.Start();
        }
    }
}