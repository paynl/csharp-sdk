using PAYNLSDK.API;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PayNLSdk.API.Statistics.GetManagement
{
    public class Request : RequestBase
    {
        public Request()
        {
            ExcludeSandbox = true;
            Filters = new List<FilterItem>();
            SortByFieldNames = new List<string>();
        }

        /// <inheritdocs />
        protected override int Version => 5;
        /// <inheritdocs />
        protected override string Controller => "Statistics";
        /// <inheritdocs />
        protected override string Method => "management";

        /// <summary>
        /// the first date to be included in the report
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// The last date to be included in the Report
        /// </summary>
        public DateTime EndDate { get; set; }

        public bool Staffels { get; set; }
        public int? CurrencyId { get; set; }

        /// <summary>
        /// This property can be used to filter events
        /// </summary>
        public List<FilterItem> Filters { get; set; }
        /// <summary>
        /// Use this field to sort the results
        /// </summary>
        public List<string> SortByFieldNames { get; set; }
        
        /// <summary>
        /// Exclude calls from the sandbox.  Default = true
        /// </summary>
        public bool ExcludeSandbox { get; set; }

        /// <inheritdocs />
        public override NameValueCollection GetParameters()
        {
            var retval = new NameValueCollection
            {
                { "startDate", StartDate.ToString("yyyy-MM-dd")},
                { "endDate", EndDate.ToString("yyyy-MM-dd")},
                { "staffels", Staffels.ToString()},
                { "CurrencyId", CurrencyId?.ToString()},
            };

            retval.Add(GenerateFiltersNameValueCollection());
            retval.Add(GenerateGroupByClause());
            return retval;
        }

        private NameValueCollection GenerateGroupByClause()
        {
            var groupByNvc = new NameValueCollection();

            var i = 0;
            foreach (var sortByFieldName in this.SortByFieldNames)
            {
                groupByNvc.Add($"groupBy[{i}]", sortByFieldName);
                i++;
            }

            return groupByNvc;
        }

        private NameValueCollection GenerateFiltersNameValueCollection()
        {
            var filterNvc = new NameValueCollection();

            var i = 0;

            if (ExcludeSandbox)
            {
                // from the PHP source
                // https://github.com/paynl/sdk-alliance/blob/master/src/Statistics.php#L36
                // $api->addFilter('payment_profile_id', 613, 'neq');

                filterNvc.Add($"filterType[{i}]", "payment_profile_id");
                filterNvc.Add($"filterOperator[{i}]", "neq");
                filterNvc.Add($"filterValue[{i}]", 613.ToString());                
                i++;
            }

            if (Filters == null)
            {
                return filterNvc;
            }

            foreach (var filterItem in Filters)
            {
                filterNvc.Add($"filterType[{i}]", filterItem.Key);
                filterNvc.Add($"filterOperator[{i}]", filterItem.Operator?.ToString() ?? ValidOperators.eq.ToString());
                filterNvc.Add($"filterValue[{i}]", filterItem.Value);
                i++;
            }

            return filterNvc;
        }


        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            if (ParameterValidator.IsEmpty(rawResponse))
            {
                throw new PayNlException("rawResponse is empty!");
            }
        }

        public struct FilterItem

        {
            public string Key { get; set; }
            public ValidOperators? Operator { get; set; }
            public string Value { get; set; }
        }

        public enum ValidOperators
        {
            eq,
            neq,
            gt,
            lt,
            like
        }
    }
}
