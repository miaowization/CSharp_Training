﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace SeleniumTests
{
    public class Settings
    {
        public static string file = "C:/Users/Aigul/Documents/GitHub/CSharp_Training/SeleniumTests/SeleniumTests/Settings.xml";
        private static string baseURL;
        private static string login;
        private static string password;
        private static XmlDocument document;

        static Settings()
        {
            if(!System.IO.File.Exists(file))
            {
                throw new Exception("Problem: settings file not found: " + file);
            }
            document = new XmlDocument();
            document.Load(file);
        }

        
        public static string BaseURL
        {
            get
            {
                if(baseURL == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("BaseURL");
                    baseURL = node.InnerText;
                    char[] charsToTrim = {'\u005c', '"'};
                    baseURL = baseURL.TrimEnd(charsToTrim);
                }
                return baseURL;
            }
        }

        public static string Login
        {
            get
            {
                if (login == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Login");
                    login = node.InnerText;
                }
                return login;
            }
        }

        public static string Password
        {
            get
            {
                if (password == null)
                {
                    XmlNode node = document.DocumentElement.SelectSingleNode("Password");
                    password = node.InnerText;
                }
                return password;
            }
        }

    }
}
