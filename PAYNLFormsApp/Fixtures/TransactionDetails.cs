using System;
using PAYNLSDK.Objects;
using PAYNLSDK;
using PAYNLSDK.Enums;
using Newtonsoft.Json;

namespace PAYNLFormsApp.Fixtures
{
    public class TransactionDetails
    {
        static public PAYNLSDK.Objects.TransactionDetailsPaymentDetails GetFixture()
        {
            String json = GetJsonFixture();
            PAYNLSDK.Objects.TransactionDetailsPaymentDetails info = JsonConvert.DeserializeObject<PAYNLSDK.Objects.TransactionDetailsPaymentDetails>(json);
            return info;
        }

        static public String GetJsonFixture()
        {
            String json = "{\"transactionId\":\"AB-1234-5678-9000\",\"orderId\":\"1122334455Xa1bc2\",\"orderNumber\":\"12345\",\"paymentProfileId\":\"10\",\"paymentProfileName\":\"iDEAL\",\"state\":\"-80\",\"stateName\":\"VERLOPEN\",\"language\":\"NL\",\"startDate\":\"1567076662\",\"completeDate\":\"\",\"startIpAddress\":\"\",\"completedIpAddress\":\"192.168.0.1\",\"amount\":{\"value\":\"5\",\"currency\":\"EUR\"},\"amountOriginal\":{\"value\":\"5\",\"currency\":\"EUR\"},\"amountPaidOriginal\":{\"value\":\"0\",\"currency\":\"EUR\"},\"amountPaid\":{\"value\":\"0\",\"currency\":\"EUR\"},\"amountRefundOriginal\":{\"value\":\"0\",\"currency\":\"EUR\"},\"amountRefund\":{\"value\":\"0\",\"currency\":\"EUR\"},\"transactionDetails\":[{\"transactionId\":\"EX-8966-3340-7200\",\"orderId\":\"1122334455Xa1bc2\",\"reportingId\":\"\",\"state\":\"-80\",\"stateName\":\"VERLOPEN\",\"startDate\":\"2019-08-29 13:04:22\",\"completeDate\":\"\",\"paymentProfileId\":\"10\",\"paymentProfileName\":\"iDEAL\",\"identifierName\":\"Mr Pay.nl\",\"identifierType\":\"IBAN\",\"identifierPublic\":\"***\",\"identifierHash\":\"\",\"amount\":{\"value\":\"5\",\"currency\":\"EUR\"}}]}";
            return json;
        }

    }
}
