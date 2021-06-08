
namespace Administracion_Torneos.Vista
{
    partial class vistaReporteRobertoEquipos
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
            this.Equiposlist = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Equiposlist)).BeginInit();
            this.SuspendLayout();
            // 
            // Equiposlist
            // 
            this.Equiposlist.AllowUserToAddRows = false;
            this.Equiposlist.AllowUserToDeleteRows = false;
            this.Equiposlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Equiposlist.Location = new System.Drawing.Point(51, 60);
            this.Equiposlist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Equiposlist.Name = "Equiposlist";
            this.Equiposlist.ReadOnly = true;
            this.Equiposlist.RowHeadersWidth = 51;
            this.Equiposlist.RowTemplate.Height = 24;
            this.Equiposlist.Size = new System.Drawing.Size(1114, 382);
            this.Equiposlist.TabIndex = 1;
            // 
            // vistaReporteRobertoEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1228, 490);
            this.Controls.Add(this.Equiposlist);
            this.Name = "vistaReporteRobertoEquipos";
            this.Text = "vistaReporteRobertoEquipos";
            ((System.ComponentModel.ISupportInitialize)(this.Equiposlist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Equiposlist;
    }
}