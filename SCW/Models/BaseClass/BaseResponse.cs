using System.ComponentModel;
using System.Runtime.Serialization;

namespace SCW.Models.BaseClass
{
    public class BaseResponse<T> : IDisposable where T : new()
    {
        public BaseResponse()
        {
            rc = new List<T>();
            res = new T();

        }

        [DataMember(Order = 1)]
        [Description("ResponseStatus")]
        public int rs { get; set; }

        [DataMember(Order = 2)]
        [Description("ResponseMessage")]
        public string rm { get; set; }

        [DataMember(Order = 2)]
        [Description("ResponseObject")]
        public T res { get; set; }

        [DataMember(Order = 3)]
        [Description("ResponseCollection")]
        public virtual List<T> rc { get; set; }
        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
