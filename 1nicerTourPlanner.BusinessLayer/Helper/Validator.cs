using System.Text.RegularExpressions;

namespace _1nicerTourPlanner.BusinessLayer.Helper
{
    public class Validator
    {
        public bool IsAlphabet(string input)
        {
            Regex r = new Regex("^[a-zA-Z]+$");
            if (r.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public bool IsAlphabetOrNumber(string input)
        {
            Regex r = new Regex("^[a-zA-Z0-9]+$");
            if (r.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public bool IsAllowedInput(string input)
        {
            Regex r = new Regex("^[a-zA-Z0-9-_.:,!?=]+$");
            if (r.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        public bool IsAllowedInputExtended(string input)
        {
            {
                Regex r = new Regex("^[a-zA-Z0-9äöüÄÖÜ_.:,!?=-]+$");
                if (r.IsMatch(input))
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsNumber(string input)
        {
            Regex r = new Regex("^[0-9]+$");
            if (r.IsMatch(input))
            {
                return true;
            }
            return false;
        }
        public bool IsAllowedType(string input)
        {
            if (input == ".png" || input == ".pdf" || input == ".txt")
            {
                return true;
            }
            return false;
        }
    }
}
