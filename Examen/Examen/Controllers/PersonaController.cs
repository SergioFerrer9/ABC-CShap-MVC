using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace Examen.Controllers
{
    public class PersonaController : Controller
    {
        //
        // GET: /Persona/

        Conexion conexion = new Conexion();
        public ActionResult Index() ///Mostrar Listado...
        {
            List<Persona> listpersona = new List<Persona>();
            listpersona = conexion.Listado().ToList();
            return View(listpersona);
        }

        public ActionResult Agregar(Persona persona) {

         
            try
            {
                    SqlConnection con = new SqlConnection("Data Source=FISICA\\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=true;");
                    
                    con.Open();
                    SqlCommand query = new SqlCommand("INSERT INTO Datos(ID,Nombre,Apellido,DPI,Ciudad) VALUES (@p0, @p1, @p2, @p3, @p4);", con);
                    query.Parameters.AddWithValue("@p0", Convert.ToInt32(persona.ID));
                    query.Parameters.AddWithValue("@p1", persona.Nombre);
                    query.Parameters.AddWithValue("@p2", persona.Apellido);
                    query.Parameters.AddWithValue("@p3", Convert.ToInt32(persona.DPI));
                    query.Parameters.AddWithValue("@p4", persona.Ciudad);

                    query.ExecuteNonQuery();
                    con.Close();
              
                

            }
            catch(Exception ex) {
                
            
            }

            return View();

        }

        public ActionResult Eliminar(Persona persona) {

            try {

                SqlConnection con = new SqlConnection("Data Source=FISICA\\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=true;");
                con.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM Datos WHERE ID = @p0;", con);
                consulta.Parameters.AddWithValue("@p0",Convert.ToInt32(persona.ID));
                consulta.ExecuteNonQuery();
                con.Close();
            }catch(Exception ex){
            
            
            }

            return View();
        }


        public ActionResult Modificar(Persona persona) {
            try {
                SqlConnection con = new SqlConnection("Data Source=FISICA\\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=true;");
                con.Open();
                SqlCommand consulta = new SqlCommand("UPDATE Datos SET Apellido=@p0 WHERE Nombre=@p1;",con);
                consulta.Parameters.AddWithValue("@p0",persona.Apellido);
                consulta.Parameters.AddWithValue("@p1",persona.Nombre);
                consulta.ExecuteNonQuery();
                con.Close();

           
            }catch(Exception ex){
            
            }


            return View();        
        }

    }
}
