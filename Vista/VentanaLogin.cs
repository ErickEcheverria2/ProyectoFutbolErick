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
    public partial class VentanaLogin : Form
    {
        public VentanaLoginDB loginDB = new VentanaLoginDB();

        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show($"Ingrese todos los datos solicitados\n" +
                    $"Nombre | Contraseña", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                int verificarUsuarioExistente = loginDB.verificarUsuarioExistente(textBox1.Text);

                if(verificarUsuarioExistente == 1)
                {
                    string contraseñaValidar = loginDB.obtenerContrasenaDeUsuario(textBox1.Text);

                    if(contraseñaValidar == textBox2.Text)
                    {
                        string estadoUsuario = loginDB.obtenerEstadoDeUsuario(textBox1.Text);

                        if(estadoUsuario == "Activo")
                        {
                            string tipoUsuario = loginDB.obtenerTipoDeUsuario(textBox1.Text);

                            int Id_Usuario = loginDB.obtenerIDDeUsuario(textBox1.Text);

                            loginDB.RegistrarEntrada(Id_Usuario,"Menu Principal");

                            this.Hide();
                            Menucontrol menucontrol = new Menucontrol(tipoUsuario,Id_Usuario);
                            menucontrol.Show();
                        }
                        else
                        {
                            MessageBox.Show($"El Usuario ingresado se encuentra Inactivo por el momento\n" +
                            $"Para más información consulte con el Administrador", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        } 
                    }
                    else
                    {
                        MessageBox.Show($"La Contraseña no coincide con la del Usuario\n" +
                        $"Intentelo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {
                    MessageBox.Show($"Nombre de Usuario no encontrado\n" +
                    $"Intentelo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                
            }
        }
    }
}
