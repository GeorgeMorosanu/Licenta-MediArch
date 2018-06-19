﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediArch.Models
{
    public static class StringCryptoHelper
    {
        //3DES
        public static string Encrypt(this string input)
        {
            string key = "abcd-efgh-ijklmn";
            byte[] inputArray = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(this string input)
        {
            if (input != "" && input != null && (input.Contains("=") || input.Contains("+")))
            {
                string key = "abcd-efgh-ijklmn";
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            else
            {
                return input;
            }
        }
        public static string CollapseAnswerText(this string input)
        {
            if (input.Length > 80)
            {
                return input.Substring(0, 77)+"...";
            }
            else
            {
                return input;
            }
        }

        public static string Collapse(this string input)
        {
            if (input.Length > 40)
            {
                return input.Substring(0, 37) + "...";
            }
            else
            {
                return input;
            }
        }
    }
}
