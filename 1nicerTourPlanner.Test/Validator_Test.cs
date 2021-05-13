using _1nicerTourPlanner.BusinessLayer;
using NUnit.Framework;

namespace _1nicerTourPlanner.Test
{
    public class Validator_Test
    {
        Validator validator = new Validator();

        [Test]
        public void is_alphabet_test()
        {
            Assert.IsTrue(validator.IsAlphabet("Test"));
        }

        [Test]
        public void is_alphabet_should_fail_test()
        {
            Assert.IsFalse(validator.IsAlphabet("Testä"));
        }

        [Test]
        public void is_alphabet_or_number_test()
        {
            Assert.IsTrue(validator.IsAlphabetOrNumber("Test"));
            Assert.IsTrue(validator.IsAlphabetOrNumber("4927"));
        }

        [Test]
        public void is_alphabet_and_number_test()
        {
            Assert.IsTrue(validator.IsAlphabetOrNumber("Test123"));
        }

        [Test]
        public void is_alphabet_and_number_should_fail_test()
        {
            Assert.IsFalse(validator.IsAlphabetOrNumber("ü2Test("));
        }

        [Test]
        public void is_allowed_input_test()
        {
            Assert.IsTrue(validator.IsAllowedInput("?=:"));
        }

        [Test]
        public void is_allowed_input_should_fail_test()
        {
            Assert.IsFalse(validator.IsAllowedInput("()"));
        }

        [Test]
        public void is_number_test()
        {
            Assert.IsTrue(validator.IsNumber("39393"));
        }

        [Test]
        public void is_number_shoudl_fail_test()
        {
            Assert.IsFalse(validator.IsNumber("xy"));
        }
    }
}
