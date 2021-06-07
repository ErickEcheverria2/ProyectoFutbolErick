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
    public partial class AlquilarCancha : Form
    {
        public AlquilarCanchaDB alquilarDB = new AlquilarCanchaDB();
        public VentanaLoginDB loginDB = new VentanaLoginDB();

        int Id_UsuarioIngresado;

        int opcion = 0;

        public AlquilarCancha(int Id_Usuario)
        {
            InitializeComponent();
            comboBox1.DataSource = alquilarDB.CargarComboCanchas(); // Solicitando la informacion de la base de datos para cargarla en el combobox
            comboBox1.DisplayMember = "Nombre"; // Asignando el valor que se mostrara en el combobox
            comboBox1.ValueMember = "NoCancha"; // Valor que estara detras de Display

            listAlquileres.DataSource = alquilarDB.GetAlquileres();

            Id_UsuarioIngresado = Id_Usuario;
        }

        private void AlquilarCancha_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
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
        private DateTime buscar_Fecha()
        {
            try
            {
                return DateTime.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[7].Value.ToString());
            }

            catch
            {
                return Convert.ToDateTime("01-01-2001");
            }

        }
        private TimeSpan buscar_HoraInicio()
        {
            try
            {
                return TimeSpan.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[8].Value.ToString());
            }

            catch
            {
                return TimeSpan.Parse("00:00:00");
            }
        }
        private TimeSpan buscar_HoraFinal()
        {
            try
            {
                return TimeSpan.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[9].Value.ToString());
            }

            catch
            {
                return TimeSpan.Parse("00:00:00");
            }
        }




        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(opcion == 0)
            {
                if (textBox1.Text == "" || txtNombre.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show($"Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
          
                    TimeSpan horaInicio = TimeSpan.Parse(textBox4.Text);
                    TimeSpan horaFinal = TimeSpan.Parse(textBox5.Text);


                    int cantidadPartidosJugar = alquilarDB.obtenerCantidadPartidosJugarHoraFecha(Convert.ToInt32(comboBox1.SelectedValue), fecha_nac.Value, horaInicio, horaFinal);
                    int cantidadPartidosJugarJornadas = alquilarDB.obtenerCantidadPartidosJugarHoraFechaJornadas(Convert.ToInt32(comboBox1.SelectedValue), fecha_nac.Value, horaInicio, horaFinal);

                    if (cantidadPartidosJugar > 0 || cantidadPartidosJugarJornadas > 0)
                    {
                        MessageBox.Show($"Alquiler NO Valido \nActualmente la cancha se encuentra ocupada en el horario indicado\nCantidad de partidos Alquilados a la fecha indicada: {cantidadPartidosJugar}\nCantidad de partidos en Torneos a la fecha indicada: {cantidadPartidosJugarJornadas}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        decimal totalDeHorasAlquilar = Convert.ToDecimal(horaFinal.TotalHours - horaInicio.TotalHours);

                        decimal cantidadPagarPorHora = alquilarDB.obtenerPrecioPorHora(Convert.ToInt32(comboBox1.SelectedValue));

                        totalDeHorasAlquilar = Decimal.Round(totalDeHorasAlquilar, 2);

                        decimal totalPagar = totalDeHorasAlquilar * cantidadPagarPorHora;

                        totalPagar = Decimal.Round(totalPagar, 2);
                        
                        if (Convert.ToDecimal(textBox8.Text) > totalPagar || Convert.ToDecimal(textBox8.Text) < totalPagar)
                        {
                            MessageBox.Show($"El monto de pago no corresponde a lo establecido\nHoras a Alquilar: {totalDeHorasAlquilar}\nCantidad a pagar por Hora: {cantidadPagarPorHora}\nTotal a Pagar: {totalPagar}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            string dia = fecha_nac.Value.ToString("dddd");

                            Modelo.InformacionEmpresa empresa = alquilarDB.obtenerHorarios();

                            if (dia == "lunes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaLunes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaLunes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Lunes: {empresa.HoraEntradaLunes} - {empresa.HoraSalidaLunes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "martes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaMartes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaMartes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Martes: {empresa.HoraEntradaMartes} - {empresa.HoraSalidaMartes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "miércoles" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaMiercoles || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaMiercoles))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Miercoles: {empresa.HoraEntradaMiercoles} - {empresa.HoraSalidaMiercoles}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "jueves" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaJueves || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaJueves))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Jueves: {empresa.HoraEntradaJueves} - {empresa.HoraSalidaJueves}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "viernes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaViernes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaViernes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Viernes: {empresa.HoraEntradaViernes} - {empresa.HoraSalidaViernes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "sábado" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaSabado || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaSabado))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Sabado: {empresa.HoraEntradaSabado} - {empresa.HoraSalidaSabado}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "domingo" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaDomingo || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaDomingo))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Domingo: {empresa.HoraEntradaDomingo} - {empresa.HoraSalidaDomingo}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                Modelo.AlquilarCancha alquilar = new Modelo.AlquilarCancha();
                                alquilar.DPI_Persona = Convert.ToInt64(textBox1.Text);
                                alquilar.Nombres = txtNombre.Text;
                                alquilar.Apellidos = textBox2.Text;
                                alquilar.Telefono = textBox7.Text;
                                alquilar.Correo = textBox3.Text;
                                alquilar.NoCancha = Convert.ToInt32(comboBox1.SelectedValue);
                                alquilar.DiaAlquiler = fecha_nac.Value;
                                alquilar.HoraInicio = TimeSpan.Parse(textBox4.Text);
                                alquilar.HoraFinal = TimeSpan.Parse(textBox5.Text);
                                alquilar.costoAlquiler = Convert.ToDecimal(textBox8.Text);

                                alquilarDB.AgregarAlquiler(alquilar);

                                listAlquileres.DataSource = alquilarDB.GetAlquileres();

                                textBox1.Text = "";
                                txtNombre.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox7.Text = "";
                                textBox8.Text = "";

                                label12.Text = $"La persona --- --- \n" +
                                $"tendrá que pagar\n" +
                                $"por el alquiler de la cancha: 00.00\n" +
                                $"y por el servicio de arbitraje: 00.00\n\n" +
                                $"Total: 00.00";
                            }
                        }
                    }
                }
            }
            else
            {
                if (textBox1.Text == "" || txtNombre.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show($"Ingrese los datos solicitados", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    TimeSpan horaInicio = TimeSpan.Parse(textBox4.Text);
                    TimeSpan horaFinal = TimeSpan.Parse(textBox5.Text);


                    int cantidadPartidosJugar = alquilarDB.obtenerCantidadPartidosJugarHoraFechaeExecptoElMismo(buscar_id(), Convert.ToInt32(comboBox1.SelectedValue), fecha_nac.Value, horaInicio, horaFinal);
                    int cantidadPartidosJugarJornadas = alquilarDB.obtenerCantidadPartidosJugarHoraFechaJornadas(Convert.ToInt32(comboBox1.SelectedValue), fecha_nac.Value, horaInicio, horaFinal);

                    if (cantidadPartidosJugar > 0 || cantidadPartidosJugarJornadas > 0)
                    {
                        MessageBox.Show($"Alquiler NO Valido \nActualmente la cancha se encuentra ocupada en el horario indicado\nCantidad de partidos Alquilados a la fecha indicada: {cantidadPartidosJugar}\nCantidad de partidos en Torneos a la fecha indicada: {cantidadPartidosJugarJornadas}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        decimal totalDeHorasAlquilar = Convert.ToDecimal(horaFinal.TotalHours - horaInicio.TotalHours);

                        decimal cantidadPagarPorHora = alquilarDB.obtenerPrecioPorHora(Convert.ToInt32(comboBox1.SelectedValue));

                        totalDeHorasAlquilar = Decimal.Round(totalDeHorasAlquilar, 2);

                        decimal totalPagar = totalDeHorasAlquilar * cantidadPagarPorHora;

                        totalPagar = Decimal.Round(totalPagar,2);

                        if (Convert.ToDecimal(textBox8.Text) > totalPagar || Convert.ToDecimal(textBox8.Text) < totalPagar)
                        {
                            MessageBox.Show($"El monto de pago no corresponde a lo establecido\nHoras a Alquilar: {totalDeHorasAlquilar}\nCantidad a pagar por Hora: {cantidadPagarPorHora}\nTotal a Pagar: {totalPagar}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            string dia = fecha_nac.Value.ToString("dddd");

                            Modelo.InformacionEmpresa empresa = alquilarDB.obtenerHorarios();

                            if (dia == "lunes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaLunes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaLunes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Lunes: {empresa.HoraEntradaLunes} - {empresa.HoraSalidaLunes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "martes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaMartes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaMartes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Martes: {empresa.HoraEntradaMartes} - {empresa.HoraSalidaMartes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "miércoles" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaMiercoles || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaMiercoles))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Miercoles: {empresa.HoraEntradaMiercoles} - {empresa.HoraSalidaMiercoles}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "jueves" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaJueves || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaJueves))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Jueves: {empresa.HoraEntradaJueves} - {empresa.HoraSalidaJueves}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "viernes" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaViernes || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaViernes))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Viernes: {empresa.HoraEntradaViernes} - {empresa.HoraSalidaViernes}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "sábado" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaSabado || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaSabado))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Sabado: {empresa.HoraEntradaSabado} - {empresa.HoraSalidaSabado}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else if (dia == "domingo" && (TimeSpan.Parse(textBox4.Text) < empresa.HoraEntradaDomingo || TimeSpan.Parse(textBox5.Text) > empresa.HoraSalidaDomingo))
                            {
                                MessageBox.Show($"Horario de Alquiler invalido \n\n" +
                                    $"Horario Dia Domingo: {empresa.HoraEntradaDomingo} - {empresa.HoraSalidaDomingo}", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                Modelo.AlquilarCancha alquilar = new Modelo.AlquilarCancha();
                                alquilar.Id_Alquiler = buscar_id();
                                alquilar.DPI_Persona = Convert.ToInt64(textBox1.Text);
                                alquilar.Nombres = txtNombre.Text;
                                alquilar.Apellidos = textBox2.Text;
                                alquilar.Telefono = textBox7.Text;
                                alquilar.Correo = textBox3.Text;
                                alquilar.NoCancha = Convert.ToInt32(comboBox1.SelectedValue);
                                alquilar.DiaAlquiler = fecha_nac.Value;
                                alquilar.HoraInicio = TimeSpan.Parse(textBox4.Text);
                                alquilar.HoraFinal = TimeSpan.Parse(textBox5.Text);
                                alquilar.costoAlquiler = Convert.ToDecimal(textBox8.Text);

                                alquilarDB.actualizar_Alquiler(alquilar);

                                listAlquileres.DataSource = alquilarDB.GetAlquileres();

                                textBox1.Text = "";
                                txtNombre.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                textBox5.Text = "";
                                textBox7.Text = "";
                                textBox8.Text = "";

                                btnModificar.Enabled = true;
                                btnEliminar.Enabled = true;
                                listAlquileres.Enabled = true;
                                btnAgregar.Text = "Guardar";

                                opcion = 0;
                            }
                        }
                    }
                }
            }
        }

        

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void AlquilarCancha_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int Id_Cancha = buscar_id();
            Modelo.AlquilarCancha alquilar = alquilarDB.buscarAlquiler(Id_Cancha);
            textBox1.Text = Convert.ToString(alquilar.DPI_Persona);
            txtNombre.Text = alquilar.Nombres;
            textBox2.Text = alquilar.Apellidos;
            textBox3.Text = alquilar.Correo;
            textBox4.Text = Convert.ToString(alquilar.HoraInicio);
            textBox5.Text = Convert.ToString(alquilar.HoraFinal);
            DateTime fechaAlquilar = alquilar.DiaAlquiler;
            fecha_nac.Value = fechaAlquilar;
            textBox7.Text = alquilar.Telefono;
            textBox8.Text = Convert.ToString(alquilar.costoAlquiler);
            comboBox1.SelectedValue = alquilar.NoCancha;

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            listAlquileres.Enabled = false;
            btnAgregar.Text = "Actualizar";

            opcion = 1;

            label12.Text = $"La persona --- --- \n" +
                            $"tendrá que pagar\n" +
                            $"por el alquiler de la cancha: 00.00\n" +
                            $"y por el servicio de arbitraje: 00.00\n\n" +
                            $"Total: 00.00";


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo; //Mensaje de advetencia
            DialogResult dr = MessageBox.Show("¿Seguro desea eliminar el Alquiler del registro? Esta opcion no se puede deshacer", "Advertencia", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                alquilarDB.EliminarAlquiler(buscar_id());

                label12.Text = $"La persona --- --- \n" +
                            $"tendrá que pagar\n" +
                            $"por el alquiler de la cancha: 00.00\n" +
                            $"y por el servicio de arbitraje: 00.00\n\n" +
                            $"Total: 00.00";
            }

            listAlquileres.DataSource = alquilarDB.GetAlquileres();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Id_Alquiler = buscar_id();
            DateTime DiaAlquiler = buscar_Fecha();
            TimeSpan HoraIncio = buscar_HoraInicio();
            TimeSpan HoraFinal = buscar_HoraFinal();

            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Servicio de Arbitraje");

            ServicioArbitraje servicio = new ServicioArbitraje(Id_Alquiler,DiaAlquiler,HoraIncio,HoraFinal);
            servicio.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }
        private void listAlquileres_MouseClick(object sender, MouseEventArgs e)
        {
            int Id_Alquiler = int.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[0].Value.ToString());

            decimal totalAlquilerCanchas = decimal.Parse(listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[10].Value.ToString());

            decimal cantidadPagarServicioArbitraje = alquilarDB.obtenerTotalPagarServicioArbitraje(Id_Alquiler);

            string Nombre = listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[2].Value.ToString();
            string apellido = listAlquileres.Rows[listAlquileres.CurrentRow.Index].Cells[3].Value.ToString();

            label12.Text = $"La persona {Nombre} {apellido} \n"+
                            $"tendrá que pagar\n" +
                            $"por el alquiler de la cancha: {totalAlquilerCanchas}\n"+
                            $"y por el servicio de arbitraje: {cantidadPagarServicioArbitraje}\n\n"+
                            $"Total: {totalAlquilerCanchas+cantidadPagarServicioArbitraje}";
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validaciones = new Validaciones();
            validaciones.validarNumeros(e); //Valida si lo ingresado NO es un numero
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            decimal cantidadPagarPorHora = alquilarDB.obtenerPrecioPorHora(Convert.ToInt32(comboBox1.SelectedValue));
            label13.Text = $"Costo por Hora: {cantidadPagarPorHora}";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
