using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using EllipticCurve;

namespace RootCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateKey key1 = new PrivateKey();
            PublicKey wallet1 = key1.publicKey();

            PrivateKey key2 = new PrivateKey();
            PublicKey wallet2 = key2.publicKey();

            Blockchain rootcoin = new Blockchain(2, 100);

            Console.WriteLine("Start the miner.");
            rootcoin.MinePendingTransactions(wallet1);
            Console.WriteLine("\nBalance of wallet1 is $" + rootcoin.GetBalanceOfWallet(wallet1).ToString() + "\n");

            Transaction tx1 = new Transaction(wallet1, wallet2, 10);
            tx1.SignTransaction(key1);
            rootcoin.addPendingTransaction(tx1);
            rootcoin.MinePendingTransactions(wallet2);
            Console.WriteLine("\nBalance of wallet1 is $" + rootcoin.GetBalanceOfWallet(wallet1).ToString() + "\n");
            Console.WriteLine("\nBalance of wallet1 is $" + rootcoin.GetBalanceOfWallet(wallet2).ToString() + "\n");



            string blockJson = JsonConvert.SerializeObject(rootcoin, Formatting.Indented);
            Console.WriteLine(blockJson);

            //rootcoin.GetLastestBlock().PreviousHash = "12345";

            if (rootcoin.IsChainValid())
            {
                Console.WriteLine("Blockchain is valid!!\n");
            }
            else
            {
                Console.WriteLine("Blockchain is NOT valid!!\n");
            }
        }
    }
}