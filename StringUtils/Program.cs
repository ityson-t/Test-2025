namespace StringUtils
{
    static class StringUtils
    {
        public static int CountVowels(string input)
        {
            int count = 0;
            foreach (var item in input)
            {
                if (item == 'a' || item == 'A' || item == 'e' || item == 'E' || item == 'o' || item == 'O' || item == 'i' || item == 'I' || item == 'u' || item == 'U')
                {
                    count++;
                }
            }
            return count;
        }
        public static string Truncate(string input, int maxLength)
        {
            string truncated = "";
            if (input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                for (int i = 0; i < maxLength; i++)
                {
                    truncated += input[i];
                }
                return truncated + "...";
            }
        }
        public static string Truncate(string input, int maxLength, string suffix)
        {
            string truncated = "";
            if (input.Length <= maxLength)
            {
                return input;
            }
            else
            {
                for (int i = 0; i < maxLength; i++)
                {
                    truncated += input[i];
                }
                return truncated + suffix;
            }
        }
        public static bool FindFirstAndLastIndex(string input, char charToFind, out int firstIndex, out int lastIndex)
        {
            bool isFind = false;
            firstIndex = -1;
            lastIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == charToFind)
                {
                    isFind = true;
                    firstIndex = i;
                    break;
                }
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == charToFind)
                {
                    isFind = true;
                    lastIndex = i;
                    break;
                }
            }
            return isFind;
        }
        public static string Repeat(string input, int count, string separator = "")
        {
            string repeatd = "";
            for (int i = 0; i < count-1; i++)
            {
                repeatd += input + separator;
            }
            return repeatd+input;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. 统计元音 ---");
            string text1 = "Programming is fun!";
            int vowelCount = StringUtils.CountVowels(text1);
            Console.WriteLine($"'{text1}' 中有 {vowelCount} 个元音。"); // 预期输出: 5

            Console.WriteLine("\n--- 2. 截断字符串 (重载) ---");
            string longText = "This is a very long string that needs to be truncated.";
            string truncated1 = StringUtils.Truncate(longText, 20);
            Console.WriteLine(truncated1); // 预期输出: This is a very long...

            string truncated2 = StringUtils.Truncate(longText, 20, "-->");
            Console.WriteLine(truncated2); // 预期输出: This is a very long-->

            Console.WriteLine("\n--- 3. 查找首末位置 (out 参数) ---");
            string text2 = "mississippi";
            char searchChar = 's';
            if (StringUtils.FindFirstAndLastIndex(text2, searchChar, out int first, out int last))
            {
                Console.WriteLine($"在 '{text2}' 中，'{searchChar}' 首次出现在索引 {first}，最后出现在索引 {last}。"); // 预期输出: 首次...2, 最后...6
            }

            if (!StringUtils.FindFirstAndLastIndex(text2, 'z', out int firstZ, out int lastZ))
            {
                Console.WriteLine($"在 '{text2}' 中未找到 'z'。索引: {firstZ}, {lastZ}"); // 预期输出: 未找到...索引: -1, -1
            }

            Console.WriteLine("\n--- 4. 创建重复字符串 (可选参数) ---");
            string repeated1 = StringUtils.Repeat("echo", 3);
            Console.WriteLine(repeated1); // 预期输出: echoechoecho

            string repeated2 = StringUtils.Repeat("echo", 3, ", ");
            Console.WriteLine(repeated2); // 预期输出: echo, echo, echo
        }
    }
}
