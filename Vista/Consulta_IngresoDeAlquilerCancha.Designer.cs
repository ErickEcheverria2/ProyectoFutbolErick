
namespace Administracion_Torneos.Vista
{
    partial class Consulta_IngresoDeAlquilerCancha
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listConsulta = new System.Windows.Forms.DataGridView();
            this.buscar = new System.Windows.Forms.Button();
            this.fecha_inicial = new System.Windows.Forms.DateTimePicker();
            this.fecha_final = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.listConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(419, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingresos de Alquiler de Canchas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fecha Inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(228, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Final";
            // 
            // listConsulta
            // 
            this.listConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listConsulta.Location = new System.Drawing.Point(78, 198);
            this.listConsulta.Margin = new System.Windows.Forms.Padding(4);
            this.listConsulta.Name = "listConsulta";
            this.listConsulta.RowHeadersWidth = 51;
            this.listConsulta.Size = new System.Drawing.Size(905, 283);
            this.listConsulta.TabIndex = 18;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(649, 98);
            this.buscar.Margin = new System.Windows.Forms.Padding(4);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(144, 62);
            this.buscar.TabIndex = 19;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.Location = new System.Drawing.Point(320, 94);
            this.fecha_inicial.Margin = new System.Windows.Forms.Padding(4);
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.Size = new System.Drawing.Size(175, 22);
            this.fecha_inicial.TabIndex = 37;
            this.fecha_inicial.Value = new System.DateTime(2021, 5, 18, 0, 0, 0, 0);
            // 
            // fecha_final
            // 
            this.fecha_final.Location = new System.Drawing.Point(320, 137);
            this.fecha_final.Margin = new System.Windows.Forms.Padding(4);
            this.fecha_final.Name = "fecha_final";
            this.fecha_final.Size = new System.Drawing.Size(175, 22);
            this.fecha_final.TabIndex = 36;
            this.fecha_final.Value = new System.DateTime(2021, 5, 18, 0, 0, 0, 0);
            // 
            // Consulta_IngresoDeAlquilerCancha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1053, 554);
            this.Controls.Add(this.fecha_inicial);
            this.Controls.Add(this.fecha_final);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.listConsulta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Consulta_IngresoDeAlquilerCancha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta_IngresoDeAlquilerCancha";
            ((System.ComponentModel.ISupportInitialize)(this.listConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView listConsulta;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.DateTimePicker fecha_inicial;
        private System.Windows.Forms.DateTimePicker fecha_final;
    }
}