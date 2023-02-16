using System;
using System.Security.Cryptography;
using System.Text;

namespace RootCoin
{
    class MerkleRoot
    {
        public MerkleRoot()
        {
            string tx1Hash = "aad28e85f31ae79339b49d114d7c1811d2c667681a1904ebbc326842a0a81985";
            string tx2Hash = "b963d3426088217357b146d5600817c54f93c2ea1a23126988e36460015ffc0e"; 
            string tx3Hash = "82498f4da1e1b662b02e95150dc9fd64307ee96b35657f75c7abd82530168ce3"; 
            string tx4Hash = "ceecfd37686a3ed1759d3cef25e412a800fc8e8846154dbe2a2d72b2af3e3b64";

            HashAlgorithm sha256Hasher = SHA256.Create();

            // Concat TX1 and TX2
            string tx12Hash = tx1Hash + tx2Hash;

            // Hash the tx1/2 concat once (12A)
            byte[] result12ABytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(tx12Hash)); // compute the hash of data1
            string hexResults12A = BitConverter.ToString(result12ABytes).Replace("-", ""); // convert the resultant byte array to a hex string

            // Hash the hexresult 12A a second time
            byte[] result12BBytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(hexResults12A));
            string hexResults12B = BitConverter.ToString(result12BBytes).Replace("-", "");

            // Print the result
            Console.WriteLine("TX12: " + hexResults12B);




            // Concat TX3 and TX4
            string tx34Hash = tx3Hash + tx4Hash;

            // Hash the tx1/2 concat once (12A)
            byte[] result34ABytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(tx34Hash)); // compute the hash of data1
            string hexResults34A = BitConverter.ToString(result34ABytes).Replace("-", ""); // convert the resultant byte array to a hex string

            // Hash the hexresult 12A a second time
            byte[] result34BBytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(hexResults34A));
            string hexResults34B = BitConverter.ToString(result34BBytes).Replace("-", "");

            // Print the result
            Console.WriteLine("TX34: " + hexResults34B);




            // Concat TX12B and TX34B
            string tx1234Hash = hexResults12B + hexResults34B;

            // Hash the tx1/2 concat once (12A)
            byte[] result1234ABytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(tx1234Hash)); // compute the hash of data1
            string hexResults1234A = BitConverter.ToString(result1234ABytes).Replace("-", ""); // convert the resultant byte array to a hex string

            // Hash the hexresult 12A a second time
            byte[] result1234BBytes = sha256Hasher.ComputeHash(Encoding.ASCII.GetBytes(hexResults1234A));
            string hexResults1234B = BitConverter.ToString(result1234BBytes).Replace("-", "");

            // Print the result
            Console.WriteLine("TX1234: " + hexResults1234B);
        }
    }
}