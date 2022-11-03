﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit9_Trader;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit9_Trader.Tests
{
    [TestClass()]
    public class SimpleTradeValidatorTests
    {
        [TestMethod()]
        public void TestGoodCurrencyString()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "4444", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TestShortCurrencyString()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAA", "4444", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TestLongCurrencyString()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAAABBBB", "4444", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TestNormalTrade()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "4444", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void TestAmount999()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "999", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void TestAmount1000()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "1000", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void TestAmountNeg10000()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "-10000", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod()]
        public void TestAmount100k()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "1000000", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void TestAmount101k()
        {
            //Arrange
            var logger = new ConsoleLogger();
            var tradeValidator = new SimpleTradeValidator(logger);
            string[] strData = { "AAABBB", "1000001", "1.00" };

            //Act
            bool result = tradeValidator.Validate(strData);

            //Assert
            Assert.IsFalse(result);
        }
    }
}