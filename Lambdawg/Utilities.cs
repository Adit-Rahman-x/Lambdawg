using System;
using System.IO;

namespace Lambdawg
{
    public static class Utilities
    {
        public static string ReadFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading file: " + ex.Message);
                return string.Empty;
            }
        }

        public static void WriteFile(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing file: " + ex.Message);
            }
        }
    }
}
