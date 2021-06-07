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
    public partial class Menucontrol : Form
    {
        public VentanaLoginDB loginDB = new VentanaLoginDB();

        int Id_UsuarioIngresado;

        public Menucontrol(string tipoUsuario, int Id_Usuario)
        {
            InitializeComponent();

            Id_UsuarioIngresado = Id_Usuario;

            if(tipoUsuario == "Operador")
            {
                btnReportes.Enabled = false;
                btnReportes.BackColor = Color.Pink;
                button2.Enabled = false;
                button2.BackColor = Color.Pink;
                button3.Enabled = false;
                button3.BackColor = Color.Pink;
            }
            else if (tipoUsuario == "Administrador")
            {

            }else
            {
                btnTorneo.Enabled = false;
                btnTorneo.BackColor = Color.Pink;
                btnEquipo.Enabled = false;
                btnEquipo.BackColor = Color.Pink;
                btnEntrenador.Enabled = false;
                btnEntrenador.BackColor = Color.Pink;
                btnArbitros.Enabled = false;
                btnArbitros.BackColor = Color.Pink;
                btnAmonestaciones.Enabled = false;
                btnAmonestaciones.BackColor = Color.Pink;
                btnPagoAmonestaciones.Enabled = false;
                btnPagoAmonestaciones.BackColor = Color.Pink;
                btnCanchas.Enabled = false;
                btnCanchas.BackColor = Color.Pink;
                btnJugadores.Enabled = false;
                btnJugadores.BackColor = Color.Pink;
                btnTorneo.Enabled = false;
                btnTorneo.BackColor = Color.Pink;
                button1.Enabled = false;
                button1.BackColor = Color.Pink;
                button2.Enabled = false;
                button2.BackColor = Color.Pink;
                button3.Enabled = false;
                button3.BackColor = Color.Pink;
            }
        }

        private void btnTorneo_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Torneo");
            TorneoCRUD t = new TorneoCRUD(Id_UsuarioIngresado);
            t.ShowDialog();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Equipo");
            ViewEquipo vq = new ViewEquipo();
            vq.ShowDialog();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Entrenador");
            ViewEntrenador ve = new ViewEntrenador();
            ve.ShowDialog();
        }

        private void btnArbitros_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Arbitros");
            VistaArbitro vA = new VistaArbitro();
            vA.ShowDialog();
        }

        private void btnAmonestaciones_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Amonestaciones");
            Amonestacion ar = new Amonestacion();
            ar.ShowDialog();
        }

        private void btnPagoAmonestaciones_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Pagar Amonestaciones");
            ViewPagoAmonestacion viewPagoAmonestacion = new ViewPagoAmonestacion();
            viewPagoAmonestacion.ShowDialog();
        }

        private void btnJugadores_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Jugadores");
            jugadorescrud jrs = new jugadorescrud();
            jrs.ShowDialog();
        }

        private void btnCanchas_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Canchas");
            Canchas c = new Canchas();
            c.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Reportes");
            Reportes reportes = new Reportes();
            reportes.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Alquilar Canchas");
            AlquilarCancha alquilar = new AlquilarCancha(Id_UsuarioIngresado);
            alquilar.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Informacion de la Empresa");
            InformacionEmpresa informacion = new InformacionEmpresa();
            informacion.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginDB.RegistrarEntrada(Id_UsuarioIngresado, "Menu Control de Usuarios");
            UsuarioSistema usuarioSistema = new UsuarioSistema();
            usuarioSistema.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
