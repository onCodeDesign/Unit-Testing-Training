namespace Samples
{
    class StringParser
    {
        public int SumDigits(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                int cAsInt = (int) char.GetNumericValue(c);
                sum += cAsInt;
            }

            return sum;
        }
    }
}
