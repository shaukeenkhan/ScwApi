using System.Data;

namespace SCW.uow
{
    public interface IUnitOfWork: IDisposable
    {
        //int Complete();
        /* Tradition ADO.Net Approch for connectivity*/
        List<T> GetDataFromStoredProcedure<T>(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues);
        /* Tradition ADO.Net Approch for connectivity*/
        DataTable GetDataFromStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues);
        /* Tradition ADO.Net Approch for DataSet connectivity*/
        List<T> GetDataFromDigitalStoredProcedure<T>(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues);
        DataSet GetDatasetFromStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues);
        /* Tradition ADO.Net Approch for connectivity*/
        int SaveDataStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues);

    }
}
