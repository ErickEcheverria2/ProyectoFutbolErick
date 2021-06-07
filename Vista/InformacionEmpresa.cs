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
    public partial class InformacionEmpresa : Form
    {
        public InformacionEmpresaDB informacionDB = new InformacionEmpresaDB();

        public InformacionEmpresa()
        {
            InitializeComponent();

            int Id_Cancha = 1;
            Modelo.InformacionEmpresa empresa = informacionDB.buscarInformacion(Id_Cancha);
            textBox1.Text = empresa.Nombre;
            textBox2.Text = empresa.Direccion;
            textBox3.Text = empresa.Telefono;
            textBox4.Text = Convert.ToString(empresa.CostoDeArbitraje);
            txtEntradaLunes.Text = Convert.ToString(empresa.HoraEntradaLunes);
            txtSalidaLunes.Text = Convert.ToString(empresa.HoraSalidaLunes);
            txtEntradaMartes.Text = Convert.ToString(empresa.HoraEntradaMartes);
            txtSalidaMartes.Text = Convert.ToString(empresa.HoraSalidaMartes);
            txtEntradaMiercoles.Text = Convert.ToString(empresa.HoraEntradaMiercoles);
            txtSalidaMiercoles.Text = Convert.ToString(empresa.HoraSalidaMiercoles);
            txtEntradaJueves.Text = Convert.ToString(empresa.HoraEntradaJueves);
            txtSalidaJueves.Text = Convert.ToString(empresa.HoraSalidaJueves);
            txtEntradaViernes.Text = Convert.ToString(empresa.HoraEntradaViernes);
            txtSalidaViernes.Text = Convert.ToString(empresa.HoraSalidaViernes);
            txtEntradaSabado.Text = Convert.ToString(empresa.HoraEntradaSabado);
            txtSalidaSabado.Text = Convert.ToString(empresa.HoraSalidaSabado);
            txtEntradaDomingo.Text = Convert.ToString(empresa.HoraEntradaDomingo);
            txtSalidaDomingo.Text = Convert.ToString(empresa.HoraSalidaDomingo);

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            txtEntradaLunes.Enabled = false;
            txtSalidaLunes.Enabled = false;
            txtEntradaMartes.Enabled = false;
            txtSalidaMartes.Enabled = false;
            txtEntradaMiercoles.Enabled = false;
            txtSalidaMiercoles.Enabled = false;
            txtEntradaJueves.Enabled = false;
            txtSalidaJueves.Enabled = false;
            txtEntradaViernes.Enabled = false;
            txtSalidaViernes.Enabled = false;
            txtEntradaSabado.Enabled = false;
            txtSalidaSabado.Enabled = false;
            txtEntradaDomingo.Enabled = false;
            txtSalidaDomingo.Enabled = false;

        }
        private void InformacionEmpresa_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        int opcion = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if(opcion == 0)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                txtEntradaLunes.Enabled = true;
                txtSalidaLunes.Enabled = true;
                txtEntradaMartes.Enabled = true;
                txtSalidaMartes.Enabled = true;
                txtEntradaMiercoles.Enabled = true;
                txtSalidaMiercoles.Enabled = true;
                txtEntradaJueves.Enabled = true;
                txtSalidaJueves.Enabled = true;
                txtEntradaViernes.Enabled = true;
                txtSalidaViernes.Enabled = true;
                txtEntradaSabado.Enabled = true;
                txtSalidaSabado.Enabled = true;
                txtEntradaDomingo.Enabled = true;
                txtSalidaDomingo.Enabled = true;

                button1.Text = "Confirmar Cambios";

                opcion = 1;
            }
            else
            {
                if(TimeSpan.Parse(txtEntradaLunes.Text) > TimeSpan.Parse(txtSalidaLunes.Text))
                {
                    MessageBox.Show($"El Horario del día Lunes en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaMartes.Text) > TimeSpan.Parse(txtSalidaMartes.Text))
                {
                    MessageBox.Show($"El Horario del día Martes en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaMiercoles.Text) > TimeSpan.Parse(txtSalidaMiercoles.Text))
                {
                    MessageBox.Show($"El Horario del día Miercoles en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaJueves.Text) > TimeSpan.Parse(txtSalidaJueves.Text))
                {
                    MessageBox.Show($"El Horario del día Jueves en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaViernes.Text) > TimeSpan.Parse(txtSalidaViernes.Text))
                {
                    MessageBox.Show($"El Horario del día Viernes en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaSabado.Text) > TimeSpan.Parse(txtSalidaSabado.Text))
                {
                    MessageBox.Show($"El Horario del día Sabado en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }else if (TimeSpan.Parse(txtEntradaDomingo.Text) > TimeSpan.Parse(txtSalidaDomingo.Text))
                {
                    MessageBox.Show($"El Horario del día Domingo en incoherente\nIngreselo nuevamente", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Modelo.InformacionEmpresa informacion = new Modelo.InformacionEmpresa();
                    informacion.Nombre = textBox1.Text;
                    informacion.Direccion = textBox2.Text;
                    informacion.Telefono = textBox3.Text;
                    informacion.CostoDeArbitraje = Convert.ToDecimal(textBox4.Text);
                    informacion.HoraEntradaLunes = TimeSpan.Parse(txtEntradaLunes.Text);
                    informacion.HoraSalidaLunes = TimeSpan.Parse(txtSalidaLunes.Text);
                    informacion.HoraEntradaMartes = TimeSpan.Parse(txtEntradaMartes.Text);
                    informacion.HoraSalidaMartes = TimeSpan.Parse(txtSalidaMartes.Text);
                    informacion.HoraEntradaMiercoles = TimeSpan.Parse(txtEntradaMiercoles.Text);
                    informacion.HoraSalidaMiercoles = TimeSpan.Parse(txtSalidaMiercoles.Text);
                    informacion.HoraEntradaJueves = TimeSpan.Parse(txtEntradaJueves.Text);
                    informacion.HoraSalidaJueves = TimeSpan.Parse(txtSalidaJueves.Text);
                    informacion.HoraEntradaViernes = TimeSpan.Parse(txtEntradaViernes.Text);
                    informacion.HoraSalidaViernes = TimeSpan.Parse(txtSalidaViernes.Text);
                    informacion.HoraEntradaSabado = TimeSpan.Parse(txtEntradaSabado.Text);
                    informacion.HoraSalidaSabado = TimeSpan.Parse(txtSalidaSabado.Text);
                    informacion.HoraEntradaDomingo = TimeSpan.Parse(txtEntradaDomingo.Text);
                    informacion.HoraSalidaDomingo = TimeSpan.Parse(txtSalidaDomingo.Text);

                    informacionDB.actualizar_Informacion(informacion);

                    button1.Text = "Actualizar Información";

                    opcion = 0;

                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    txtEntradaLunes.Enabled = false;
                    txtSalidaLunes.Enabled = false;
                    txtEntradaMartes.Enabled = false;
                    txtSalidaMartes.Enabled = false;
                    txtEntradaMiercoles.Enabled = false;
                    txtSalidaMiercoles.Enabled = false;
                    txtEntradaJueves.Enabled = false;
                    txtSalidaJueves.Enabled = false;
                    txtEntradaViernes.Enabled = false;
                    txtSalidaViernes.Enabled = false;
                    txtEntradaSabado.Enabled = false;
                    txtSalidaSabado.Enabled = false;
                    txtEntradaDomingo.Enabled = false;
                    txtSalidaDomingo.Enabled = false;
                }

                
            }
            
        }

        private void txtEntradaLunes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaLunes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaMartes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaMartes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaMiercoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaMiercoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaJueves_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaJueves_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaViernes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaViernes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaSabado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaSabado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtEntradaDomingo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void txtSalidaDomingo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }
    }
}
