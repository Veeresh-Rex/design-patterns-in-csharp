using System;

namespace Csharp_design_patterns_lab.Structural.Adapter;

public interface ITargetBillingProcessor
{
    void ProcessPayment(string clientJsonData);
}

public class LegacyBillingSystem
{
    public void ProcessLegacyPayment(string clientXmlData)
    {
        Console.WriteLine("Processing payment using XML data:");
        Console.WriteLine($"    Data: {clientXmlData}");
    }
}

public class BillingAdapter : ITargetBillingProcessor
{
    private readonly LegacyBillingSystem _legacyBillingSystem;

    public BillingAdapter(LegacyBillingSystem legacyBillingSystem)
    {
        _legacyBillingSystem = legacyBillingSystem ?? throw new ArgumentNullException(nameof(legacyBillingSystem));
    }

    public void ProcessPayment(string clientJsonData)
    {
        Console.WriteLine("Translating JSON to XML...");
        string clientXmlData = ConvertJsonToXml(clientJsonData);
        _legacyBillingSystem.ProcessLegacyPayment(clientXmlData);
    }

    private string ConvertJsonToXml(string json)
    {
        string amount = "0";
        string currency = "USD";

        if (json.Contains("\"amount\":"))
        {
            int amountIdx = json.IndexOf("\"amount\":") + 9;
            int commaIdx = json.IndexOf(",", amountIdx);
            if (commaIdx == -1) commaIdx = json.IndexOf("}", amountIdx);
            amount = json.Substring(amountIdx, commaIdx - amountIdx).Trim(' ', '"');
        }

        if (json.Contains("\"currency\":"))
        {
            int currencyIdx = json.IndexOf("\"currency\":") + 11;
            int commaIdx = json.IndexOf(",", currencyIdx);
            if (commaIdx == -1) commaIdx = json.IndexOf("}", currencyIdx);
            currency = json.Substring(currencyIdx, commaIdx - currencyIdx).Trim(' ', '"');
        }

        return $"<payment><amount>{amount}</amount><currency>{currency}</currency></payment>";
    }
}

public static class AdapterDemo
{
    public static void Invoke()
    {
        Console.WriteLine("Adapter Pattern:");

        LegacyBillingSystem legacySystem = new LegacyBillingSystem();
        ITargetBillingProcessor billingProcessor = new BillingAdapter(legacySystem);
        string clientJsonData = "{ \"amount\": 250.00, \"currency\": \"USD\" }";
        
        Console.WriteLine("Sending payment request in JSON format...");
        billingProcessor.ProcessPayment(clientJsonData);

        Console.WriteLine();
    }
}
