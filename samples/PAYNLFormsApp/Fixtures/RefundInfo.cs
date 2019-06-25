﻿using System;
using Newtonsoft.Json;

namespace PAYNLFormsApp.Fixtures
{
    public class TransactionRefundInfo
    {
        static public PAYNLSDK.Objects.RefundInfo GetRefundInfoFixture()
        {
            var json = GetJsonFixture();
            var info = JsonConvert.DeserializeObject<PAYNLSDK.Objects.RefundInfo>(json);
            return info;
        }

        static public string GetJsonFixture()
        {
            var json = "{  \"request\": {\"result\": \"1\",\"errorId\": \"\",\"errorMessage\": \"\"},\"refund\": {\"paymentSessionId\": \"915930241\",\"amount\": \"2\",\"description\": \"EX-1234-4567-0000\",\"bankaccountHolder\": \"F. Lastname\",\"bankaccountNumber\": \"NL12RABO0123456789\",\"bankaccountBic\": \"RABONL2U\",\"statusCode\": \"316\",\"statusName\": \"Verwerkt\",\"processedDate\": \"2018-01-22\"},\"refundId\": \"RF-1234-4567-1234\"}";
            return json;
        }
    }
}
