﻿using _1nicerTourPlanner.BusinessLayer.Helper;
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
        public void is_not_alphabet__test()
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
        public void is_not_alphabet_and_number_test()
        {
            Assert.IsFalse(validator.IsAlphabetOrNumber("ü2Test("));
        }

        [Test]
        public void is_allowed_input_test()
        {
            Assert.IsTrue(validator.IsAllowedInput("?=:"));
        }

        [Test]
        public void is_not_allowed_input_test()
        {
            Assert.IsFalse(validator.IsAllowedInput("()"));
        }

        [Test]
        public void is_number_test()
        {
            Assert.IsTrue(validator.IsNumber("39393"));
        }

        [Test]
        public void is_no_number_test()
        {
            Assert.IsFalse(validator.IsNumber("xy"));
        }
        [Test]
        public void type_is_correct_test()
        {
            Assert.IsTrue(validator.IsAllowedType(".png"));
        }
        [Test]
        public void type_is_false_test()
        {
            Assert.IsFalse(validator.IsAllowedType(".ppt"));
        }
    }
}
