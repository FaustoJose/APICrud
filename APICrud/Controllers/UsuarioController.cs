using Microsoft.AspNetCore.Mvc;
using System.Data;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-MMLJCRA; database=Usuario; Integrated Security=true");
       
        // GET: api/<UsuarioController>
        [HttpGet]
        public string Get()
        {
            //return context.Usuario.ToList();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Usuario",con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else 
            {
                return "No Hay Datos";
            }
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public void Post([FromBody] string Nombre,string Apellido,string Correo)
        {
            
            string query= "insert into Usuario(Nombre, Apellido, Correo) VALUES(@nombre, @apellido, @correo )";
            SqlCommand cmd = new SqlCommand(query,con);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@apellido", Apellido);
            cmd.Parameters.AddWithValue("@correo", Correo);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string Nombre, string Apellido, string Correo)
        {
            string query = "update Usuario set Nombre=@nombre, Apellido=@apellido, Correo=@correo where ID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", Nombre);
            cmd.Parameters.AddWithValue("@apellido", Apellido);
            cmd.Parameters.AddWithValue("@correo", Correo);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            string query = "delete from Usuario where ID=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
