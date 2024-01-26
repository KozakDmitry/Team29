﻿
using Scripts.UI.Services.Windows;
using Scripts.UI.Windows;
using System;

namespace Scripts.StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowsID windowsID;
        public WindowBase windowPrefab;
    }
}
