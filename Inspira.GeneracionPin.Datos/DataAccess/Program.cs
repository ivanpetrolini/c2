using System;

namespace Inspira.GeneracionPin.Datos.DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string originalString = "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=bogexaprvm1-ao73q-scan.bogexaprpri1.icesprodvcn1.oraclevcn.com)(PORT=1525))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SRV_DBINSPIRADIGITAL.bogexaprpri1.icesprodvcn1.oraclevcn.com)(FAILOVER_MODE=
          (TYPE=select)
          (METHOD=basic)));uid=GENERACIONPIN;pwd=@n3T1m3P4ssw0rd$;"; // A string que você deseja encriptar

            Console.WriteLine("Texto Original: " + originalString);

            // Encriptar a string
            string encryptedString = Security.EncryptionString(originalString);

            Console.WriteLine("Texto Encriptado: " + encryptedString);

            // Desencriptar a string
            string decryptedString = Security.UnencryptionString(encryptedString);

            Console.WriteLine("Texto Desencriptado: " + decryptedString);

            Console.ReadKey();
        }
    }
}