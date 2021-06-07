using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administracion_Torneos.BD
{
    public class Validaciones
    {
        public void validarNumeros(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
              if (Char.IsPunctuation(e.KeyChar)) //permitir teclas de puntuacion "."
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
                MessageBox.Show("Solamente se permite el ingreso de datos numericos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

}
