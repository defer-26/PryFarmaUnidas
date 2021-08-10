using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class BUSCAR_CLIENTE : Form
    {
        private string nombre;
        private string documento;
        private string id;

        public BUSCAR_CLIENTE(string documento, string nombre)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.documento = documento;
            listar_clientes();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtrucdefactura.Text.Trim().Length == 8 || txtrucdefactura.Text.Trim().Length == 11)
            {
                if(txtnombrecliente.Text.Trim().Length != 0)
                {
                    try
                    {
                        CONEXION.CONEXIONMAESTRA.abrir();
                        string query = "INSERT INTO clientes (Nombre, Direccion, IdentificadorFiscal, Celular, Estado, Saldo) " +
                            "VALUES ('" + txtnombrecliente.Text + "', '" + txtdirecciondefactura.Text + "', '" + txtrucdefactura.Text + "', '" + txtcelular.Text + "', 0, 0.00)";
                        SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                        cmd.ExecuteNonQuery();
                        CONEXION.CONEXIONMAESTRA.cerrar();
                        CONEXION.CONEXIONMAESTRA.abrir();
                        query = "SELECT id FROM clientes WHERE IdentificadorFiscal = '" + txtrucdefactura.Text + "'";
                        cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                        this.id = cmd.ExecuteScalar().ToString();
                        CONEXION.CONEXIONMAESTRA.cerrar();
                        this.nombre = txtnombrecliente.Text;
                        this.documento = txtrucdefactura.Text;
                        Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un nombre");
                    txtnombrecliente.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar un DNI (8 dígitos) o un RUC (11 dígitos)");
                txtrucdefactura.Focus();
            }
        }

        public string getName()
        {
            return this.nombre;
        }

        public string getDocument()
        {
            return this.documento;
        }

        public string getId()
        {
            return this.id;
        }

        private void txtrucdefactura_TextChanged(object sender, EventArgs e)
        {
            listar_clientes();
        }

        private void listar_clientes()
        {
            try
            {
                DataTable dt = new DataTable();
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "SELECT idclientev, IdentificadorFiscal as Documento, Nombre FROM clientes" +
                                " WHERE nombre + IdentificadorFiscal LIKE '%" + txtrucdefactura.Text + "%' AND nombre != 'GENERICO'";
                SqlDataAdapter da = new SqlDataAdapter(query, CONEXION.CONEXIONMAESTRA.conectar);
                da.Fill(dt);
                dataClientes.DataSource = dt;
                dataClientes.Columns[0].Visible = false;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dataClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = dataClientes.SelectedCells[0].Value.ToString();
            this.documento = dataClientes.SelectedCells[1].Value.ToString();
            this.nombre = dataClientes.SelectedCells[2].Value.ToString();
            Dispose();
        }

        private void BUSCAR_CLIENTE_Load(object sender, EventArgs e)
        {

        }
    }
}
