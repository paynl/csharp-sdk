using System;
using PAYNLSDK.Objects;
using PAYNLSDK;
using PAYNLSDK.Enums;
using Newtonsoft.Json;

namespace PAYNLFormsApp.Fixtures
{
    public class ChangeStatusList
    {
        static public PAYNLSDK.API.Transaction.ChangeStatusList.Response GetFixture()
        {
            String json = GetJsonFixture();
            PAYNLSDK.API.Transaction.ChangeStatusList.Response info = JsonConvert.DeserializeObject<PAYNLSDK.API.Transaction.ChangeStatusList.Response>(json);
            return info;
        }

        static public String GetJsonFixture()
        {
            String json = "{\"request\":{\"result\":\"1\",\"errorId\":\"0\",\"errorMessage\":\"\"},\"moreData\":\"false\",\"firstChangeStamp\":\"1565686208\",\"lastChangeStamp\":\"1567055168\",\"numberOfTransactions\":\"1\",\"transactions\":[{\"transactionId\":\"EX-1234-5678-9000\",\"orderId\":\"11223344X1a2b3\",\"orderNumber\":\"\",\"paymentProfileId\":\"10\",\"paymentProfileName\":\"iDEAL\",\"state\":\"100\",\"stateName\":\"Paid\",\"created\":\"1565686180\",\"modified\":\"1565686208\",\"amountOriginal\":{\"value\":\"2000000\",\"currency\":\"EUR\"},\"amount\":{\"value\":\"2000000\",\"currency\":\"EUR\"},\"amountPaidOriginal\":{\"value\":\"2000000\",\"currency\":\"EUR\"},\"amountPaid\":{\"value\":\"2000000\",\"currency\":\"EUR\"},\"amountRefundOriginal\":{\"value\":\"0\",\"currency\":\"EUR\"}}]}";
            return json;
        }


    }
}
