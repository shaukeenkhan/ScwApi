using System.Data;
using System.Data.SqlClient;
using SCW.common;

namespace SCW.uow
{
    public class UnitOfWork: IUnitOfWork
    {
        /* Declare Objects...*/
        /* Declare Objects...*/

        private readonly IConfiguration _configuration;
        //private readonly ApplicationDbContext _context;

        public UnitOfWork(IConfiguration configuration)
        {
            //_context = context;
            _configuration = configuration;
        }

        /* Implement Database Actions...*/
        //public int Complete()
        //{
        //    return _context.SaveChanges();
        //}
        /* Implement Dispose functions...*/
        public void Dispose()
        {
            //_context.Dispose();
        }


        /* Tradition ADO.Net Approch for connectivity*/
        public List<T> GetDataFromStoredProcedure<T>(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues)
        {
            List<T> _list = new List<T>();
            try
            {
                DataTable dtb = new DataTable();
                string connectionstring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

                using (SqlConnection sqlConn = new SqlConnection(connectionstring))
                {

                    SqlCommand cmdRecords = new SqlCommand(StoredProcedureName, sqlConn);
                    SqlDataAdapter daReport = new SqlDataAdapter(cmdRecords);
                    using (cmdRecords)
                    {
                        cmdRecords.CommandType = CommandType.StoredProcedure;
                        int i = 0;
                        foreach (string oName in ParametersName)
                        {
                            SqlParameter ForeignKeyTablePrm = new SqlParameter(oName, ParametersValues[i]);
                            cmdRecords.Parameters.Add(ForeignKeyTablePrm);
                            i++;
                        }
                        daReport.Fill(dtb);
                    }
                }
                _list = DataTableExtension.ToList<T>(dtb);
            }
            catch (Exception ex)
            { }
            return _list;
        }
        /**********************End Generic function Ado dot net********************************/


        /* Tradition ADO.Net Approch for connectivity*/
        public DataTable GetDataFromStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues)
        {
            DataTable dtb = new DataTable();
            string connectionstring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection sqlConn = new SqlConnection(connectionstring);
            SqlCommand cmdRecords = new SqlCommand(StoredProcedureName, sqlConn);
            SqlDataAdapter daReport = new SqlDataAdapter(cmdRecords);
            using (cmdRecords)
            {
                cmdRecords.CommandType = CommandType.StoredProcedure;
                int i = 0;
                foreach (string oName in ParametersName)
                {
                    SqlParameter ForeignKeyTablePrm = new SqlParameter(oName, ParametersValues[i]);
                    cmdRecords.Parameters.Add(ForeignKeyTablePrm);
                    i++;
                }
                daReport.Fill(dtb);
            }
            return dtb;
        }

        /* Tradition ADO.Net Approch for connectivity*/
        public List<T> GetDataFromDigitalStoredProcedure<T>(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues)
        {
            List<T> _list = new List<T>();
            try
            {
                DataTable dtb = new DataTable();
                string connectionstring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

                using (SqlConnection sqlConn = new SqlConnection(connectionstring))
                {

                    SqlCommand cmdRecords = new SqlCommand(StoredProcedureName, sqlConn);
                    SqlDataAdapter daReport = new SqlDataAdapter(cmdRecords);
                    using (cmdRecords)
                    {
                        cmdRecords.CommandType = CommandType.StoredProcedure;
                        int i = 0;
                        foreach (string oName in ParametersName)
                        {
                            SqlParameter ForeignKeyTablePrm = new SqlParameter(oName, ParametersValues[i]);
                            cmdRecords.Parameters.Add(ForeignKeyTablePrm);
                            i++;
                        }
                        daReport.Fill(dtb);
                    }
                }
                _list = DataTableExtension.ToList<T>(dtb);
            }
            catch (Exception ex)
            { }
            return _list;
        }
        /* Tradition ADO.Net Approch for DataSet connectivity*/
        public DataSet GetDatasetFromStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues)
        {
            DataSet dtb = new DataSet();
            string connectionstring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection sqlConn = new SqlConnection(connectionstring);
            SqlCommand cmdRecords = new SqlCommand(StoredProcedureName, sqlConn);
            SqlDataAdapter daReport = new SqlDataAdapter(cmdRecords);
            using (cmdRecords)
            {
                cmdRecords.CommandType = CommandType.StoredProcedure;
                int i = 0;
                foreach (string oName in ParametersName)
                {
                    SqlParameter ForeignKeyTablePrm = new SqlParameter(oName, ParametersValues[i]);
                    cmdRecords.Parameters.Add(ForeignKeyTablePrm);
                    i++;
                }
                daReport.Fill(dtb);
            }

            return dtb;

        }

        /* Tradition ADO.Net Approch for connectivity*/
        public int SaveDataStoredProcedure(string StoredProcedureName, string[] ParametersName, params object[] ParametersValues)
        {
            int result = 0;


            //Read the connection string from Web.Config file
            string connectionstring = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            SqlConnection sqlConn = new SqlConnection(connectionstring);
            SqlCommand cmdRecords = new SqlCommand(StoredProcedureName, sqlConn);
            SqlDataAdapter daReport = new SqlDataAdapter(cmdRecords);
            using (cmdRecords)
            {
                //Create the SqlCommand object
                //SqlCommand cmd = new SqlCommand(StoredProcedureName, con);

                //Specify that the SqlCommand is a stored procedure
                cmdRecords.CommandType = CommandType.StoredProcedure;
                //Add the output parameter to the command object 
                int i = 0;
                foreach (string oName in ParametersName)
                {
                    SqlParameter ForeignKeyTablePrm = new SqlParameter(oName, ParametersValues[i]);
                    cmdRecords.Parameters.Add(ForeignKeyTablePrm);
                    i++;
                }

                //Open the connection and execute the query
                sqlConn.Open();
                result = cmdRecords.ExecuteNonQuery();
                sqlConn.Close();
            }
            return result;
        }
    }
}
