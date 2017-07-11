using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"H:\temp\td_1"); //manifest location
            string s = File.ReadAllText("manifest.data"); //manifest filename
            char[] a = "THEQUICKBROWNFOXJUMPSOVERTHELAZYDOGthequickbrownfoxjumpsoverthelazydog0123456789".ToCharArray();
            bool b = false;
            try
            {
                File.Delete("out.txt");
            }
            catch
            { }
            try
            {
                File.Delete("out2.txt");
            }
            catch
            { }
            try
            {
                File.Delete("out3.txt");
            }
            catch
            { }
            foreach (char c in s.ToCharArray())
            {
                if (a.Contains(c) || c.Equals('_') || c.Equals('.'))
                {
                    File.AppendAllText("out.txt", c.ToString());
                    b = false;
                }
                else
                {
                    if (!b)
                    {
                        File.AppendAllText("out.txt", "\r\n");
                        b = true;
                    }
                }
            }
            string[] s7 = File.ReadAllLines("out.txt");
            bool f = false;
            foreach (string s2 in s7)
            {
                if (s2.Contains(".unity3d"))
                {
                    if (!f)
                    {
                        File.AppendAllText("out2.txt", s2 + "\t\t\t");
                        f = !f;
                    }
                    else if (f)
                    {
                        string x = "https://td-assets.bn765.com/1/production/5.6/Android/" + s2 + "\r\n"; //replace /1/ with the number relevant to the update
                        x = x.Replace("Android/0", "Android/");
                        File.AppendAllText("out2.txt", x);
                        f = !f;
                    }
                }
            }
            string[] s8 = File.ReadAllLines("out2.txt");
            Array.Sort(s8);
            File.WriteAllLines("out3.txt", s8);
            //string[] s = File.ReadAllLines("selected_lines.txt");
            //foreach (string s2 in s)
            //{
            //    File.AppendAllText("out4.txt", s2.Split(new string[] { "\t\t\t" }, StringSplitOptions.RemoveEmptyEntries)[1] + "\r\n");
            //}
        }
    }
}
