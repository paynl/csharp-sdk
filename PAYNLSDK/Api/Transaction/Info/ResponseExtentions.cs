using PAYNLSDK.Enums;

namespace PAYNLSDK.API.Transaction.Info
{
    /// <summary>
    /// Extentions methods
    /// </summary>
    public static class ResponseExtentions
    {
        /// <summary>
        ///     Checks whether a status is a PAID status
        /// </summary>
        /// <returns>True if PAID, false otherwise</returns>
        public static bool IsPaid(this Response response)
        {
            return response?.PaymentDetails?.State == PaymentStatus.PAID;
        }

        /// <summary>
        ///     Checks whether a status is a CANCELLED status
        /// </summary>
        /// <returns>True if CANCELLED, false otherwise</returns>
        public static bool IsCancelled(this Response response)
        {
            return response?.PaymentDetails?.State == PaymentStatus.CANCEL;
        }

        /// <summary>
        ///     Checks whether a status is a PENDING status
        /// </summary>
        /// <returns>True if PENDING, false otherwise</returns>
        public static bool IsPending(this Response response)
        {
            var status = response?.PaymentDetails?.State;
            return status == PaymentStatus.PENDING_1 ||
                   status == PaymentStatus.PENDING_2 ||
                   status == PaymentStatus.PENDING_3 ||
                   status == PaymentStatus.VERIFY;
        }

        /// <summary>
        ///     Checks whether a status is a VERIFY status
        /// </summary>
        /// <param name="response"></param>
        /// <returns>True if VERIFY, false otherwise</returns>
        public static bool IsVerify(this Response response)
        {
            return response?.PaymentDetails?.State == PaymentStatus.VERIFY;
        }
    }
}