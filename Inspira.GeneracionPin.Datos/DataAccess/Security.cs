using System;
using System.IO;
using System.Security.Cryptography;

namespace Inspira.GeneracionPin.Datos.DataAccess
{
    /// <summary>
    /// Security: manejo de seguridad en manejo de cadenas
    /// </summary>
    /// <remarks>Permite la encripción y desencripción de cadenas</remarks>
    public static class Security
    {
        /// Encripta una cadena
        public static string EncryptionString(string strToEncrypt)
        {
            byte[] bytArrayKey = { 107, 64, 54, 90, 91, 99, 99, 196, 113, 253, 169, 113, 3, 30, 114, 68, 28, 16, 227, 20, 99, 8, 111, 170 };
            byte[] bytArrayVI = { 63, 71, 172, 226, 2, 170, 111, 114 };

            string strEncrypString = "";
            MemoryStream mstMemoryStream = new MemoryStream();
            TripleDESCryptoServiceProvider objTripleDes = new TripleDESCryptoServiceProvider();

            objTripleDes.Key = bytArrayKey;
            objTripleDes.IV = bytArrayVI;
            byte[] bytTextBytes = System.Text.Encoding.Unicode.GetBytes(strToEncrypt);

            CryptoStream cstStream = new CryptoStream(mstMemoryStream, objTripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cstStream.Write(bytTextBytes, 0, bytTextBytes.Length);
            cstStream.FlushFinalBlock();
            strEncrypString = Convert.ToBase64String(mstMemoryStream.ToArray());
            return strEncrypString;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string UnencryptionString(string strToDecrypt)
        {
            byte[] bytArrayKey = { 107, 64, 54, 90, 91, 99, 99, 196, 113, 253, 169, 113, 3, 30, 114, 68, 28, 16, 227, 20, 99, 8, 111, 170 };
            byte[] bytArrayVI = { 63, 71, 172, 226, 2, 170, 111, 114 };

            string strUnEncrypString = "";
            MemoryStream mstMemoryStream = new System.IO.MemoryStream();
            TripleDESCryptoServiceProvider objTripleDes = new TripleDESCryptoServiceProvider();

            objTripleDes.Key = bytArrayKey;
            objTripleDes.IV = bytArrayVI;
            byte[] bytTextBytes = Convert.FromBase64String(strToDecrypt);

            CryptoStream cstStream = new CryptoStream(mstMemoryStream, objTripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            cstStream.Write(bytTextBytes, 0, bytTextBytes.Length);
            cstStream.FlushFinalBlock();
            strUnEncrypString = System.Text.Encoding.Unicode.GetString(mstMemoryStream.ToArray());

            return strUnEncrypString;
        }
    }
}
