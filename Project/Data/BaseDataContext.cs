using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BaseDataContext: System.Data.Linq.DataContext
    {
        private static System.Data.Linq.Mapping.MappingSource mapping = new System.Data.Linq.Mapping.AttributeMappingSource();
        private DataLoader _Loader;

        private static int SqlCommandTimeout()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeout"] == null)
                return 600;
            try
            {
                return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SqlCommandTimeout"]);
            }
            catch (Exception e)
            {
                throw new Exception("SqlCommandTimeout", e);
            }
        }
        public class DataLoader
        {
            readonly BaseDataContext context;
            public DataLoader(BaseDataContext context)
            {
                this.context = context;
            }
            DataLoadOptions option = new DataLoadOptions();
            public DataLoader LoadWith<T>(System.Linq.Expressions.Expression<Func<T, object>> func)
            {
                option.LoadWith(func);
                return this;
            }
            public void Set()
            {
                context.LoadOptions = option;
            }
        }
        public static String ConnectionString(String Name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }
        public static String DefaultConnectionString()
        {
            return ConnectionString("ConnStr");
        }
        public static SqlConnection GetConnection()
        {
            SqlConnection lConn = new SqlConnection(DefaultConnectionString());
            if (lConn.State == ConnectionState.Closed)
                lConn.Open();
            return lConn;
        }

        public static SqlConnection GetConnection(String Name)
        {
            SqlConnection lConn = new SqlConnection(ConnectionString(Name));
            lConn.Open();
            return lConn;
        }
        public BaseDataContext()
            : this(DefaultConnectionString())
        {

        }
        public BaseDataContext(string ConnectionStrings)
            : base(ConnectionStrings, mapping)
        {
            this.CommandTimeout = SqlCommandTimeout();
            _Loader = new DataLoader(this);
        }

        public DataSet ExecuteDataset(MethodInfo methed, params object[] parameterValues)
        {
            SqlConnection lConn = GetConnection();
            SqlCommand cmd = null;
            try
            {
                var Function = methed.GetCustomAttributes(typeof(FunctionAttribute));
                if (Function != null && Function.Count() > 0)
                {
                    var func = (FunctionAttribute)Function.FirstOrDefault();
                    cmd = lConn.CreateCommand();
                    cmd.CommandTimeout = SqlCommandTimeout();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = func.Name;
                    var Parameters = methed.GetParameters();
                    if (Parameters != null && Parameters.Count() != 0)
                    {
                        foreach (var item in Parameters)
                        {
                            var param = item.GetCustomAttribute<ParameterAttribute>();
                            if (param != null)
                            {
                                var p = cmd.CreateParameter();
                                p.ParameterName = param.Name;
                                p.Value = parameterValues[item.Position];
                                cmd.Parameters.Add(p);
                            }
                            else
                            {
                                var p = cmd.CreateParameter();
                                p.ParameterName = item.Name;
                                p.Value = parameterValues[item.Position];
                                cmd.Parameters.Add(p);
                            }
                        }
                    }
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.FillLoadOption = LoadOption.Upsert;
                    da.Fill(ds);
                    cmd.Dispose();
                    lConn.Close();
                    lConn.Dispose();
                    return ds;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                try
                {
                    lConn.Close();
                    lConn.Dispose();
                    lConn = null;
                }
                catch (Exception)
                {

                }
            }

        }
        public DataTable ExecuteDatatable(MethodInfo methed, params object[] parameterValues)
        {
            SqlConnection lConn = GetConnection();
            SqlCommand cmd = null;
            try
            {
                var Function = methed.GetCustomAttributes(typeof(FunctionAttribute));
                if (Function != null && Function.Count() > 0)
                {
                    var func = (FunctionAttribute)Function.FirstOrDefault();
                    cmd = lConn.CreateCommand();
                    cmd.CommandTimeout = SqlCommandTimeout();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = func.Name;
                    var Parameters = methed.GetParameters();
                    if (Parameters != null && Parameters.Count() != 0)
                    {
                        foreach (var item in Parameters)
                        {
                            var param = item.GetCustomAttribute<ParameterAttribute>();
                            if (param != null)
                            {
                                var p = cmd.CreateParameter();
                                p.ParameterName = param.Name;
                                p.Value = parameterValues[item.Position];
                                cmd.Parameters.Add(p);
                            }
                            else
                            {
                                var p = cmd.CreateParameter();
                                p.ParameterName = item.Name;
                                p.Value = parameterValues[item.Position];
                                cmd.Parameters.Add(p);
                            }
                        }
                    }
                    DataTable ds = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.AcceptChangesDuringFill = false;
                    da.FillLoadOption = LoadOption.Upsert;
                    da.Fill(ds);
                    cmd.Dispose();
                    lConn.Close();
                    lConn.Dispose();
                    return ds;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
                try
                {
                    lConn.Close();
                    lConn.Dispose();
                    lConn = null;
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
