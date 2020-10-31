using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AprilApp_10
{
    class Program
    {
        public enum NpgsqlType
        {
            [Text("anyarray")]
            Array = -2147483648,
            Unknow = 0,
            [Text("int8")]
            Bigint = 1,
            [Text("bool")]
            Boolean = 2,
            [Text("box")]
            Box = 3,
            [Text("bytea")]
            Bytea = 4,
            [Text("circle")]
            Circle = 5
        }

        static void Main(string[] args)
        {
            Console.Write("Введите значение: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"Строка атрибута для значения {num}: {ToText(num)}");
            Console.ReadKey();
        }

        public static string ToText(int val)
        {
            NpgsqlType npg = (NpgsqlType)val;
            Type type = typeof(NpgsqlType);
            MemberInfo[] m = type.GetMember(npg.ToString());
            foreach(MemberInfo mInfo in m)
            {
                object[] attributes = mInfo.GetCustomAttributes(typeof(TextAttribute), false);
                foreach(object attribute in attributes)
                {
                    return ((TextAttribute)attribute).text;
                }
            }

            return "Для данного значения атрибут отсутствует";
        }
    }
}
