using Extensions.SystemExt.Serialization;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace Extensions.MicrosoftExt
{
    public static class FileExt
    {
        public static void SavelBitmapImageToPicturesAsPng(Bitmap image)
        {
            var openFileDialog = CreateSaveFileDialog("C:\\Users\\Work\\Pictures", ".png");
            var filePath = TryGetSaveFilePathFromDialog(openFileDialog);
            if (image != null)
                image.Save(filePath, ImageFormat.Png);
        }

        public static void SaveJsonToFileUsingDataContract<T>(
            T item,
            string ext)
        {
            var openFileDialog = CreateSaveFileDialog("C:\\Users\\Work", ext);
            var filePath = TryGetSaveFilePathFromDialog(openFileDialog);
            var settings = new JsonSerializerSettings() { ContractResolver = new MyContractResolver() };
            var json = JsonConvert.SerializeObject(item, settings);
            using (var file = new StreamWriter(filePath))
            {
                file.WriteLine(json);
            }
        }

        public static T OpenFromJsonFileUsingDataContract<T>(string ext)
            where T: class
        {
            var openFileDialog = CreateOpenFileDialog("C:\\Users\\Work", ext);
            var filePath = TryGetOpenFilePathFromDialog(openFileDialog);
            string jsonText = string.Empty;
            using (var file = new StreamReader(filePath))
            {
                jsonText = file.ReadToEnd();
            }
            return JsonConvert.DeserializeObject(jsonText) as T;
        }

        private static string TryGetSaveFilePathFromDialog(SaveFileDialog saveFileDialog)
        {
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != null && saveFileDialog.FileName.Length != 0)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return GetDefaultFileName();
            }
        }

        private static SaveFileDialog CreateSaveFileDialog(
            string initialDirectory = null,
            string defaultExt = null)
        {
            var saveFileDialog = new SaveFileDialog();
            if (initialDirectory != null)
            {
                saveFileDialog.InitialDirectory = initialDirectory;
            }
            if (defaultExt != null)
            {
                saveFileDialog.DefaultExt = defaultExt;
            }
            saveFileDialog.FileName = GetDefaultFileName();
            return saveFileDialog;
        }

        private static string TryGetOpenFilePathFromDialog(OpenFileDialog openFileDialog)
        {
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null && openFileDialog.FileName.Length != 0)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return GetDefaultFileName();
            }
        }

        private static OpenFileDialog CreateOpenFileDialog(
            string initialDirectory = null,
            string defaultExt = null)
        {
            var openFileDialog = new OpenFileDialog();
            if (initialDirectory != null)
            {
                openFileDialog.InitialDirectory = initialDirectory;
            }
            if (defaultExt != null)
            {
                openFileDialog.Filter = $"frac files (*{defaultExt})|*{defaultExt}";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
            }
            openFileDialog.FileName = GetDefaultFileName();
            return openFileDialog;
        }

        private static string GetDefaultFileName()
        {
            var dateTime = DateTimeOffset.Now;
            return $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}-{dateTime.Hour}-{dateTime.Minute}-{dateTime.Second}";
        }
    }
}
