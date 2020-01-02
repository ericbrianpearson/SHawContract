using Newtonsoft.Json;

namespace ShawContract.Application.Models
{
    public class BaseModel
    {
        public override string ToString()
        {
            // When logging a dto object, we can simply do something like log.Write(dtoObj) and this function will show all properties of the object. Might be helpful in log files to debug issues.
            return JsonConvert.SerializeObject(this);
        }
    }
}