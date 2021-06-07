
namespace Administracion_Torneos.Vista
{
    partial class Partidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listjornadas = new System.Windows.Forms.DataGridView();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.horainicio = new System.Windows.Forms.DateTimePicker();
            this.horafin = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.local = new System.Windows.Forms.NumericUpDown();
            this.visita = new System.Windows.Forms.NumericUpDown();
            this.Back = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.accionespopartido = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listjornadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.local)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visita)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1041, 85);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 321);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hora Fin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 374);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Hora Inicio";
            // 
            // listjornadas
            // 
            this.listjornadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listjornadas.Location = new System.Drawing.Point(20, 54);
            this.listjornadas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listjornadas.Name = "listjornadas";
            this.listjornadas.RowHeadersWidth = 51;
            this.listjornadas.Size = new System.Drawing.Size(1013, 235);
            this.listjornadas.TabIndex = 13;
            this.listjornadas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listjornadas_CellContentClick);
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(83, 318);
            this.fecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(215, 22);
            this.fecha.TabIndex = 14;
            this.fecha.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 434);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Marcador Local";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 434);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Marcador visita";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(765, 374);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(176, 24);
            this.comboBox1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(680, 380);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Canchas";
            // 
            // horainicio
            // 
            this.horainicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horainicio.Location = new System.Drawing.Point(111, 373);
            this.horainicio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horainicio.Name = "horainicio";
            this.horainicio.Size = new System.Drawing.Size(215, 22);
            this.horainicio.TabIndex = 21;
            // 
            // horafin
            // 
            this.horafin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.horafin.Location = new System.Drawing.Point(423, 374);
            this.horafin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.horafin.Name = "horafin";
            this.horafin.Size = new System.Drawing.Size(215, 22);
            this.horafin.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1041, 151);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 47);
            this.button2.TabIndex = 23;
            this.button2.Text = "selecionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // local
            // 
            this.local.Location = new System.Drawing.Point(147, 432);
            this.local.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(117, 22);
            this.local.TabIndex = 24;
            // 
            // visita
            // 
            this.visita.Location = new System.Drawing.Point(400, 432);
            this.visita.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.visita.Name = "visita";
            this.visita.Size = new System.Drawing.Size(160, 22);
            this.visita.TabIndex = 25;
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(979, 480);
            this.Back.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(152, 47);
            this.Back.TabIndex = 26;
            this.Back.Text = "Regresar";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(604, 496);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 27;
            this.label7.Text = "Acciones por partido ";
            // 
            // accionespopartido
            // 
            this.accionespopartido.FormattingEnabled = true;
            this.accionespopartido.Items.AddRange(new object[] {
            "Registro de Goles ",
            "Registro de Tarjetas",
            "Registro de Cambios",
            "Registro de Arbitros"});
            this.accionespopartido.Location = new System.Drawing.Point(755, 492);
            this.accionespopartido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accionespopartido.Name = "accionespopartido";
            this.accionespopartido.Size = new System.Drawing.Size(187, 24);
            this.accionespopartido.TabIndex = 28;
            this.accionespopartido.SelectedIndexChanged += new System.EventHandler(this.accionespopartido_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(205, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(304, 22);
            this.textBox1.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Torneo";
            // 
            // Partidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1195, 554);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.accionespopartido);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.visita);
            this.Controls.Add(this.local);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.horafin);
            this.Controls.Add(this.horainicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.listjornadas);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Partidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jornadas";
            this.Load += new System.EventHandler(this.Partidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listjornadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.local)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visita)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView listjornadas;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker horainicio;
        private System.Windows.Forms.DateTimePicker horafin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown local;
        private System.Windows.Forms.NumericUpDown visita;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox accionespopartido;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
    }
}