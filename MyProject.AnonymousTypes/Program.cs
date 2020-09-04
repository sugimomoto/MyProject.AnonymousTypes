using System;
using System.Collections.Generic;
using System.Linq;

namespace MyProject.AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Reference
            // https://docs.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types


            // new {} で生成できる。プロパティに型は指定できない？
            var v = new { Name = "Hello", Age = 33 };

            Console.WriteLine(v.Name);

            // 配列として指定することも可能。
            var anonymousArray = new[]
            {
                new { Name = "Kazuya", Age = 33},
                new { Name = "Hitomi", Age = 32}
            };

            foreach (var item in anonymousArray)
            {
                Console.WriteLine(item.Name + ":" + item.Age);
            }

            // 通常はLINQのselectで用いられる
            var userList = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Kazuya",
                    Age = 33
                },
                new User()
                {
                    Id = 2,
                    Name = "Hitomi",
                    Age = 33
                },
                new User()
                {
                    Id = 3,
                    Name = "Yuta",
                    Age = 33
                }
            };

            // users は IdとNameのプロパティが存在する IEnumerable 匿名型になる
            var users = from user in userList
                        select new { user.Id, user.Name };

            foreach (var item in users)
            {
                Console.WriteLine(item.Name + ":" + item.Id);
            }

            // 匿名型はObject型以外にキャストできない
            var castObj = (object)users;

            // 元の型に戻そうと思ってもできない。以下はエラーになる
            // var castUser = (IEnumerable<User>)users;

            // メソッドの戻り値の型としても指定できない。
            // Objectになるので、何も操作できなくなってしまう。
            var response = GetAnonimous();

        }

        public static object GetAnonimous()
        {
            return new { Name = "Hello", Age = 33 };
        }

    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
    }

    public class AnonymousTypesSample
    {
        public AnonymousTypesSample()
        {
        }
    }
}
