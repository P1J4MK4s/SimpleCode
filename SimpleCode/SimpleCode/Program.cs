using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCode
{
    class Solution
    {
        public static int[] Solutions(string[] A, string[] B)
        {
            int[] result = new int[A.Length];
            int resIndex = 0;
            bool flagAllRight = true;
            for (int i = 0; i < A.Length; i++){
                for(int j = 0; j < B.Length; j++){
                    if (A[i].Contains(B[j]) == false)
                    {
                        flagAllRight = true;
                    }
                    else { 
                        flagAllRight = false;
                        break;
                    }
                }
                if (flagAllRight) { 
                    result[resIndex] = i;
                    resIndex++;
                }
            }
            Array.Resize(ref result, resIndex);
            return result;
        }
        static void Main(string[] args)
        {
            string[] A = new string[] { "unlock.microvirus.md", "visitwar.com","visitwar.de","fruonline.co.uk","australia.open.com","credit.card.us" };
            string[] B = new string[] { "microvirus.md","visitwar.de","piratebay.co.uk","list.stolen.credit.card.us"};
            int[] a = Solutions(A,B);
            for(int i = 0; i < a.Length; i++) {
                Console.Write(" {0} ",a[i]); 
            }
        }
    }
}
