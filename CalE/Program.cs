using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalE
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("CalE 1.0 ©兆邦中国 2015");
            Console.WriteLine("请输入需要计算e的位数（至少20位）");
            int range = int.Parse(Console.ReadLine());

            sbyte[] i = new sbyte[range + 2];
            i[0] = 1;
            sbyte[] e = new sbyte[range + 2];

            long x = 1;
            long y = 2;
            e[0] = 1;
            for (x = 1; x < 11; x++)
            {
                i = Divide(i, x);
                e = Add(e, i);
            }

            Console.Write(e[0]);
            Console.Write(".");

            for (x = 11; y <= range; x++)
            {
                i = Divide(i, x);
                e = Add(e, i);
                while (i[y] == 0)
                {
                    if (y > range) break;
                    Console.Write(e[y - 2]);
                    y++;
                }

            }

            //for (x = 1; x < e.Count();x++ )
            //{
            //    if (i[x] != 0)
            //        break;
            //    Console.Write(e[x]);
            //}

            Console.WriteLine();
            Console.WriteLine("已完成");
            Console.Read();

            //e = Divide(i, 13);
        }

        static sbyte[] Add(sbyte[] a, sbyte[] b)
        {
            sbyte[] c = new sbyte[Math.Min(a.LongCount(), b.LongCount())];
            long i;
            for (i = c.LongCount()-1; i>0; i--)
            {
                c[i] += (sbyte)(a[i] + b[i]);
                if(c[i]>9)
                {
                    c[i] -= 10;
                    c[i - 1]++;
                }
            }
            c[0] += (sbyte)(a[0] + b[0]);
            return c;
        }

        static sbyte[] Minus(sbyte[] a, sbyte[] b)
        {
            sbyte[] c = new sbyte[Math.Min(a.LongCount(), b.LongCount())];
            long i;
            for (i=c.LongCount()-1;i>0;i--)
            {
                c[i] += (sbyte)(a[i] - b[i]);
                if(c[i]<0)
                {
                    c[i] += 10;
                    c[i - 1]--;
                }
            }
            c[0] += (sbyte)(a[0] - b[0]);
            return c;
        }

        static sbyte[] Divide(sbyte[] a , long b)
        {
            long i;

            long x = 0;

            sbyte[] c = new sbyte[a.LongCount()];
            for (i = 0; i < c.LongCount()-1; i++)
            {
                c[i] = (sbyte)((a[i] + x) / b);
                x = (x + a[i] - c[i] * b) * 10;
            }
            return c;
        }
    }

    
}
