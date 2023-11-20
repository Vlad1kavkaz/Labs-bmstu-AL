using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class Tickers
    {
        public int Id { get; set; }
        public string TickerSymbol { get; set; }
    }

    public class Prices
    {
        public int Id { get; set; }
        public int TickerId { get; set; }
        public double Price { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class TodaysCondition
    {
        public int Id { get; set; }
        public int TickerId { get; set; }
        public bool State { get; set; }
    }

    public class StockContext : DbContext
    {
        public DbSet<Tickers> Tickers { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<TodaysCondition> TodaysCondition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=StockApp;User Id=sa;Password=MyStr0ngPassword!;");
        }
    }

    public class Program
    {
        async public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Any, 8888);

            tcpListener.Start();
            try
            {
                while (true)
                {
                    using var tcpClient = await tcpListener.AcceptTcpClientAsync();
                    var stream = tcpClient.GetStream();
                    byte[] data = new byte[256];
                    await stream.ReadAsync(data);
                    var s = Encoding.UTF8.GetString(data);
                    using (var context = new StockContext())
                    {
                        var ticker = context.Tickers.FirstOrDefault(t => t.TickerSymbol == s);
                        var price = context.Prices.FirstOrDefault(p => p.Id == ticker.Id);
                        await stream.WriteAsync(Encoding.UTF8.GetBytes(Convert.ToString(price)));
                    }
                }
            }
            finally
            {
                tcpListener.Stop();
            }

            
        }
    }
}

