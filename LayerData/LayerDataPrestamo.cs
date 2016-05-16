using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace LayerData
{
    public class LayerDataPrestamo
    {
        public string strconn = @"Data Source=ACER\SENA2016;Initial Catalog=Siss;Integrated Security=True";
        public LayerDataPrestamo() { }

        public int Prestamo(Int64 Id, string Apellidos, string Nombres, string Elementos, string Insumos, string Concepto, string Comentarios, double CantidadElem, double CantidadInsu, DateTime FechaEntrega)
        {

            using (SqlConnection cnx = new SqlConnection(strconn))
            {


                cnx.Open();
                SqlCommand OrderSql = new SqlCommand("SpMostrarPrestamo", cnx);
                OrderSql.CommandType = CommandType.StoredProcedure;
                try
                {
                    OrderSql.Parameters.AddWithValue("@Id", Id);
                    OrderSql.Parameters.AddWithValue("@Apellidos", Apellidos);
                    OrderSql.Parameters.AddWithValue("@Nombres", Nombres);
                    OrderSql.Parameters.AddWithValue("@Elementos", Elementos);
                    OrderSql.Parameters.AddWithValue("@Insumos", Insumos);
                    OrderSql.Parameters.AddWithValue("@Concepto", Concepto);
                    OrderSql.Parameters.AddWithValue("@Comentarios", Comentarios);
                    OrderSql.Parameters.AddWithValue("@CantidadElem", CantidadElem);
                    OrderSql.Parameters.AddWithValue("@CantidadInsu", CantidadInsu);
                    OrderSql.Parameters.AddWithValue("@FechaEntrega", FechaEntrega);
                    return OrderSql.ExecuteNonQuery();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                    OrderSql.Dispose();


                }




            }

        }


        public DataTable MostrarPrestamo()
        {
            using (SqlConnection cnx = new SqlConnection(strconn))
            {
                cnx.Open();
                SqlDataAdapter dAd = new SqlDataAdapter("SpMostrarPrestamo", cnx);
                dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();

                try
                {
                    dAd.Fill(ds, "Table");
                    return ds.Tables["Table"];
                }

                catch (Exception)
                {
                    throw;

                }
                finally
                {
                    cnx.Close();
                    cnx.Dispose();
                    dAd.Dispose();
                    ds.Dispose();
                }





            }
        }

    }
}

