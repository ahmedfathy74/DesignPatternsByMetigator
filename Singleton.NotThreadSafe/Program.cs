using Singleton.NotThreadSafe;
using System;


class Program
{
    static MemoryLogger logger;

    static void Main(string[] args)
    {
        AssignVoucher("ahmedfathy@gmail.com", "ABC123");

        UseVoucher("ABC123");

        logger.ShowLog();

        Console.ReadKey();
    }

    static void UseVoucher(string voucher)
    {
        logger = MemoryLogger.GetLogger;

        // Logic here
        logger.LogWarning($"3 attempts made to validate the voucher");

        // Logic here
        logger.LogInfo($"'{voucher}' is used");
    }

    static void AssignVoucher(string email, string voucher)
    {
        logger = MemoryLogger.GetLogger;

        //logic here
        logger.LogInfo($"Voucher '{voucher}' assigned");

        // another logic
        logger.LogError($"unable to send email '{email}'");
    }
}