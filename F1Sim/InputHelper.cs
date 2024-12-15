namespace InputHelperSpace
{
    public static class InputHelper
    {

        public static int? ConvertStringToIntWithinRange(string s, int lower, int higher)
        {
            int result = -1;
            if (!int.TryParse(s, out result))
            {
                return null;
            }

            if (lower <= result && result < higher)
            {
                return result;
            }
            return null;
        }

        public static void WaitForInputThenContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press anything to contunue");//I Have a really hard time spelling contuie and gorgeous5
            Console.ReadLine();
            Console.Clear();
        }

        public static void CleanUp()
        {
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}