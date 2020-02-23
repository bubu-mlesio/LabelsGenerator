using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace LabelsGenerator
{
    internal class FindProgram
    {
        public string findPDFprogram(string pdf_name)
        {
            List<string> list_disk = new List<string>();
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo disk in allDrives)
            {
                list_disk.Add(disk.Name);
            }

            string fullName = "Not found";
            for (int i = 0; i < list_disk.Count; i++)
            {
                if (Directory.Exists(list_disk[i] + "\\Program Files\\" + pdf_name))
                {
                    fullName = list_disk[i] + @"Program Files\" + pdf_name;
                    break;
                }
                else if (Directory.Exists(list_disk[i] + "\\Program Files (x86)\\" + pdf_name))
                {
                    fullName = list_disk[i] + @"Program Files (x86)\" + pdf_name;
                    break;
                }
                else
                {
                    fullName = "Brak programu na dysku w domyślnej ścieżce: " + pdf_name;
                    MessageBox.Show(fullName, "404", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            return fullName;
        }
        public string findPrinter()
        {
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string printerName = "";
            foreach (ManagementObject printer in searcher.Get())
            {
                printerName = printer["Name"].ToString();
                //MessageBox.Show("Printer = " + printer["Name"], "Status drukarki", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ((printerName.Contains("Godex")) | (printerName.Contains("ZDesigner")) | (printerName.Contains("Zebra")))
                {
                    
                    if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        continue;
                        
                    }
                    else
                    {
                        printerName = printer["Name"].ToString();
                        break;
                    }
                }
                else
                {
                    printerName = "";
                }
            }
            if(String.IsNullOrEmpty(printerName))
                MessageBox.Show("Brak drukarki etykiet", "Status drukarki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return printerName;
        }
    }
}