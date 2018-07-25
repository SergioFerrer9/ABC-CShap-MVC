using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Examen.Models
{
    public class Conexion
    {

        String conexion = "Data Source=FISICA\\SQLEXPRESS; Initial Catalog=Base1; Integrated Security=true;";

        public List<Persona> Listado() {

            List<Persona> Lista = new List<Persona>();

            using(SqlConnection con = new SqlConnection(conexion)){

                var select = new SqlCommand("SELECT * FROM Datos",con);
                con.Open();

                using(var ls = select.ExecuteReader()){
                    
                    while(ls.Read()){

                        Persona persona = new Persona();
                        persona.ID = Convert.ToInt32(ls["ID"]);
                        persona.Nombre = Convert.ToString(ls["Nombre"]);
                        persona.Apellido = Convert.ToString(ls["Apellido"]);
                        persona.DPI = Convert.ToInt32(ls["DPI"]);
                        persona.Ciudad = Convert.ToString(ls["Ciudad"]);

                        Lista.Add(persona);
                    }
                }
            }

            return Lista;
        }

    }
}