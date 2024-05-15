using System;
using static AESProject.AESClass;
namespace AESProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string option;
            string plain, plaindrom = "";
            string key;
            string cipher = "";
            string input = "";
            string chunk;
            string sb = "";
            Console.WriteLine("Welcome to AES World!\n");
            Console.WriteLine("Enter The Message You Want To Keep A Secret ;) Or Reveal O_O");
            plain = Console.ReadLine();
            Console.WriteLine("Enter the secret key(256-bit/16 characters) :O");
            key = Console.ReadLine();
            char[] charValues = plain.ToCharArray();
            string hexOutput = "";
            foreach (char _eachChar in charValues)
            {
                int value = Convert.ToInt32(_eachChar);
                hexOutput += String.Format("{0:X}", value);
            }

            Console.WriteLine("Enter Option:");
            option = Console.ReadLine();

            if (option == "E")
            {
                if (hexOutput.Length < 32)
                {
                    while (hexOutput.Length < 32)
                        hexOutput = "0" + hexOutput;
                }
                else
                {
                    for (int i = 0; i < hexOutput.Length; i += 32)
                    {
                        chunk = hexOutput.Substring(i, Math.Min(32, hexOutput.Length - i));

                        while (chunk.Length < 32)
                            chunk = "0" + chunk;

                        input += chunk;

                        cipher += AESClass.Encrypt(chunk, key);

                    }
                }
                Console.WriteLine("Your Encrypted Message:");
                Console.WriteLine(cipher);
            }
            else if(option == "D")
            {
                if (plain.Length < 32)
                {
                    while (plain.Length < 32)
                        plain = "0" + plain;
                }
                else
                {
                    for (int i = 0; i < plain.Length; i += 32)
                    {
                        chunk = plain.Substring(i, Math.Min(32, plain.Length - i));

                        while (chunk.Length < 32)
                            chunk = "0" + chunk;

                        input += chunk;

                        plaindrom += AESClass.Decrypt(chunk, key);

                    }
                }

                for (int i = 0; i < plaindrom.Length; i += 2)
                {
                    string hs = plaindrom.Substring(i, 2);
                    sb += Convert.ToChar(Convert.ToUInt32(hs, 16));
                }
                Console.WriteLine("The Decrypted:");
                Console.WriteLine(sb);
            }
        }
    }
}
