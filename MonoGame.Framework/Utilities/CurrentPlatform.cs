// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Runtime.InteropServices;
using System;

namespace MonoGame.Utilities
{
    internal enum OS
    {
        Windows,
        Linux,
        MacOSX,
        Unknown
    }

    internal static class CurrentPlatform
    {
        private static OS os = OS.Linux;

        public static OS OS
        {
            get
            {
                return os;
            }
        }

    }

    public static class PlatformParameters
    {
        /// <summary>
        /// If true, MonoGame will detect the CPU architecture (x86 or x86-64) and add the "./x86" or "./x64" folder to the
        /// native DLL resolution paths. This allows MonoGame to work with Any CPU by loading the correct dependencies at runtime.
        /// If false, MonoGame will look for native DLLs in the executing folder, which typically is the .exe home.
        ///
        /// This parameter only works on Windows and doesn't affect other platforms.
        /// </summary>
        public static bool DetectWindowsArchitecture = (CurrentPlatform.OS == OS.Windows ? true : false);
    }

    internal static class NativeHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        private static bool _dllDirectorySet = false;

        public static void InitDllDirectory()
        {

        }
    }
}

