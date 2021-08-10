using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class BUSCAR_PRODUCTO : Form
    {
        private string product_id = "";

        public BUSCAR_PRODUCTO()
        {
            InitializeComponent();
        }

        private void BUSCAR_PRODUCTO_Load(object sender, EventArgs e)
        {
            llenar_combo_lineas();
            txtDescripcion.Focus();
        }

        private void llenar_combo_lineas()
        {
            try
            {
                cmbLineas.Items.Add("TODAS");
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "select Linea from Grupo_de_Productos";
                SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbLineas.Items.Add(rdr["Linea"].ToString());
                }
                rdr.Close();
                cmbLineas.SelectedIndex = 0;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = rdDescripcion.Checked;
            if (rdDescripcion.Checked)
            {
                txtDescripcion.Focus();
            }
            else
            {
                txtDescripcion.Text = "";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtCodigo.Enabled = rdCodigo.Checked;
            if (rdCodigo.Checked)
            {
                txtCodigo.Focus();
            }
            else
            {
                txtCodigo.Text = "";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Se buscará por descripción");
            txtAccion.Enabled = rdAccion.Checked;
            if (rdAccion.Checked)
            {
                txtAccion.Focus();
            }
            else
            {
                txtAccion.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Se buscará por descripción");
            txtPrincipio.Enabled = rdPrincipio.Checked;
            if (rdPrincipio.Checked)
            {
                txtPrincipio.Focus();
            }
            else
            {
                txtPrincipio.Text = "";
            }
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            buscar_productos();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            buscar_productos();
        }

        private void txtAccion_TextChanged(object sender, EventArgs e)
        {
            buscar_productos();
        }

        private void txtPrincipio_TextChanged(object sender, EventArgs e)
        {
            buscar_productos();
        }

        private void buscar_productos()
        {
            string query = "SELECT Id_Producto1, codigo as Código, Descripcion as Descripción, stock as Stock, Stock_minimo, Precio_de_venta as Precio, Precio_mayoreo as Mayoreo " +
                "FROM Producto1 p INNER JOIN Grupo_de_Productos gp ON p.Id_grupo = gp.Idline ";
            if (rdDescripcion.Checked)
            {
                query += "WHERE Descripcion LIKE '%" + txtDescripcion.Text + "%'";
            }
            else if (rdCodigo.Checked)
            {
                query += "WHERE Codigo LIKE '%" + txtCodigo.Text + "%'";
            }
            else if (rdAccion.Checked)
            {
                query += "WHERE Descripcion LIKE '%" + txtAccion.Text + "%'";
            }
            else if (rdPrincipio.Checked)
            {
                query += "WHERE Descripcion LIKE '%" + txtPrincipio.Text + "%'";
            }

            if (cmbLineas.SelectedIndex != 0)
            {
                query += " AND Linea = '" + cmbLineas.SelectedItem.ToString() + "'";
            }

            DataTable dt = new DataTable();
            CONEXION.CONEXIONMAESTRA.abrir();
            SqlDataAdapter da = new SqlDataAdapter(query, CONEXION.CONEXIONMAESTRA.conectar);
            da.Fill(dt);
            dataProductos.DataSource = dt;
            CONEXION.CONEXIONMAESTRA.cerrar();
            dataProductos.Columns[0].Visible = false;
            dataProductos.Columns[4].Visible = false;
            dataProductos.ClearSelection();
        }

        private void cmbLineas_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscar_productos();
        }

        private void dataProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.product_id = dataProductos.SelectedCells[0].Value.ToString();
            Dispose();
        }

        public string get_product_id()
        {
            return this.product_id;
        }

        private void dataProductos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (Convert.ToDecimal(((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString()) <= 0)
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 87, 87);
            }
            else if (Convert.ToDecimal(((DataGridView)sender).Rows[e.RowIndex].Cells[3].Value.ToString()) <= Convert.ToDecimal(((DataGridView)sender).Rows[e.RowIndex].Cells[4].Value.ToString()))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 133);
            }
        }
    }
}
