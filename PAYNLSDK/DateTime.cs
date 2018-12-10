using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayNLSdk
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class LocalDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }

    public class UtcDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
