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
    public partial class tablapos : Form
    {
        
        public ReportesDB rp = new ReportesDB();
        public TorneoDB trconte = new TorneoDB();
        
        public tablapos()
        {
            InitializeComponent();
             
            pos.AllowUserToAddRows = false;
            pos.AllowDrop = false;
            pos.AllowUserToAddRows = false;
            pos.ReadOnly = true;
            pos.AllowUserToDeleteRows = false;
            pos.MultiSelect = false;

            List<Torneo>  tr = trconte.GetTorneos();
            foreach( var i in tr)
            {
                comboBox1.Items.Add(i.nombre); //llenar el combobox con los ombres de los torneos 
            }
       
        }
        public int  TRAERID()
        {
            List<Torneo> tr = trconte.GetTorneos();
            foreach (var i in tr)
            {
                if ( i.nombre == comboBox1.SelectedItem.ToString()) //traer el id del torneo seleccioando 
                {
                    return i.ID_Torneo;
                }
                 
            }
            return 0;

        }
        private void tablapos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>=0)
            { //validando que se hayta seleccionado un torneo se muestran datos de no ser asi muestra el error 
                int? id = TRAERID();
                pos.DataSource = rp.TablaLocal(id);
            }
            else
            {
                MessageBox.Show("Seleccione un torneo porfavor ");
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {//validando que se hayta seleccionado un torneo se muestran datos de no ser asi muestra el error 
                int id = TRAERID();
                pos.DataSource = rp.tablageneral(id);
            }
            else
            {
                MessageBox.Show("Seleccione un torneo porfavor ");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {//validando que se hayta seleccionado un torneo se muestran datos de no ser asi muestra el error 
                int id = TRAERID();
                pos.DataSource = rp.TablaVisita(id);
            }
            else
            {
                MessageBox.Show("Seleccione un torneo porfavor ");
            }
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tablapos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reportes reportes = new Reportes();
            reportes.Show();
        }
    }
}
