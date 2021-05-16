using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea10.Clases.Archivos;
using Tarea10.Clases.Base_de_datos;

namespace Tarea10
{
    public partial class frminicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void cargarArchivoExterno()
        {
            string fuente = @"C:\Users\Wicho\Desktop\Tercer semestre\Progra\csv\1_4949951634001101227.csv";
            Clsarchivo ar = new Clsarchivo();
            Clsconexion cn = new Clsconexion();

            //obtener tood el archivo de un arreglo
            string[] ArregloNotas = ar.LeerArchivo(fuente);
            string sentencial_sql = "";
            int NumeroLinea = 0;

            //interamos sobre el arreglo, line por linea para luego convertirlo en dadots
            foreach (string linea in ArregloNotas)
            {
                string[] datos = linea.Split(';');
                if (NumeroLinea > 0)
                {
                    sentencial_sql += $"insert into progra1.tb_alumno values({datos[0]},'{datos[1]}',{datos[2]},{datos[3]},{datos[4]},{datos[5]},'{datos[6]}');\n";
                }// end foreach

                NumeroLinea++;

            }
            NumeroLinea = 0;
            cn.EjecutaSQLDirecto(sentencial_sql);
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text.Trim();
            string condicion = $"correlativo = {id}";
            DataTable dt = CargarDatosDB(condicion);
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<string>("nombre");
                TextBox2.Text = nombre;
            }
            else
            {
                TextBox2.Text = "No hay informacion en la numeracion";
            }
        }


    protected void Button1_Click(object sender, EventArgs e)
        {
            cargarArchivoExterno();
        }

        public DataTable CargarDatosDB(string condicion = "1=1")
        {
            Clsconexion cn = new Clsconexion();
            DataTable dt = new DataTable();
            string sentencia = $"select * from progra1.tb_alumno where {condicion} ";
            dt = cn.consultaTablaDirecta(sentencia);
            return dt;


        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string nombre = TextBox2.Text.Trim();
            string condicion = $"('%{nombre}%')";
            DataTable dt = CargarDatosDB(condicion);

            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<Int32>("correlativo");
                TextBox1.Text = id + "";
            }
            else
            {
                TextBox1.Text = "No hay resultados";
            }
        }
    }
}




