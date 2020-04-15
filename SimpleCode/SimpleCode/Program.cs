using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCode
{
    class Solution
    {
        public static int[] solution(string[] A, string[] B)
        {
            int[] result = new int[A.Length];
            int resIndex = 0;
            bool flagAllRight;
            var Btable = new HashSet<string>();
            for(int i = 0; i < B.Length; i++)
            {
                Btable.Add(B[i]);
            }
            for (int i = 0; i < result.Length; i++)
            {
                flagAllRight = true;
                if (Btable.Contains(A[i]))
                {
                    flagAllRight = !flagAllRight;
                }
                else
                {
                    string detectString = A[i];
                    do
                    {
                        if (detectString.Contains('.')) 
                        {
                            string[] forSplit = detectString.Split(new char[] { '.' }, 2);
                            detectString = forSplit[1];
                        }
                        flagAllRight = true;
                        if (Btable.Contains(detectString))
                        {
                            flagAllRight = false;
                            break;
                        }
                    } while (detectString.Contains('.'));
                }
                if (flagAllRight)
                {
                    result[resIndex] = i;
                    resIndex++;
                }
            }
            Array.Resize(ref result, resIndex);
            return result;
        }

        public static void Test1()
        {
            string[] A1 = new string[] { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us" };
            string[] B1 = new string[] { "microvirus.md", "visitwar.de", "piratebay.co.uk", "list.stolen.credit.card.us" };
            int[] a = solution(A1, B1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(" {0} ", a[i]);
            }
            Console.WriteLine();
        }
        public static void Test2()
        {
            int[] expected = {1,2,3,4};
            string[] A = new string[] { "rnhub.com", "ggrnhub.com", "com", "com.com", "newhub.com" };
            string[] B = new string[] { "rnhub.com", "hub.com", "rnhub.com.dot" };
            if (expected.SequenceEqual(solution(A, B)))
            {
                Console.WriteLine("First test done!");
            }
            else
            {
                Console.WriteLine("First test failed");
            }
        }
        public static void Test3()
        {
            int[] expected = {1};
            string[] A = new string[] { " ", " .com", "com. " };
            string[] B = new string[] { " " };
            if (expected.SequenceEqual(solution(A, B)))
            {
                Console.WriteLine("Second test done!");
            }
            else
            {
                Console.WriteLine("Second test failed");
            }
        } 
        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();
        }
    }
}
