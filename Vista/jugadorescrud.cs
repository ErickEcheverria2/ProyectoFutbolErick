using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Administracion_Torneos.BD;
using Administracion_Torneos.Modelo;


namespace Administracion_Torneos.Vista
{
    public partial class jugadorescrud : Form
    {

        public jugadorBD jrcontext = new jugadorBD();
        public jugadorescrud()
        {
            InitializeComponent();
            Gettp();

            listjugadores.AllowUserToAddRows = false;
            listjugadores.AllowDrop = false;
            listjugadores.AllowUserToDeleteRows = false;
            listjugadores.MultiSelect = false;
            listjugadores.ReadOnly = true;
        }
        private long? GetId() //obtenemos el id de cada fila
        {
            try
            {
                return long.Parse(
                    listjugadores.Rows[listjugadores.CurrentRow.Index].Cells[0].Value.ToString()
                    );
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
            listjugadores.DataSource = jrcontext.Getjugadores(); //llenamos la lista con los elementos en la base
            int x = listjugadores.Rows.Count;// contamos lass lineas de datos 

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

        private void Guardar_Click(object sender, EventArgs e)
        {

            if (DateTime.Now.Date!= fecha_nac.Value.Date)
            {

                if (accion == 1)
                {
                    if (nacionalidad.SelectedIndex >= 0 && txtid.TextLength > 0) //verificamos que tenga seleccionado una nacionalidad  asi como que ingrese su identificador
                    {
                        DateTime dt = DateTime.Today; //obtenemos la fecha de hoy 
                        TimeSpan age = dt - fecha_nac.Value; // asi como la resta entre ambas fehcas , la seleccionada y la de hoy 

                        DateTime totalTime = new DateTime(age.Ticks);
                        int edad = Convert.ToInt32(totalTime.Year - 1); //restamos uno a l año 


                        jugador jr = new jugador(); //instanciamos el modeloado 

                        jr.Identificacion = Convert.ToInt64(txtid.Text);  //otorgamos los valores a el modelo 
                        jr.nombres = txtnombre.Text;
                        jr.apellidos = txtapellido.Text;
                        jr.fecha_naciemiento = fecha_nac.Value;
                        jr.direccion = txtdireccion.Text;

                        jr.Nacionalidad = nacionalidad.SelectedItem.ToString();
                        jr.correo = correo.Text;
                        jr.Telefono = tel.Text;
                        if (edad < 18) //validamos la edad para decidir si es menor a o mayor 
                        {
                            jr.Menor_de_edad = true;
                        }
                        else if (edad >= 18)
                        {
                            jr.Menor_de_edad = false;
                        }

                        jrcontext.addjugador(jr); // agregamos el modelo a base de datos 
                    }
                    else { MessageBox.Show("los campos identificacion y Nacionalidad son requeridos"); }
                }
                else if (accion == 0)
                {

                    if (nacionalidad.SelectedIndex >= 0 && txtid.TextLength > 0)
                    {
                        DateTime dt = DateTime.Today; //obtenemos la fecha de hoy 
                        TimeSpan age = dt - fecha_nac.Value; // asi como la resta entre ambas fehcas , la seleccionada y la de hoy 

                        DateTime totalTime = new DateTime(age.Ticks);
                        int edad = Convert.ToInt32(totalTime.Year - 1); //restamos uno a l año 


                        jugador jr = new jugador(); //instanciamos el modeloado 

                        jr.Identificacion = Convert.ToInt64(txtid.Text);  //otorgamos los valores a el modelo 
                        jr.nombres = txtnombre.Text;
                        jr.apellidos = txtapellido.Text;
                        jr.fecha_naciemiento = fecha_nac.Value;
                        jr.direccion = txtdireccion.Text;

                        jr.Nacionalidad = nacionalidad.SelectedItem.ToString();
                        jr.correo = correo.Text;
                        jr.Telefono = tel.Text;
                        if (edad < 18) //validamos la edad para decidir si es menor a o mayor 
                        {
                            jr.Menor_de_edad = true;
                        }
                        else if (edad >= 18)
                        {
                            jr.Menor_de_edad = false;
                        }

                        jrcontext.updtjugador(jr);
                        listjugadores.Enabled = true;
                    }
                    else { MessageBox.Show("los campos identificacion y Nacionalidad son requeridos"); }
                }
                this.Hide();
                jugadorescrud vista = new jugadorescrud();
                vista.Show();

            }
            else {
                MessageBox.Show("Seleccione una fecha por favor , esta no puede ser el dia de hoy");
            }
           
        }

        private void fecha_nac_ValueChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today; //validamos que no se pueda elegir una fecha mayor a ala del sistema 

            if (today < fecha_nac.Value)
            {
                MessageBox.Show("La Fecha de nacimeinto es invalida ");
                Guardar.Enabled = false;
            }
            else
            {
                Guardar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtid.ReadOnly = true; //evitamos que modifiquen un llave primaria 
            accion = 0;
            long? id = GetId(); // traemos el id seleccionado 
          jugador jr =   jrcontext.jugadorid(id); // cargamos los datos del modelo en el id deseado 
            txtid.Text = jr.Identificacion.ToString(); //cargamos todos los valores
            txtnombre.Text = jr.nombres;
            txtapellido.Text = jr.apellidos;
            txtdireccion.Text = jr.direccion;
            tel.Text = jr.Telefono;
            correo.Text = jr.correo;
            nacionalidad.SelectedItem = jr.Nacionalidad;
            fecha_nac.Value = jr.fecha_naciemiento;
            listjugadores.Enabled = false;

        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            long? id = GetId(); //obtenemos el id deseado del item seleccionado 
            jrcontext.deletejs(id); //enviamos el id a eleminar en base de datos el registro 
            this.Hide(); //recargamos el moduio 
            jugadorescrud vista = new jugadorescrud();
            vista.Show();
        }

        private void jugadorescrud_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
