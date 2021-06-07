using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.Modelo;
using Administracion_Torneos.BD;

namespace Administracion_Torneos.Vista
{
    public partial class Amonestacion : Form
    {
        TarjetaDB trcontext = new TarjetaDB();
        public Amonestacion()
        {
            InitializeComponent();
            Gettp();
            listaamonestaciones.AllowUserToAddRows = false;
            listaamonestaciones.AllowDrop = false;
            listaamonestaciones.AllowUserToDeleteRows = false;
            listaamonestaciones.MultiSelect = false;
            listaamonestaciones.ReadOnly = true;
        }

        private string GetId() //obtenemos el id de cada fila
        {
            try
            {
                return   listaamonestaciones.Rows[listaamonestaciones.CurrentRow.Index].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }
        }

        public enum acciones
        {
            editar = 0,
            guardar = 1
        }
        public int accion = 1;
        public void Gettp()
        {
            listaamonestaciones.DataSource = trcontext.ltr(); //llenamos la lista con los elementos en la base
            int x = listaamonestaciones.Rows.Count;// contamos lass lineas de datos 

            if (x == 0) //
            {
                MessageBox.Show("Conexion exitosa , pero la tabla buscada no tiene datos");
                editar.Enabled = false;
                eliminar.Enabled = false;
            }
            else
            {
                editar.Enabled = true;
                eliminar.Enabled = true;
            }
        }
        private void listaamonestaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
           if(multa.Value>0) // revisamoa que posea una multa 
            {
                if (accion == 1) //revisamos el tipo de accion ya sea guardar o modificar 
                {
                    Tarjeta tr = new Tarjeta();
                    tr.Color_Tarjeta = colortarjeta.Text;
                    tr.Multa = multa.Value.ToString();
                    tr.Comentario = come.Text;
                    trcontext.agregarTarjeta(tr);

                }
                else if (accion == 0)
                {
                    Tarjeta tr = new Tarjeta();
                    tr.Color_Tarjeta = colortarjeta.Text;
                    tr.Multa = multa.Value.ToString();
                    tr.Comentario = come.Text;
                    trcontext.updtTarjeta(tr);
                    listaamonestaciones.Enabled = true;

                }
            }else
            {
                MessageBox.Show("Ingrese un valor mayor a cero para continuar");
            }
            this.Hide();
            Amonestacion am = new Amonestacion();
            am.Show();
        }

        private void editar_Click(object sender, EventArgs e)
        {
            string id = GetId(); // llamamos el id del item seleccionado 
            Tarjeta tr =  trcontext.tarjeta(id); //cargamos los datos 
            colortarjeta.Text = tr.Color_Tarjeta;
            multa.Value = Convert.ToDecimal(tr.Multa);
            come.Text = tr.Comentario;
            accion = 0;
            listaamonestaciones.Enabled = false;
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            string id = GetId(); //eliminamos el item seleccionado 
            trcontext.Delete(id);
            this.Hide();
            Amonestacion am = new Amonestacion();
            am.Show();
        }

        private void Amonestacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
