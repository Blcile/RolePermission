using System;
using RolePermission.Common;
using Xunit;

namespace UnitTestP
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var s = Encrypt.DecodeText("123456");
            Console.WriteLine(s);
        }
    }
}
