using System.Text.RegularExpressions;

namespace InfoJobsPoc.Core.Vo
{
    public static class EmailVo
    {
        public static bool IsValid(string input)
        {
            var ret = Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return ret;
        }
    }
}
