using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewMostrarItemSelecionado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarItens();
        }

        private void CarregarItens()
        {
            for (int i = 1; i <= 20; i++)
            {
                Lista.Items.Add(string.Format("Item {0}", i));
            }
        }

        private void SelecionarUltimoItem_Click(object sender, EventArgs e)
        {
            var ultimoItemDaLista = Lista.Items[Lista.Items.Count - 1];
            ultimoItemDaLista.Selected = true;
            ultimoItemDaLista.EnsureVisible();
            Lista.Select();
        }
    }
}
