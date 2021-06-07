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
    public partial class UsuarioSistema : Form
    {
        public UsuarioSistemaDB usuarioDB = new UsuarioSistemaDB();

        public UsuarioSistema()
        {
            InitializeComponent();
            listAlquileres.DataSource = usuarioDB.GetUsuarios();
        }

        private void UsuarioSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show($"Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int cantidadUsuariosMismoCorreo = usuarioDB.p_BuscarUsuariosMismoCorreo(textBox6.Text);
                int cantidadUsuariosMismoDPI = usuarioDB.p_BuscarUsuariosMismoDPI(Convert.ToInt64(textBox1.Text));
                int cantidadUsuariosMismoNombreUsuario = usuarioDB.p_BuscarUsuariosMismoNombreUsuario(textBox8.Text);

                if(cantidadUsuariosMismoCorreo > 0)
                {
                    MessageBox.Show($"Actualmente ya existe un Usuario con el mismo Correo\n" +
                        $"Porfavor, intentelo nuevamente ingresando un distinto Correo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(cantidadUsuariosMismoDPI > 0)
                {
                    MessageBox.Show($"Actualmente ya existe un Usuario con el mismo DPI\n" +
                        $"Porfavor, intentelo nuevamente ingresando un distinto DPI", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if(cantidadUsuariosMismoNombreUsuario > 0)
                {
                    MessageBox.Show($"Actualmente ya existe un Usuario con el mismo Nombre de Usuario\n" +
                        $"Porfavor, intentelo nuevamente ingresando un distinto Nombre de Usuario", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Modelo.UsuarioSistema usuario = new Modelo.UsuarioSistema();
                    usuario.DPI_Usuario = Convert.ToInt64(textBox1.Text);
                    usuario.Nombre_Usuario = textBox8.Text;
                    usuario.Nombres = textBox2.Text;
                    usuario.Apellidos = textBox3.Text;
                    usuario.Telefono = textBox4.Text;
                    usuario.Direccion = textBox5.Text;
                    usuario.Correo = textBox6.Text;
                    usuario.Puesto = textBox7.Text;
                    usuario.Estado = comboBox1.Text;
                    usuario.Tipo = comboBox2.Text;
                    usuario.Contraseña = textBox9.Text;

                    usuarioDB.AgregarUsuario(usuario);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";

                    listAlquileres.DataSource = usuarioDB.GetUsuarios();
                }
            }
        }

        private int buscar_id()
        {
            try
            {
                return int.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[0].Value.ToString());
            }

            catch
            {
                return 0;
            }

        }

        int opcion = 0;

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (opcion == 0)
            {
                int Id_Usuario = buscar_id();
                Modelo.UsuarioSistema usuario = usuarioDB.buscarUsuario(Id_Usuario);

                textBox1.Text = Convert.ToString(usuario.DPI_Usuario);
                textBox2.Text = usuario.Nombres;
                textBox3.Text = usuario.Apellidos;
                textBox4.Text = usuario.Telefono;
                textBox5.Text = usuario.Direccion;
                textBox6.Text = usuario.Correo;
                textBox7.Text = usuario.Puesto;
                textBox8.Text = usuario.Nombre_Usuario;
                textBox9.Text = usuario.Contraseña;
                comboBox1.Text = usuario.Estado;
                comboBox2.Text = usuario.Tipo;

                btnAgregar.Enabled = false;
                btnModificar.Text = "Confirmar Cambios";
                listAlquileres.Enabled = false;

                opcion = 1;
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox9.Text == "")
                {
                    MessageBox.Show($"Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int p_BuscarUsuariosMismoCorreoExceptoElMismo = usuarioDB.p_BuscarUsuariosMismoCorreoExceptoElMismo(textBox6.Text, buscar_id());
                    int p_BuscarUsuariosMismoDPIExceptoElMismo = usuarioDB.p_BuscarUsuariosMismoDPIExceptoElMismo(Convert.ToInt64(textBox1.Text), buscar_id());
                    int p_BuscarUsuariosMismoNombreUsuarioExceptoElMismo = usuarioDB.p_BuscarUsuariosMismoNombreUsuarioExceptoElMismo(textBox8.Text, buscar_id());

                    if (p_BuscarUsuariosMismoCorreoExceptoElMismo > 0)
                    {
                        MessageBox.Show($"Actualmente ya existe un Usuario con el mismo Correo\n" +
                            $"Porfavor, intentelo nuevamente ingresando un distinto Correo", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (p_BuscarUsuariosMismoDPIExceptoElMismo > 0)
                    {
                        MessageBox.Show($"Actualmente ya existe un Usuario con el mismo DPI\n" +
                            $"Porfavor, intentelo nuevamente ingresando un distinto DPI", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (p_BuscarUsuariosMismoNombreUsuarioExceptoElMismo > 0)
                    {
                        MessageBox.Show($"Actualmente ya existe un Usuario con el mismo Nombre de Usuario\n" +
                            $"Porfavor, intentelo nuevamente ingresando un distinto Nombre de Usuario", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Modelo.UsuarioSistema usuario = new Modelo.UsuarioSistema();
                        usuario.Id_Usuario = buscar_id();
                        usuario.DPI_Usuario = Convert.ToInt64(textBox1.Text);
                        usuario.Nombre_Usuario = textBox8.Text;
                        usuario.Nombres = textBox2.Text;
                        usuario.Apellidos = textBox3.Text;
                        usuario.Telefono = textBox4.Text;
                        usuario.Direccion = textBox5.Text;
                        usuario.Correo = textBox6.Text;
                        usuario.Puesto = textBox7.Text;
                        usuario.Estado = comboBox1.Text;
                        usuario.Tipo = comboBox2.Text;
                        usuario.Contraseña = textBox9.Text;

                        usuarioDB.actualizarUsuario(usuario);

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";

                        listAlquileres.DataSource = usuarioDB.GetUsuarios();

                        btnAgregar.Enabled = true;
                        btnModificar.Text = "Modificar";
                        listAlquileres.Enabled = true;

                        opcion = 0;
                    }
                }
            }
        }
    }
}
