using System;
using System.Collections.Generic;
using System.Linq;

namespace Tinkov
{
    public class Programm
    {
        public static void Count(string[] domains, string[] responds)
        {
            var line = new string[2];
            for(int i = 0; i < responds.Length; i++)
            {
                line = responds[i].Split(' ');
                Console.WriteLine(FindDomainsCount(domains, line[0], line[1]));
            }
        }

        public static int FindDomainsCount(string[] domains, string start, string end)
        {
            int result = 0;
            for(int i = 0; i < domains.Length; i++)
            {
                if (domains[i].Length >= start.Length + end.Length)
                {
                    if (domains[i][..start.Length] == start && domains[i].Substring(domains[i].Length - end.Length) == end)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
        public static void Main()
        {
            string[] nm = Console.ReadLine().Split(' ');
            string star = "STAR";
            int n = int.Parse(nm[0]);
            if (n < 1 || n > Math.Pow(10, 5))
            {
                throw new ArgumentOutOfRangeException("n is incorrect");
            }
            int m = int.Parse(nm[1]);
            if (m < 1 || m > Math.Pow(10, 5))
            {
                throw new ArgumentOutOfRangeException("m is incorrect");
            }
            string[] dom = new string[n];
            for(int i = 0; i < n; i++)
            {
                dom[i] = Console.ReadLine();
                if (dom[i].Length > Math.Pow(10, 5))
                {
                    throw new ArgumentOutOfRangeException("line is too big");
                }
                for(int j = 0; j < dom[i].Length; j++)
                {
                    if (!star.Contains(dom[i][j]))
                    {
                        throw new ArgumentException("words are not S T A R in domains");
                    }
                }
            }
            if (dom.Sum(n=>n.Length) > 2 * Math.Pow(10, 6))
            {
                throw new ArgumentOutOfRangeException("domains are too big");
            }
            string[] resp = new string[m];
            string[][] line = new string[m][];
            for (int i = 0; i < m; i++)
            {
                resp[i] = Console.ReadLine();
                line[i] = resp[i].Split(' ');
                if (line[i][0].Length > Math.Pow(10, 5) || line[i][1].Length > Math.Pow(10,5))
                {
                    throw new ArgumentOutOfRangeException("line is too big");
                }
                for (int j = 0; j < resp[i].Length; j++)
                {
                    if (!(star.Contains(resp[i][j])) && resp[i][j] != ' ')
                    {
                        throw new ArgumentException("words are not S T A R in responds");
                    }
                }
            }
            if (line.Sum(n => n[0].Length) > 2 * Math.Pow(10, 6) || line.Sum(n => n[1].Length) > 2 * Math.Pow(10, 6))
            {
                throw new ArgumentOutOfRangeException("responds are too big");
            }
            Count(dom, resp);
        }
    }
}
