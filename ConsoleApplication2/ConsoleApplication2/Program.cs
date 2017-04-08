using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"../Dataset/amber_136466.html"))
            {

                string pattern = @"(?\sc[\w]*)";
                //宣告 Regex 忽略大小寫
                string input = sr.ReadLine();
                //規則字串
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                //將比對後集合傳給 MatchCollection
                MatchCollection matches = regex.Matches(input);
                int index = 0;
                // 一一取出 MatchCollection 內容
                foreach (Match match in matches)
                {
                    // 將 Match 內所有值的集合傳給 GroupCollection groups
                    GroupCollection groups = match.Groups;
                    // 印出 Group 內 word 值
                    Console.WriteLine(++index + ": " + groups["word"].Value.Trim());
                }
            }
        }
    }
}