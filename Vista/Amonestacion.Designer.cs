
namespace Administracion_Torneos.Vista
{
    partial class Amonestacion
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
            this.listaamonestaciones = new System.Windows.Forms.DataGridView();
            this.colortarjeta = new System.Windows.Forms.TextBox();
            this.multa = new System.Windows.Forms.NumericUpDown();
            this.come = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.editar = new System.Windows.Forms.Button();
            this.eliminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.listaamonestaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.multa)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listaamonestaciones
            // 
            this.listaamonestaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaamonestaciones.Location = new System.Drawing.Point(117, 28);
            this.listaamonestaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listaamonestaciones.Name = "listaamonestaciones";
            this.listaamonestaciones.RowHeadersWidth = 51;
            this.listaamonestaciones.Size = new System.Drawing.Size(449, 185);
            this.listaamonestaciones.TabIndex = 0;
            this.listaamonestaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaamonestaciones_CellContentClick);
            // 
            // colortarjeta
            // 
            this.colortarjeta.Location = new System.Drawing.Point(141, 324);
            this.colortarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colortarjeta.Name = "colortarjeta";
            this.colortarjeta.Size = new System.Drawing.Size(168, 22);
            this.colortarjeta.TabIndex = 1;
            // 
            // multa
            // 
            this.multa.DecimalPlaces = 2;
            this.multa.Location = new System.Drawing.Point(141, 368);
            this.multa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.multa.Maximum = new decimal(new int[] {
            -1593835521,
            466537709,
            54210,
            0});
            this.multa.Name = "multa";
            this.multa.Size = new System.Drawing.Size(149, 22);
            this.multa.TabIndex = 2;
            // 
            // come
            // 
            this.come.Location = new System.Drawing.Point(141, 411);
            this.come.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.come.Name = "come";
            this.come.Size = new System.Drawing.Size(180, 22);
            this.come.TabIndex = 3;
            this.come.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 324);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Color de Tarjeta ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 377);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precio de Multa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 420);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comentario ";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(393, 364);
            this.save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(100, 28);
            this.save.TabIndex = 7;
            this.save.Text = "Guardar";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // editar
            // 
            this.editar.Location = new System.Drawing.Point(213, 220);
            this.editar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.editar.Name = "editar";
            this.editar.Size = new System.Drawing.Size(100, 28);
            this.editar.TabIndex = 8;
            this.editar.Text = "Editar";
            this.editar.UseVisualStyleBackColor = true;
            this.editar.Click += new System.EventHandler(this.editar_Click);
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(352, 220);
            this.eliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(100, 28);
            this.eliminar.TabIndex = 9;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editar);
            this.groupBox1.Controls.Add(this.eliminar);
            this.groupBox1.Controls.Add(this.listaamonestaciones);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(691, 268);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado";
            // 
            // Amonestacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(749, 463);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.come);
            this.Controls.Add(this.multa);
            this.Controls.Add(this.colortarjeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Amonestacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Amonestacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Amonestacion_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.listaamonestaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.multa)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaamonestaciones;
        private System.Windows.Forms.TextBox colortarjeta;
        private System.Windows.Forms.NumericUpDown multa;
        private System.Windows.Forms.TextBox come;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button editar;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}