﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit9_Trader;
using System;
using System.Collections.Generic;
using System.Text;
using Unit9_Trader.Contracts;

namespace Unit9_Trader.Tests
{
    [TestClass()]
    public class URLTradeDataProviderTests
    {
        private int countStrings(IEnumerable<string> collectionOfStrings)
        {
            // count the trades
            int count = 0;
            foreach (var trade in collectionOfStrings)
            {
                count++;
            }
            return count;
        }


        [TestMethod()]
        public void TestSize1()
        {
            //Arrange
            ILogger logger = new ConsoleLogger();
            string tradeURL = "http://faculty.css.edu/tgibbons/trades4.txt";

            ITradeDataProvider tradeProvider = new URLTradeDataProvider(tradeURL, logger);

            //Act
            IEnumerable<string> trades = tradeProvider.GetTradeData();

            //Assert

            Assert.AreEqual(countStrings(trades), 4);
        }
    }
}