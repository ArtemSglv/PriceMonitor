﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;
namespace PriceMonitor
{
    public abstract class StockExchange
    {
        public struct CurrentPrice
        {
            public double ask;
            public double bid;
            public override string ToString()
            {
                string countDigitAfterComma = ConfigurationManager.AppSettings.Get("countDigitAfterComma");
                return (ask != 0.0d && bid != 0.0d) ? "asks: " + ask.ToString("F" + countDigitAfterComma) + "\r\nbids: " + bid.ToString("F" + countDigitAfterComma) : "";
            }
            public void Clear()
            {
                ask = 0.0d;
                bid = 0.0d;
            }
        }

        public string Name { get; set; }
        public string UrlAPI { get; set; }
        public string Url { get; protected set; }
        public List<string> AvailableCoins { get; set; }
        public Dictionary<string, CurrentPrice> Price { get; set; }
        private bool paused;
        public bool Paused
        {
            get
            {
                if (DateTime.Now.Subtract(pauseTime).TotalSeconds > 25)
                {
                    Paused = false;
                }
                return paused;

            }
            set
            {
                if (value)
                    pauseTime = DateTime.Now;
                else pauseTime = DateTime.MinValue;
                paused = value;
            }
        }
        private DateTime pauseTime = DateTime.MinValue;

        public StockExchange() { Paused = false; }

        public abstract void GetPrice();

        public abstract List<string> GetAssets();
        public override string ToString()
        {
            return Name + ": " + AvailableCoins.Count + "\r\n";
        }
        public abstract string GetUrl(string coin);
    }
}
