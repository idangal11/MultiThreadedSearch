
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MultiThreadedSearch;


namespace ConsoleApp4
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            int nThreads = int.Parse(args[3]);
            int delta = int.Parse(args[3]);
            List<string> text = File.ReadAllLines(args[0]).ToList();
            //@"C:\Users\idang\OneDrive\Documents\test.txt"
            string StringToSearch = args[1];
          
            int div = 0;
            div = text.Count / nThreads;
            

            findWords.lines = text;
            findWords.startLine = 0;
            findWords.endLine = div;
            findWords.StringToSearch = StringToSearch;
            findWords.delta=delta;

            for (int i = 0; i < nThreads; i++)
            {
                Thread thread = new Thread(findWords.findCorrectWords);               
                thread.Start();

                Thread.Sleep(2000);
                findWords.startLine += div;
                findWords.endLine += div;             

            }
        }
    } 
}