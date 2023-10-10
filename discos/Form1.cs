using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace discos
{
    public partial class Form1 : Form
        
    {
        List<Disco> listaDiscos;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();
            listaDiscos = negocio.listar();
            dgvDiscos.DataSource = listaDiscos;
            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;
            cargarImagen(listaDiscos[0].UrlImagenTapa);
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
           
        }

        private void cargarImagen(string imagen)
        {
            try
            { 
                pbxDiscos.Load(imagen);

            }
            catch (Exception ex)
            {

                pbxDiscos.Load("https://i.stack.imgur.com/y9DpT.jpg");
            }
        }
    }
}
