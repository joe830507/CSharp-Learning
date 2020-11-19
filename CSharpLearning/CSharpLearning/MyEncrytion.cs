using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CSharpLearning
{
    public class MyEncrytion : IDemonstrate
    {
        public void Demonstrate()
        {
            ShowHowToUseRSA();
        }
        //321 : MD5
        public void PrintMD5String()
        {
            System.Console.WriteLine("Please type in texts...");
            string input = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(input);
            MD5 md5 = MD5.Create();
            byte[] result = md5.ComputeHash(data);
            Console.WriteLine("Result:");
            foreach (var b in result)
            {
                Console.WriteLine(" 0x{0:x2}", b);
            }
        }
        //322 : SHA
        public void MySHA1()
        {
            using (FileStream fsin = File.Create($"D:/ver1.smp"))
            {
                byte[] buffer = new byte[256];
                Random rand = new Random();
                for (int i = 0; i < 50; i++)
                {
                    rand.NextBytes(buffer);
                    fsin.Write(buffer);
                }
            }
            File.Copy($"D:/ver1.smp", $"D:/ver2.smp", true);
            string curdir = $"D:/";
            string[] files = Directory.GetFiles(curdir, "*.smp");
            SHA1 sha = SHA1.Create();
            foreach (var f in files)
            {
                using (FileStream fs = File.OpenRead(f))
                {
                    byte[] result = sha.ComputeHash(fs);
                    Console.WriteLine(Path.GetFileName(f));
                    StringBuilder bd = new StringBuilder();
                    foreach (var b in result)
                    {
                        bd.AppendFormat("{0:X2}", b);
                    }
                    Console.WriteLine(bd.ToString() + "\n");
                }
            }
            sha.Dispose();
        }
        //323 : AES (CBC:With iv)
        public byte[] EncryptData(byte[] key, byte[] iv, string content)
        {
            byte[] res = null;
            using (Aes aes = Aes.Create())
            {
                using (MemoryStream msbase = new MemoryStream())
                {
                    using (CryptoStream cstr = new CryptoStream(msbase, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cstr))
                        {
                            writer.Write(content);
                        }
                    }
                    res = msbase.ToArray();
                }
            }
            return res;
        }
        public string DecryptData(byte[] key, byte[] iv, byte[] dataContent)
        {
            string res = null;
            using (Aes aes = Aes.Create())
            {
                using (MemoryStream msbase = new MemoryStream(dataContent))
                {
                    ICryptoTransform trf = aes.CreateDecryptor(key, iv);
                    using (CryptoStream cstr = new CryptoStream(msbase, trf, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cstr))
                        {
                            res = reader.ReadToEnd();
                        }
                    }
                }
            }
            return res;
        }
        public void ShowHowToUseAES()
        {
            string msgToEnc = "Experimental texts";
            byte[] key;
            byte[] iv;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                key = aes.Key;
                aes.GenerateIV();
                iv = aes.IV;
            }
            byte[] encData = EncryptData(key, iv, msgToEnc);
            Console.WriteLine("Original:{0}", msgToEnc);
            Console.WriteLine("Encrypted:{0}", BitConverter.ToString(encData));
            string decMsg = DecryptData(key, iv, encData);
            Console.WriteLine("Decrypted:{0}", decMsg);
        }
        //324 : AES (ECB:No iv)
        public byte[] GenerateKey()
        {
            byte[] theKey = null;
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                theKey = aes.Key;
            }
            return theKey;
        }
        public byte[] EncryptoText(byte[] key, string text)
        {
            byte[] resData = null;
            using (Aes aescrpt = Aes.Create())
            {
                aescrpt.Mode = CipherMode.ECB;
                using (MemoryStream mmStr = new MemoryStream())
                {
                    ICryptoTransform cf = aescrpt.CreateEncryptor(key, null);
                    using (CryptoStream cs = new CryptoStream(mmStr, cf, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            writer.Write(text);
                        }
                    }
                    resData = mmStr.ToArray();
                }
            }
            return resData;
        }
        public string DecryptoText(byte[] key, byte[] data)
        {
            string _text = null;
            using (Aes aescrypt = Aes.Create())
            {
                aescrypt.Mode = CipherMode.ECB;
                using (MemoryStream mmstream = new MemoryStream(data))
                {
                    ICryptoTransform cf = aescrypt.CreateDecryptor(key, null);
                    using (CryptoStream cs = new CryptoStream(mmstream, cf, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            _text = reader.ReadToEnd();
                        }
                    }
                }
            }
            return _text;
        }
        public void ShowHowToUseAESWithECBMode()
        {
            Console.WriteLine("Please type in your texts...");
            string input = Console.ReadLine();
            byte[] key = GenerateKey();
            byte[] encryptedText = EncryptoText(key, input);
            string result = DecryptoText(key, encryptedText);
            Console.WriteLine(result);
        }
        //325 : RSA
        public void ShowHowToUseRSA()
        {
            string sampleTest = "The dotnet core app";
            byte[] key = null;
            byte[] encryptData = null;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                key = rsa.ExportCspBlob(true);
                encryptData = rsa.Encrypt(Encoding.ASCII.GetBytes(sampleTest), RSAEncryptionPadding.Pkcs1);
            }

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportCspBlob(key);
                byte[] bf = rsa.Decrypt(encryptData, RSAEncryptionPadding.Pkcs1);
                string restoreStr = Encoding.ASCII.GetString(bf);
                Console.WriteLine("Decrypted:{0}", restoreStr);
            }
        }
    }
}
