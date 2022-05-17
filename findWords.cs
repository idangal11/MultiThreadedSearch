using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadedSearch
{
    internal class findWords
    {
        public static List<string> lines = new List<string>();
        public static int startLine;
        public static int endLine;
        public static int delta;
        public static String StringToSearch;

        public static void findCorrectWords()
        {
            
            List<char> str = new List<char>();
             int c = 0;
             
             int d = 0;
             int flag = 1;
             int j;
             int i;

           for(int s=0; s< StringToSearch.Length;s++)
            {
                str.Add(StringToSearch[s]);
            }

            for (i = startLine; i < endLine; i++)
            {          
                for (j = 0; j < lines[i].Length; j++)
                {
                   
                    if (lines[i][j] == str[0])
                    {
                        int line = i;
                        int col = j;

                        while (c < str.Count)
                        {
                            if (flag == 1) { c = 1 ; flag = 0; }
                            d = delta;
                            if(d == 0)
                            {                      
                                j++;
                                if (flag == 0 && !(lines[i][j] == str[c])) { c = 0; flag = 1; break; } 
                            }

                            else
                            {                               
                                if (j+1 +d > lines[i].Length)
                                {
                                    d -= lines[i].Length - j;
                                   
                                    while(d > lines[i + 1].Length)
                                    {                                       
                                            d -= lines[i + 1].Length + 1;
                                            i++; j = -1;
          
                                    }
                                    i++; j = -1;
                                }
                                if(j+1+d == lines[i].Length)
                                {
                                    break;
                                }
                                                           
                                if (flag == 0 && !(lines[i][j + d + 1] == str[c])) { c = 0; flag = 1; break; } else { j = (j + d + 1); d = delta; }
                            }
                           
                            c++;
                            if (c == str.Count)
                            {               
                                c = 0;
                                flag = 1;
                                Console.WriteLine("[" + line + "," + col + "]");
                                break;
                            }
                        }
                    }
                }
            }           

        }
        

    }

}
                               