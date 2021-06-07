
namespace Administracion_Torneos.Vista
{
    partial class ReportePartidosAfectados
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
            this.listPartidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listPartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // listPartidos
            // 
            this.listPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listPartidos.Location = new System.Drawing.Point(16, 74);
            this.listPartidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listPartidos.Name = "listPartidos";
            this.listPartidos.RowHeadersWidth = 51;
            this.listPartidos.Size = new System.Drawing.Size(968, 356);
            this.listPartidos.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "REPORTE DE PARTIDOS AFECTADOS";
            // 
            // ReportePartidosAfectados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 444);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listPartidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReportePartidosAfectados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePartidosAfectados";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReportePartidosAfectados_FormClosing);
            this.Load += new System.EventHandler(this.ReportePartidosAfectados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listPartidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listPartidos;
        private System.Windows.Forms.Label label1;
    }
}