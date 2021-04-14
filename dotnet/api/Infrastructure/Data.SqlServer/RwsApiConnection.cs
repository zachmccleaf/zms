using AndcultureCode.CSharp.Core.Models;

namespace Rws.Api.Infrastructure.Data.SqlServer
{
    public class RwsApiConnection : Connection
    {
        #region Overrides of Connection

        public override string ToString(string delimiter = ";")
        {
            return $"Data Source={Datasource}; Database={Database}; User Id={UserId}; Password={Password}; {AdditionalParameters}";
        }

        #endregion
    }
}