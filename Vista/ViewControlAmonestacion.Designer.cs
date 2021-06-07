
namespace Administracion_Torneos.Vista
{
    partial class ViewControlAmonestacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.listTarjetas = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxJugador = new System.Windows.Forms.ComboBox();
            this.cbxTarjeta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTiempo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxEquipo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listTarjetas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "CONTROL DE TARJETAS";
            // 
            // listTarjetas
            // 
            this.listTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listTarjetas.Location = new System.Drawing.Point(43, 66);
            this.listTarjetas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listTarjetas.Name = "listTarjetas";
            this.listTarjetas.RowHeadersWidth = 51;
            this.listTarjetas.Size = new System.Drawing.Size(837, 247);
            this.listTarjetas.TabIndex = 1;
            this.listTarjetas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listTarjetas_CellContentClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(739, 342);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(141, 78);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(344, 346);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Jugador";
            // 
            // cbxJugador
            // 
            this.cbxJugador.FormattingEnabled = true;
            this.cbxJugador.Location = new System.Drawing.Point(412, 342);
            this.cbxJugador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxJugador.Name = "cbxJugador";
            this.cbxJugador.Size = new System.Drawing.Size(160, 24);
            this.cbxJugador.TabIndex = 4;
            // 
            // cbxTarjeta
            // 
            this.cbxTarjeta.FormattingEnabled = true;
            this.cbxTarjeta.Location = new System.Drawing.Point(165, 394);
            this.cbxTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTarjeta.Name = "cbxTarjeta";
            this.cbxTarjeta.Size = new System.Drawing.Size(160, 24);
            this.cbxTarjeta.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 398);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Color de Tarjeta";
            // 
            // cbxTiempo
            // 
            this.cbxTiempo.FormattingEnabled = true;
            this.cbxTiempo.Location = new System.Drawing.Point(412, 394);
            this.cbxTiempo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTiempo.Name = "cbxTiempo";
            this.cbxTiempo.Size = new System.Drawing.Size(160, 24);
            this.cbxTiempo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 398);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tiempo";
            // 
            // cbxEquipo
            // 
            this.cbxEquipo.FormattingEnabled = true;
            this.cbxEquipo.Location = new System.Drawing.Point(165, 342);
            this.cbxEquipo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxEquipo.Name = "cbxEquipo";
            this.cbxEquipo.Size = new System.Drawing.Size(160, 24);
            this.cbxEquipo.TabIndex = 10;
            this.cbxEquipo.SelectedIndexChanged += new System.EventHandler(this.cbxEquipo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 346);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Equipo Local/Visita";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(615, 346);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(100, 28);
            this.btnModificar.TabIndex = 11;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(615, 385);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 12;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // ViewControlAmonestacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 454);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.cbxEquipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxTiempo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxJugador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.listTarjetas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewControlAmonestacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Amonestacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewControlAmonestacion_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listTarjetas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listTarjetas;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxJugador;
        private System.Windows.Forms.ComboBox cbxTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxTiempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxEquipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
    }
}