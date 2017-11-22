﻿using System;

namespace Festispec.ViewModels.Routes
{
    public class Route
    {
        public string Key { get; set; }
        public Uri PageType { get; set; }
        public object Parameter { get; set; }
        public string[] Roles { get; set; }
    }
}