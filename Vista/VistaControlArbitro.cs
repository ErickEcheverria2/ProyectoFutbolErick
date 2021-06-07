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
    public partial class VistaControlArbitro : Form
    {
        public ControlArbitroDb controlContext = new ControlArbitroDb();
        public Modelo.ControlArbitro controlSeleccionada = new Modelo.ControlArbitro();
        int idPartido, idTorneo;
        public enum Acciones
        {
            editar = 0,
            guardar = 1
        }
        public int accion = 1;



        public VistaControlArbitro(int idPartido, int idTorneo)
        {
            InitializeComponent();
            
            controlarblist.AllowUserToAddRows = false;
            controlarblist.AllowDrop = false;
            controlarblist.AllowUserToDeleteRows = false;
            controlarblist.MultiSelect = false;
            controlContext.seleccionar(comboBox1);

            this.idPartido = idPartido;
            this.idTorneo = idTorneo;
            GetControlAct();
        }

        public void GetControlAct()
        {
            controlarblist.DataSource = controlContext.GetArbitros(idPartido);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int validar = 0;
            Modelo.ControlArbitro controlArbitro = new Modelo.ControlArbitro();
            if (accion == 1)
            {
                controlArbitro.Pago = txtPago.Text;
                string arbitro = Convert.ToString(comboBox1.SelectedItem);
                string[] arregloArbitro = arbitro.Split('|');
                int dpiArbitro = Convert.ToInt32(arregloArbitro[0]);
                controlArbitro.DPI_Arbitro = dpiArbitro;
                controlArbitro.Id_Juego = idPartido;
                List<ControlArbitro> pos = controlContext.GetArbitros(idPartido);
                foreach (var i in pos)
                {
                    if (i.DPI_Arbitro == controlArbitro.DPI_Arbitro)
                    {
                        validar = 1;
                    }

                }
                if (validar == 0)
                {
                    controlContext.AddControl(controlArbitro);
                    GetControlAct();
                }
                else if (validar == 1)
                {
                    MessageBox.Show("Este arbitro ya fue agregado al partido");
                }
            }
            else if (accion == 0)
            {
                string arbitro = Convert.ToString(comboBox1.SelectedItem);
                string[] arregloArbitro = arbitro.Split('|');
                long dpiArbitro = Convert.ToInt64(arregloArbitro[0]);
                string Pago = txtPago.Text;
                controlContext.UpdateControl(dpiArbitro, idPartido, Pago);
                GetControlAct();
                comboBox1.Enabled = true;
                accion = 1;
            }

            comboBox1.SelectedIndex = -1;
            txtPago.Clear();

        }

        public int? GetID()
        {
            try
            {
                return int.Parse(
                    controlarblist.Rows[controlarblist.CurrentRow.Index].Cells[0].Value.ToString()
                    );
            }
            catch
            {
                return null;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            accion = 0;
            int? DPI_Arbitro = GetID();
            Modelo.ControlArbitro controledit = controlContext.GetArbitro(DPI_Arbitro, idPartido);
            foreach (var i in comboBox1.Items)
            {
                string[] data = i.ToString().Split('|');
                int id = Convert.ToInt32(data[0]);
                if (id == controledit.DPI_Arbitro)
                {
                    comboBox1.SelectedItem = i.ToString();
                }
            }
            txtPago.Text = controledit.Pago;
            comboBox1.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? DPI_Arbitro = GetID();
            controlContext.DeleteControl(DPI_Arbitro, idPartido);
            GetControlAct();
        }

        private void VistaControlArbitro_FormClosing(object sender, FormClosingEventArgs e)
        {
            Partidos partidos = new Partidos(idTorneo);
            partidos.Show();
        }
    }
}
