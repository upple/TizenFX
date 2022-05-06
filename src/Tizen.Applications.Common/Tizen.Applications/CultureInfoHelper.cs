/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using Tizen;

namespace Tizen.Applications
{
    internal static class CultureInfoHelper
    {
        private const string LogTag = "Tizen.Applications";
        private static bool _initialized = false;
        private static Dictionary<string, string> _cultureNames = new Dictionary<string, string>();
        private static readonly object _lock = new object();
        private const string _pathCultureInfoDll = "/usr/share/dotnet.tizen/framework/i18n/CultureInfoData.dll";

        internal static class DllLoader
        {
            delegate Dictionary<string, string> API();
            static API method;
            static bool init = false;
            static void Initialize()
            {
                Assembly u = Assembly.LoadFile(_pathCultureInfoDll);
                Module[] modules = u.GetModules();
                Type t = modules[0].GetType("CultureInfoData.ClassLib");
                MethodInfo minfo = t.GetMethod("GetCultureNames");
                method = (API)Delegate.CreateDelegate(typeof(API), minfo);
                init = true;
            }

            public static Dictionary<string, string> GetCultureNames() {
                if (init == false)
                    Initialize();
                return method();
            }
        };

        public static void Initialize()
        {
            if (File.Exists(_pathCultureInfoDll))
            {
                try
                {
                    _cultureNames = DllLoader.GetCultureNames();
                }
                catch
                {
                    Log.Warn(LogTag, "Failed to load CultureInfoData.dll");
                }
            }

            _initialized = true;
        }

        // private static void ParseCultureInfoXml()
        // {
        //     XmlDocument doc = new XmlDocument();
        //     doc.Load(_pathCultureInfoXml);
        //     XmlElement root = doc.DocumentElement;
        //     foreach (XmlElement node in root.ChildNodes)
        //     {
        //         if (node.Name != "name" && node.FirstChild == null)
        //         {
        //             continue;
        //         }

        //         string lang = node.GetAttribute("xml:lang");
        //         string cultureName = node.FirstChild.Value;
        //         if (!string.IsNullOrEmpty(lang) && !string.IsNullOrEmpty(cultureName))
        //         {
        //             try
        //             {
        //                 _cultureNames.Add(lang, cultureName);
        //             }
        //             catch (ArgumentException e)
        //             {
        //                 Log.Error(LogTag, "ArgumentException: " + e.Message);
        //             }
        //         }
        //     }
        // }

        public static string GetCultureName(string locale)
        {
            Log.Error(LogTag, "[TEST_C] Start");
            lock (_lock)
            {
                if (!_initialized)
                {
                    Log.Error(LogTag, "[TEST_C] Initialize Start");
                    Initialize();
                    Log.Error(LogTag, "[TEST_C] Initialize Finish");
                }
                Log.Error(LogTag, "[TEST_C] dic size: " + _cultureNames.Count);
                if (_cultureNames.TryGetValue(locale.ToLowerInvariant(), out string cultureName))
                {
                Log.Error(LogTag, "[TEST_C] TryGetValue Finish");
                    return cultureName;
                }
                Log.Error(LogTag, "[TEST_C] TryGetValue Finish");
            }

            return string.Empty;
        }
    }
}
