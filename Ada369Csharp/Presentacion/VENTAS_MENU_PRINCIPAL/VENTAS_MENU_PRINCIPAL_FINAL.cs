using System;
using System.Windows.Forms;
using Ada369Csharp.Presentacion.Admin_nivel_dios;
using Ada369Csharp.Datos;
using Ada369Csharp.Logica;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Ada369Csharp.Presentacion.VENTAS_MENU_PRINCIPAL
{
    public partial class VENTAS_MENU_PRINCIPAL_FINAL : Form
    {
        public static int idVenta;
        public static string tipoComprobante;
        public static string tipoPago;
        public static double total;
        public static string txtventagenerada;
        public static int idusuario_que_inicio_sesion;
        public static int Id_caja;
        public static double txtpantalla;
        public static bool EstadoMediosPago = false;
        double lblStock_de_Productos;
        int idproducto;
        string Tema;
        int contadorVentasEspera;
        decimal stock_max;
        string idCliente = "1";
        string SerialPC;
        string Ip;
        string ResultadoLicencia;
        string FechaFinal;
        string sevendePor;
        string usainventarios;
        string codProducto;


        public VENTAS_MENU_PRINCIPAL_FINAL()
        {
            InitializeComponent();
        }

        private void btndevoluciones_Click(object sender, EventArgs e)
        {
            HistorialVentas.HistorialVentasForm frm = new HistorialVentas.HistorialVentasForm();
            frm.ShowDialog();
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            Dispose();
            DASHBOARD_PRINCIPAL frm = new DASHBOARD_PRINCIPAL();
            frm.ShowDialog();
        }

        private void BtnCerrar_turno_Click(object sender, EventArgs e)
        {
            Dispose();
            CAJA.CIERRE_DE_CAJA frm = new CAJA.CIERRE_DE_CAJA();
            frm.ShowDialog();
        }

        private void btnverMovimientosCaja_Click(object sender, EventArgs e)
        {
            CAJA.Listado_gastos_ingresos frm = new CAJA.Listado_gastos_ingresos();
            frm.ShowDialog();
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            BtnTecladoV.PerformClick();
        }

        private void btnCobros_Click(object sender, EventArgs e)
        {
            Cobros.CobrosForm frm = new Cobros.CobrosForm();
            frm.ShowDialog();
        }

        private void btnCreditoCobrar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorCobrarOk frm = new Apertura_de_credito.PorCobrarOk();
            frm.ShowDialog();
        }

        private void btnCreditoPagar_Click(object sender, EventArgs e)
        {
            Apertura_de_credito.PorPagar frm = new Apertura_de_credito.PorPagar();
            frm.ShowDialog();
        }

        private void btnMayoreo_Click(object sender, EventArgs e)
        {
            aplicar_precio_mayoreo();
        }

        private void aplicar_precio_mayoreo()
        {
            if (detalleVenta.Rows.Count > 0)
            {
                LdetalleVenta parametros = new LdetalleVenta();
                Editar_datos funcion = new Editar_datos();
                parametros.Id_producto = Convert.ToInt32(detalleVenta.SelectedCells[8].Value.ToString());
                parametros.iddetalle_venta = Convert.ToInt32(detalleVenta.SelectedCells[9].Value.ToString());
                if (funcion.aplicar_precio_mayoreo(parametros) == true)
                {
                    Listarproductosagregados();
                }
            }
        }

        private void Listarproductosagregados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_productos_agregados_a_venta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idventa", idVenta);
                da.Fill(dt);
                detalleVenta.DataSource = dt;
                con.Close();
                detalleVenta.Columns[3].Visible = false;
                detalleVenta.Columns[8].Visible = false;
                detalleVenta.Columns[9].Visible = false;
                detalleVenta.Columns[10].Visible = false;
                detalleVenta.Columns[12].Visible = false;
                detalleVenta.Columns[13].Visible = false;
                detalleVenta.Columns[14].Visible = false;
                detalleVenta.Columns[15].Visible = false;
                detalleVenta.Columns[16].Visible = false;
                detalleVenta.Columns[17].Visible = false;
                detalleVenta.Columns[18].Visible = false;
                if (Tema == "Redentor")
                {
                    Bases.Multilinea(ref detalleVenta);
                }
                else
                {
                    Bases.MultilineaTemaOscuro(ref detalleVenta);
                }
                sumar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void sumar()
        {
            try
            {
                int x;
                x = detalleVenta.Rows.Count;
                if (x == 0)
                {
                    txt_total_suma.Text = "0.00";
                }
                double totalpagar;
                totalpagar = 0;
                foreach (DataGridViewRow fila in detalleVenta.Rows)
                {
                    totalpagar += Convert.ToDouble(fila.Cells["Importe"].Value);
                    txt_total_suma.Text = Convert.ToString(totalpagar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreditoPagar_Click_1(object sender, EventArgs e)
        {
            Apertura_de_credito.PorPagar frm = new Apertura_de_credito.PorPagar();
            frm.ShowDialog();
        }

        private void btnMayoreo_Click_1(object sender, EventArgs e)
        {
            aplicar_precio_mayoreo();
        }

        private void btnIngresosCaja_Click(object sender, EventArgs e)
        {
            Ingresos_varios.IngresosVarios frm = new Ingresos_varios.IngresosVarios();
            frm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Gastos_varios.Gastos frm = new Gastos_varios.Gastos();
            frm.ShowDialog();
        }

        private void befectivo_Click(object sender, EventArgs e)
        {
            actualizar_numero_comprobante();
            total = Convert.ToDouble(txt_total_suma.Text);
            if (txtventagenerada == "VENTA GENERADA")
            {
                if(detalleVenta.Rows.Count > 0)
                {
                    if (cmbComprobante.Text == "FACTURA" && txtDocCliente.TextLength != 11)
                    {
                        MessageBox.Show("Para entregar una factura el cliente debe tener registrado un RUC");
                    }
                    else if (cmbComprobante.Text == "BOLETA" && txtDocCliente.TextLength < 8)
                    {
                        MessageBox.Show("Para entregar una boleta debe registrar al cliente");
                    }
                    else
                    {
                        MEDIOS_DE_PAGO frm = new MEDIOS_DE_PAGO();
                        frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No ha agregado productos a la venta");
                }
            }
            else
            {
                MessageBox.Show("No se ha creado la venta");
            }
        }

        private void frm_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (EstadoMediosPago == true)
            {
                Limpiar_para_venta_nueva();
                actualizar_numero_comprobante();
            }
        }

        private void Limpiar_para_venta_nueva()
        {
            txtFecha.Text = DateTime.Today.ToString("dd-MM-yyyy");
            idVenta = 0;
            Listarproductosagregados();
            txtventagenerada = "VENTA NUEVA";
            txtDocCliente.Text = "0";
            txtNomCliente.Text = "GENÉRICO";
            idCliente = "1";
            cmbFormaPago.SelectedIndex = 0;
            cmbComprobante.SelectedIndex = 0;
            sumar();
            //PanelEnespera.Visible = false;
            //panelBienvenida.Visible = true;
            //PanelOperaciones.Visible = false;
            ContarVentasEspera();
        }

        private void ContarVentasEspera()
        {
            Obtener_datos.contarVentasEspera(ref contadorVentasEspera);
            if (contadorVentasEspera == 0)
            {
                panelNotificacionEspera.Visible = false;
            }
            else
            {
                panelNotificacionEspera.Visible = true;
                lblContadorEspera.Text = contadorVentasEspera.ToString();
            }
        }

        private void VENTAS_MENU_PRINCIPAL_FINAL_Load(object sender, EventArgs e)
        {
            llenar_combo_comprobantes();
            cmbFormaPago.SelectedIndex = 0;
            validarLicencia();
            Bases.Cambiar_idioma_regional();
            Bases.Obtener_serialPC(ref SerialPC);
            Obtener_datos.Obtener_id_caja_PorSerial(ref Id_caja);
            Obtener_datos.mostrar_inicio_De_sesion(ref idusuario_que_inicio_sesion);

            ValidarTemaCaja();
            Limpiar_para_venta_nueva();
            ObtenerIpLocal();
        }

        private void ObtenerIpLocal()
        {

            this.Text = Bases.ObtenerIp(ref Ip);
        }

        private void ValidarTemaCaja()
        {
            Obtener_datos.mostrarTemaCaja(ref Tema);
            if (Tema == "Redentor")
            {
                TemaClaro();
                IndicadorTema.Checked = false;
            }
            else
            {
                TemaOscuro();
                IndicadorTema.Checked = true;

            }
        }

        private void TemaOscuro()
        {
            panel1.BackColor = Color.FromArgb(35, 35, 35);
            panel1.ForeColor = Color.White;

            panel2.BackColor = Color.FromArgb(35, 35, 35);
            panel2.ForeColor = Color.White;

            panel3.BackColor = Color.FromArgb(35, 35, 35);
            panel3.ForeColor = Color.White;

            panel4.BackColor = Color.FromArgb(35, 35, 35);
            panel4.ForeColor = Color.White;

            txtFecha.BackColor = Color.FromArgb(20, 20, 20);
            txtFecha.ForeColor = Color.White;

            cmbComprobante.BackColor = Color.FromArgb(20, 20, 20);
            cmbComprobante.ForeColor = Color.White;

            txtNumComprobante.BackColor = Color.FromArgb(20, 20, 20);
            txtNumComprobante.ForeColor = Color.White;

            cmbFormaPago.BackColor = Color.FromArgb(20, 20, 20);
            cmbFormaPago.ForeColor = Color.White;


            txtNomCliente.BackColor = Color.FromArgb(20, 20, 20);
            txtNomCliente.ForeColor = Color.White;

            txtDocCliente.BackColor = Color.FromArgb(20, 20, 20);
            txtDocCliente.ForeColor = Color.White;


            txtProdDescripcion.BackColor = Color.FromArgb(20, 20, 20);
            txtProdDescripcion.ForeColor = Color.White;

            txtProdPrecio.BackColor = Color.FromArgb(20, 20, 20);
            txtProdPrecio.ForeColor = Color.White;

            txtProdCantidad.BackColor = Color.FromArgb(20, 20, 20);
            txtProdCantidad.ForeColor = Color.White;

            txtProdDescuento.BackColor = Color.FromArgb(20, 20, 20);
            txtProdDescuento.ForeColor = Color.White;

            txtProdImporte.BackColor = Color.FromArgb(20, 20, 20);
            txtProdImporte.ForeColor = Color.White;


            button1.BackColor = Color.FromArgb(20, 20, 20);
            button1.ForeColor = Color.White;
            button3.BackColor = Color.FromArgb(20, 20, 20);
            button3.ForeColor = Color.White;
            button4.BackColor = Color.FromArgb(20, 20, 20);
            button4.ForeColor = Color.White;
            button2.BackColor = Color.FromArgb(20, 20, 20);
            button2.ForeColor = Color.White;
            btnCobros.BackColor = Color.FromArgb(20, 20, 20);
            btnCobros.ForeColor = Color.White;
            btnCreditoCobrar.BackColor = Color.FromArgb(20, 20, 20);
            btnCreditoCobrar.ForeColor = Color.White;
            btnCreditoPagar.BackColor = Color.FromArgb(20, 20, 20);
            btnCreditoPagar.ForeColor = Color.White;

            panelC2.BackColor = Color.FromArgb(35, 35, 35);
            panelC2.ForeColor = Color.White;
            PanelC1.BackColor = Color.FromArgb(35, 35, 35);
            PanelC1.ForeColor = Color.White;
            btnadmin.BackColor = Color.FromArgb(35, 35, 35);
            btnadmin.ForeColor = Color.White;

            lblNombreSoftware.ForeColor = Color.White;

            StatusStrip4.BackColor = Color.FromArgb(35, 35, 35);
            StatusStrip4.ForeColor = Color.White;

            btnMayoreo.BackColor = Color.FromArgb(20, 20, 20);
            btnMayoreo.ForeColor = Color.White;
            toolStripButton2.BackColor = Color.FromArgb(20, 20, 20);
            toolStripButton2.ForeColor = Color.White;
            btnIngresosCaja.BackColor = Color.FromArgb(20, 20, 20);
            btnIngresosCaja.ForeColor = Color.White;
            toolStripButton1.BackColor = Color.FromArgb(20, 20, 20);
            toolStripButton1.ForeColor = Color.White;
            btnTeclado.BackColor = Color.FromArgb(20, 20, 20);
            btnTeclado.ForeColor = Color.White;
            ////PanelC1 Encabezado
            //PanelC1.BackColor = Color.FromArgb(35, 35, 35);
            //lblNombreSoftware.ForeColor = Color.White;
            //btnadmin.ForeColor = Color.White;
            //txtbuscar.BackColor = Color.FromArgb(20, 20, 20);
            //txtbuscar.ForeColor = Color.White;
            //lbltipodebusqueda2.BackColor = Color.FromArgb(20, 20, 20);
            ////PanelC2 Intermedio
            //panelC2.BackColor = Color.FromArgb(35, 35, 35);
            //btnCobros.BackColor = Color.FromArgb(45, 45, 45);
            //btnCobros.ForeColor = Color.White;


            //btnCreditoCobrar.BackColor = Color.FromArgb(45, 45, 45);
            //btnCreditoCobrar.ForeColor = Color.White;
            //btnCreditoPagar.BackColor = Color.FromArgb(45, 45, 45);
            //btnCreditoPagar.ForeColor = Color.White;

            ////PanelC3
            //PanelC3.BackColor = Color.FromArgb(35, 35, 35);
            //btnMayoreo.BackColor = Color.FromArgb(45, 45, 45);
            //btnMayoreo.ForeColor = Color.White;
            //btnIngresosCaja.BackColor = Color.FromArgb(45, 45, 45);
            //btnIngresosCaja.ForeColor = Color.White;
            //btnGastos.BackColor = Color.FromArgb(45, 45, 45);
            //btnGastos.ForeColor = Color.White;
            //BtnTecladoV.BackColor = Color.FromArgb(45, 45, 45);
            //BtnTecladoV.ForeColor = Color.White;
            ////PanelC4 Pie de pagina
            //panelC4.BackColor = Color.FromArgb(20, 20, 20);
            //btnespera.BackColor = Color.FromArgb(20, 20, 20);
            //btnespera.ForeColor = Color.White;
            //btnrestaurar.BackColor = Color.FromArgb(20, 20, 20);
            //btnrestaurar.ForeColor = Color.White;
            //btneliminar.BackColor = Color.FromArgb(20, 20, 20);
            //btneliminar.ForeColor = Color.White;
            //btndevoluciones.BackColor = Color.FromArgb(20, 20, 20);
            //btndevoluciones.ForeColor = Color.White;
            ////PanelOperaciones
            //PanelOperaciones.BackColor = Color.FromArgb(28, 28, 28);
            //txt_total_suma.ForeColor = Color.WhiteSmoke;
            ////PanelBienvenida
            //panelBienvenida.BackColor = Color.FromArgb(35, 35, 35);
            //label8.ForeColor = Color.WhiteSmoke;
            Listarproductosagregados();
        }

        private void TemaClaro()
        {
            panel1.BackColor = Color.White;
            panel1.ForeColor = Color.Black;

            panel2.BackColor = Color.White;
            panel2.ForeColor = Color.Black;

            panel3.BackColor = Color.White;
            panel3.ForeColor = Color.Black;

            panel4.BackColor = Color.White;
            panel4.ForeColor = Color.Black;

            txtFecha.BackColor = Color.White;
            txtFecha.ForeColor = Color.Black;

            cmbComprobante.BackColor = Color.White;
            cmbComprobante.ForeColor = Color.Black;


            txtNumComprobante.BackColor = Color.White;
            txtNumComprobante.ForeColor = Color.Black;

            cmbFormaPago.BackColor = Color.White;
            cmbFormaPago.ForeColor = Color.Black;


            txtNomCliente.BackColor = Color.White;
            txtNomCliente.ForeColor = Color.Black;

            txtDocCliente.BackColor = Color.White;
            txtDocCliente.ForeColor = Color.Black;


            txtProdDescripcion.BackColor = Color.White;
            txtProdDescripcion.ForeColor = Color.Black;

            txtProdPrecio.BackColor = Color.White;
            txtProdPrecio.ForeColor = Color.Black;

            txtProdCantidad.BackColor = Color.White;
            txtProdCantidad.ForeColor = Color.Black;

            txtProdDescuento.BackColor = Color.White;
            txtProdDescuento.ForeColor = Color.Black;

            txtProdImporte.BackColor = Color.White;
            txtProdImporte.ForeColor = Color.Black;


            button1.BackColor = Color.WhiteSmoke;
            button1.ForeColor = Color.Black;
            button3.BackColor = Color.WhiteSmoke;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.WhiteSmoke;
            button4.ForeColor = Color.Black;
            button2.BackColor = Color.WhiteSmoke;
            button2.ForeColor = Color.Black;
            btnCobros.BackColor = Color.WhiteSmoke;
            btnCobros.ForeColor = Color.Black;
            btnCreditoCobrar.BackColor = Color.WhiteSmoke;
            btnCreditoCobrar.ForeColor = Color.Black;
            btnCreditoPagar.BackColor = Color.WhiteSmoke;
            btnCreditoPagar.ForeColor = Color.Black;

            panelC2.BackColor = Color.White;
            panelC2.ForeColor = Color.Black;
            PanelC1.BackColor = Color.White;
            PanelC1.ForeColor = Color.Black;
            btnadmin.BackColor = Color.White;
            btnadmin.ForeColor = Color.Black;

            lblNombreSoftware.ForeColor = Color.Black;

            StatusStrip4.BackColor = Color.White;
            StatusStrip4.ForeColor = Color.Black;

            btnMayoreo.BackColor = Color.White;
            btnMayoreo.ForeColor = Color.Black;
            toolStripButton2.BackColor = Color.White;
            toolStripButton2.ForeColor = Color.Black;
            btnIngresosCaja.BackColor = Color.White;
            btnIngresosCaja.ForeColor = Color.Black;
            toolStripButton1.BackColor = Color.White;
            toolStripButton1.ForeColor = Color.Black;
            btnTeclado.BackColor = Color.White;
            btnTeclado.ForeColor = Color.Black;
            //    //PanelC1 encabezado
            //    PanelC1.BackColor = Color.White;
            //    lblNombreSoftware.ForeColor = Color.Black;
            //    btnadmin.ForeColor = Color.Black;
            //    txtbuscar.BackColor = Color.White;
            //    txtbuscar.ForeColor = Color.Black;
            //    lbltipodebusqueda2.BackColor = Color.White;

            //    //PanelC2 intermedio
            //    panelC2.BackColor = Color.White;
            //    btnCobros.BackColor = Color.WhiteSmoke;
            //    btnCobros.ForeColor = Color.Black;


            //    btnCreditoCobrar.BackColor = Color.WhiteSmoke;
            //    btnCreditoCobrar.ForeColor = Color.Black;
            //    btnCreditoPagar.BackColor = Color.WhiteSmoke;
            //    btnCreditoPagar.ForeColor = Color.Black;

            //    //PanelC3
            //    PanelC3.BackColor = Color.White;
            //    btnMayoreo.BackColor = Color.WhiteSmoke;
            //    btnMayoreo.ForeColor = Color.Black;
            //    btnIngresosCaja.BackColor = Color.WhiteSmoke;
            //    btnIngresosCaja.ForeColor = Color.Black;
            //    btnGastos.BackColor = Color.WhiteSmoke;
            //    btnGastos.ForeColor = Color.Black;
            //    BtnTecladoV.BackColor = Color.WhiteSmoke;
            //    BtnTecladoV.ForeColor = Color.Black;
            //    //PanelC4 pie de pagina
            //    panelC4.BackColor = Color.Gainsboro;
            //    btnespera.BackColor = Color.Gainsboro;
            //    btnespera.ForeColor = Color.Black;
            //    btnrestaurar.BackColor = Color.Gainsboro;
            //    btnrestaurar.ForeColor = Color.Black;
            //    btneliminar.BackColor = Color.Gainsboro;
            //    btneliminar.ForeColor = Color.Black;
            //    btndevoluciones.BackColor = Color.Gainsboro;
            //    btndevoluciones.ForeColor = Color.Black;
            //    //PanelOperaciones
            //    PanelOperaciones.BackColor = Color.FromArgb(242, 243, 245);
            //    txt_total_suma.ForeColor = Color.Black;
            //    //PanelBienvenida
            //    panelBienvenida.BackColor = Color.White;
            //    label8.ForeColor = Color.FromArgb(64, 64, 64);
            Listarproductosagregados();
        }

        private void llenar_combo_comprobantes()
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                string query = "select tipodoc from Serializacion where Destino  = 'VENTAS'";
                SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbComprobante.Items.Add(rdr["tipodoc"].ToString());
                }
                rdr.Close();
                cmbComprobante.SelectedIndex = 0;
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void actualizar_numero_comprobante()
        {
            try
            {
                tipoComprobante = cmbComprobante.Text;
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("buscar_Tipo_de_documentos_para_insertar_en_ventas", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@letra", tipoComprobante);
                SqlDataReader rdr = cmd.ExecuteReader();

                string serie = "";
                int numerofin = 0;
                int idcomprobante = 0;
                string cantNumeros = "";

                while (rdr.Read())
                {
                    serie = rdr["Serie"].ToString();
                    numerofin = Convert.ToInt32(rdr["numerofin"].ToString())+1;
                    idcomprobante = Convert.ToInt32(rdr["Id_serializacion"].ToString());
                    cantNumeros = rdr["Cantidad_de_numeros"].ToString();
                }
                rdr.Close();
                txtNumComprobante.Text = serie + "-" + CONEXION.Agregar_ceros_adelante_De_numero.ceros(numerofin.ToString(), Convert.ToInt32(cantNumeros));
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar_numero_comprobante();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BUSCAR_CLIENTE frm = new BUSCAR_CLIENTE(txtDocCliente.Text, txtNomCliente.Text, idCliente);
            frm.ShowDialog();
            txtNomCliente.Text = frm.getName();
            txtDocCliente.Text = frm.getDocument();
            idCliente = frm.getId();
            if (txtventagenerada == "VENTA GENERADA")
            {
                try
                {
                    string query = "UPDATE ventas SET idclientev = " + idCliente + " WHERE idventa = " + idVenta;
                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                    cmd.ExecuteNonQuery();
                    CONEXION.CONEXIONMAESTRA.cerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idCliente = "1";
            txtNomCliente.Text = "GENÉRICO";
            txtDocCliente.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BUSCAR_PRODUCTO frm = new BUSCAR_PRODUCTO();
            frm.ShowDialog();
            try
            {
                string product_id = frm.get_product_id();
                if (product_id != "")
                {
                    idproducto = Convert.ToInt32(product_id);
                    string query = "SELECT * FROM Producto1 WHERE Id_Producto1 = " + product_id;
                    CONEXION.CONEXIONMAESTRA.abrir();
                    SqlCommand cmd = new SqlCommand(query, CONEXION.CONEXIONMAESTRA.conectar);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtProdDescripcion.Text = rdr["Descripcion"].ToString();
                        txtProdPrecio.Text = rdr["Precio_de_venta"].ToString();
                        stock_max = Convert.ToDecimal(rdr["Stock"].ToString());
                        usainventarios = rdr["usa_Inventarios"].ToString();
                        txtProdCantidad.Text = "1";
                        sevendePor = rdr["Se_vende_a"].ToString();
                        codProducto = rdr["Codigo"].ToString();
                        verificar_stock();
                    }
                    rdr.Close();
                    CONEXION.CONEXIONMAESTRA.cerrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void calcular_importe()
        {
            try
            {
                if (txtProdCantidad.Text != "")
                {
                    if (txtProdDescuento.Text != "")
                    {
                        txtProdDescuento.Text = "0";
                    }

                    txtProdImporte.Text = ((Convert.ToInt32(txtProdCantidad.Text) * Convert.ToDouble(txtProdPrecio.Text)) - Convert.ToDouble(txtProdDescuento.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Ingrese la cantidad a vender");
                }
            }
            catch
            {
                MessageBox.Show("Cantidad o descuento incorrectos");
            }
        }

        private void txtProdDescuento_TextChanged(object sender, EventArgs e)
        {
            if(txtProdDescuento.Text != "")
            {
                calcular_importe();
            }
        }

        private void txtProdCantidad_TextChanged(object sender, EventArgs e)
        {
            if(txtProdCantidad.Text != "")
            {
                verificar_stock();
            }
        }

        private void verificar_stock()
        {
            try
            {
                if (txtProdPrecio.Text != "")
                {
                    if (stock_max < Convert.ToDecimal(txtProdCantidad.Text))
                    {
                        MessageBox.Show("Stock Insuficiente");
                        txtProdCantidad.Text = stock_max.ToString();
                    }
                    calcular_importe();
                }
            }
            catch
            {
                MessageBox.Show("Cantidad incorrecta");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                txtProdImporte.Text = ((Convert.ToDouble(txtProdCantidad.Text) * Convert.ToDouble(txtProdPrecio.Text)) - Convert.ToDouble(txtProdDescuento.Text)).ToString();
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                da = new SqlDataAdapter("mostrar_stock_de_detalle_de_ventas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_producto", idproducto);
                da.Fill(dt);
                detalleVenta.DataSource = dt;
                con.Close();

                lblStock_de_Productos = Convert.ToDouble(stock_max);
                txtpantalla = Convert.ToDouble(txtProdCantidad.Text);

                ejecutar_insertar_ventas();
                if (txtventagenerada == "VENTA GENERADA")
                {
                    insertar_detalle_venta();
                    Listarproductosagregados();
                }

                txtProdDescripcion.Text = "";
                txtProdCantidad.Text = "0";
                txtProdDescuento.Text = "0";
                txtProdPrecio.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ejecutar_insertar_ventas()
        {
            if (txtventagenerada == "VENTA NUEVA")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_venta", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", idCliente);
                    cmd.Parameters.AddWithValue("@fecha_venta", DateTime.Today);
                    cmd.Parameters.AddWithValue("@nume_documento", 0);
                    cmd.Parameters.AddWithValue("@montototal", 0);
                    cmd.Parameters.AddWithValue("@Tipo_de_pago", cmbFormaPago.Text);
                    cmd.Parameters.AddWithValue("@estado", "EN ESPERA");
                    cmd.Parameters.AddWithValue("@IGV", 0);
                    cmd.Parameters.AddWithValue("@Comprobante", cmbComprobante.Text);
                    cmd.Parameters.AddWithValue("@id_usuario", idusuario_que_inicio_sesion);
                    cmd.Parameters.AddWithValue("@Fecha_de_pago", DateTime.Today);
                    cmd.Parameters.AddWithValue("@ACCION", "VENTA");
                    cmd.Parameters.AddWithValue("@Saldo", 0);
                    cmd.Parameters.AddWithValue("@Pago_con", 0);
                    cmd.Parameters.AddWithValue("@Porcentaje_IGV", 0);
                    cmd.Parameters.AddWithValue("@Id_caja", Id_caja);
                    cmd.Parameters.AddWithValue("@Referencia_tarjeta", 0);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Obtener_id_venta_recien_Creada();
                    txtventagenerada = "VENTA GENERADA";
                    //mostrar_panel_de_Cobro();
                }
                catch
                {
                    MessageBox.Show("insertar_venta");
                }

            }
        }

        private void eliminar_venta(int id_v)
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("eliminar_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", id_v);
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar_para_venta_nueva();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Obtener_id_venta_recien_Creada()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            SqlCommand com = new SqlCommand("mostrar_id_venta_por_Id_caja", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id_caja", Id_caja);
            try
            {
                con.Open();
                idVenta = Convert.ToInt32(com.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insertar_detalle_venta()
        {
            try
            {
                if (usainventarios == "SI")
                {
                    if (lblStock_de_Productos >= txtpantalla)
                    {
                        insertar_detalle_venta_Validado();
                    }
                }
                else if (usainventarios == "NO")
                {
                    insertar_detalle_venta_SIN_VALIDAR();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void insertar_detalle_venta_Validado()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtProdPrecio.Text);
                cmd.Parameters.AddWithValue("@moneda", 0);
                cmd.Parameters.AddWithValue("@unidades", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", txtProdDescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", codProducto);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Usa_inventarios", usainventarios);
                cmd.Parameters.AddWithValue("@Costo", txtProdImporte.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                disminuir_stock_en_detalle_de_venta(idproducto.ToString(), txtpantalla.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void insertar_detalle_venta_SIN_VALIDAR()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("insertar_detalle_venta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idventa", idVenta);
                cmd.Parameters.AddWithValue("@Id_presentacionfraccionada", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@preciounitario", txtProdPrecio);
                cmd.Parameters.AddWithValue("@moneda", 0);
                cmd.Parameters.AddWithValue("@unidades", "Unidad");
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Estado", "EN ESPERA");
                cmd.Parameters.AddWithValue("@Descripcion", txtProdDescripcion.Text);
                cmd.Parameters.AddWithValue("@Codigo", codProducto);
                cmd.Parameters.AddWithValue("@Stock", lblStock_de_Productos);
                cmd.Parameters.AddWithValue("@Se_vende_a", sevendePor);
                cmd.Parameters.AddWithValue("@Usa_inventarios", usainventarios);
                cmd.Parameters.AddWithValue("@Costo", txtProdImporte.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + ex.Message);
            }
        }

        private void disminuir_stock_en_detalle_de_venta(string idproducto, string txtpantalla)
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("disminuir_stock_en_detalle_de_venta", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validarLicencia()
        {
            DLicencias funcion = new DLicencias();
            funcion.ValidarLicencias(ref ResultadoLicencia, ref FechaFinal);
            if (ResultadoLicencia == "VENCIDA")
            {
                funcion.EditarMarcanVencidas();
                Dispose();
                LICENCIAS_MENBRESIAS.MembresiasNuevo frm = new LICENCIAS_MENBRESIAS.MembresiasNuevo();
                frm.ShowDialog();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            eliminar_venta(idVenta);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (detalleVenta.Rows.Count > 0)
            {
                LdetalleVenta parametros = new LdetalleVenta();
                Editar_datos funcion = new Editar_datos();
                parametros.Id_producto = Convert.ToInt32(detalleVenta.SelectedCells[8].Value.ToString());
                parametros.iddetalle_venta = Convert.ToInt32(detalleVenta.SelectedCells[9].Value.ToString());
                if (funcion.quitar_precio_mayoreo(parametros) == true)
                {
                    Listarproductosagregados();
                }
            }
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoPago = cmbFormaPago.Text;
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            Ventas_en_espera frm = new Ventas_en_espera();
            frm.FormClosing += Frm_FormClosing1;
            frm.ShowDialog();
            ContarVentasEspera();
        }

        private void Frm_FormClosing1(object sender, FormClosingEventArgs e)
        {
            Listarproductosagregados();
            try
            {
                if(detalleVenta.Rows.Count > 0)
                {
                    string query = "SELECT c.idclientev, c.Nombre, c.IdentificadorFiscal, v.Comprobante, v.Tipo_de_pago FROM ventas v " +
                                "INNER JOIN clientes c ON c.idclientev = v.idclientev " +
                                "WHERE v.idventa = " + idVenta;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion+ ";MultipleActiveResultSets=True";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        txtDocCliente.Text = rdr["IdentificadorFiscal"].ToString();
                        txtNomCliente.Text = rdr["Nombre"].ToString();
                        idCliente = rdr["idclientev"].ToString();
                        cmbComprobante.SelectedItem = (rdr["Comprobante"].ToString().Split(' '))[0];
                        actualizar_numero_comprobante();
                        cmbFormaPago.SelectedItem = rdr["Tipo_de_pago"].ToString();
                    }
                    rdr.Close();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //mostrar_panel_de_Cobro();
        }

        private void btnespera_Click(object sender, EventArgs e)
        {
            if (detalleVenta.RowCount > 0)
            {
                PanelEnespera.Visible = true;
                PanelEnespera.BringToFront();
                PanelEnespera.Dock = DockStyle.Fill;
                txtnombre.Clear();
            }
        }

        private void btnGuardarEspera_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtnombre.Text))
            {
                editarVentaEspera();
            }
            else
            {
                MessageBox.Show("Ingrese una referencia");
            }
        }

        private void editarVentaEspera()

        {
            Editar_datos.ingresar_nombre_a_venta_en_espera(idVenta, txtnombre.Text);
            Limpiar_para_venta_nueva();
            ocularPanelenEspera();
        }

        private void ocularPanelenEspera()
        {
            PanelEnespera.Visible = false;
            PanelEnespera.Dock = DockStyle.None;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ocularPanelenEspera();
        }

        private void btnAutomaticoEspera_Click(object sender, EventArgs e)
        {
            txtnombre.Text = cmbComprobante.Text + " " + idVenta;
            editarVentaEspera();
        }

        private void detalleVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iddetalleventa = Convert.ToInt32(detalleVenta.SelectedCells[9].Value.ToString());
                int idproducto = Convert.ToInt32(detalleVenta.SelectedCells[8].Value.ToString());
                string sevendePor = detalleVenta.SelectedCells[17].Value.ToString();
                string usainventarios = detalleVenta.SelectedCells[16].Value.ToString();
                double cantidad = Convert.ToDouble(detalleVenta.SelectedCells[5].Value);
                double txtpantalla;

                if (e.ColumnIndex == this.detalleVenta.Columns["S"].Index)
                {
                    txtpantalla = 1;
                    editar_detalle_venta_sumar(idproducto.ToString(), txtpantalla.ToString(), usainventarios);
                }
                if (e.ColumnIndex == this.detalleVenta.Columns["R"].Index)
                {
                    txtpantalla = 1;
                    editar_detalle_venta_restar(iddetalleventa.ToString(), txtpantalla.ToString(), idproducto.ToString());
                    EliminarVentas();
                }

                if (e.ColumnIndex == this.detalleVenta.Columns["EL"].Index)
                {
                    int iddetalle_venta = Convert.ToInt32(detalleVenta.SelectedCells[9].Value);
                    try
                    {
                        SqlCommand cmd;
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                        con.Open();
                        cmd = new SqlCommand("eliminar_detalle_venta", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iddetalleventa", iddetalle_venta);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        txtpantalla = Convert.ToDouble(detalleVenta.SelectedCells[5].Value);
                        aumentar_stock_en_detalle_de_venta(idproducto.ToString(), txtpantalla.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Listarproductosagregados();
                    EliminarVentas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editar_detalle_venta_sumar(string idproducto, string txtpantalla, string usainventarios)
        {
            if (usainventarios == "SI")
            {
                double lblStock_de_Productos = Convert.ToDouble(detalleVenta.SelectedCells[15].Value.ToString());
                if (lblStock_de_Productos > 0)
                {
                    ejecutar_editar_detalle_venta_sumar(idproducto, txtpantalla);
                    disminuir_stock_en_detalle_de_venta(idproducto, txtpantalla);
                }
                else
                {
                    MessageBox.Show("No hay stock");
                }
            }
            else
            {
                ejecutar_editar_detalle_venta_sumar(idproducto, txtpantalla);
            }
            Listarproductosagregados();
        }

        private void ejecutar_editar_detalle_venta_sumar(string idproducto, string txtpantalla)
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_sumar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editar_detalle_venta_restar(string iddetalleventa, string txtpantalla, string idproducto)
        {
            if (usainventarios == "SI")
            {
                ejecutar_editar_detalle_venta_restar(iddetalleventa, txtpantalla, idproducto);
                aumentar_stock_en_detalle_de_venta(idproducto, txtpantalla);
            }
            else
            {
                ejecutar_editar_detalle_venta_restar(iddetalleventa, txtpantalla, idproducto);
            }
            Listarproductosagregados();
        }

        private void ejecutar_editar_detalle_venta_restar(string iddetalleventa, string txtpantalla, string idproducto)
        {
            try
            {
                SqlCommand cmd;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();
                cmd = new SqlCommand("editar_detalle_venta_restar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iddetalle_venta", iddetalleventa);
                cmd.Parameters.AddWithValue("cantidad", txtpantalla);
                cmd.Parameters.AddWithValue("@Cantidad_mostrada", txtpantalla);
                cmd.Parameters.AddWithValue("@Id_producto", idproducto);
                cmd.Parameters.AddWithValue("@Id_venta", idVenta);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aumentar_stock_en_detalle_de_venta(string idproducto, string txtpantalla)
        {
            try
            {
                CONEXION.CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("aumentar_stock_en_detalle_de_venta", CONEXION.CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Producto1", idproducto);
                cmd.Parameters.AddWithValue("@cantidad", txtpantalla);
                cmd.ExecuteNonQuery();
                CONEXION.CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EliminarVentas()
        {
            int Contador = detalleVenta.Rows.Count;
            if (Contador == 0)
            {
                eliminar_venta(idVenta);
                Limpiar_para_venta_nueva();
            }
        }

        private void IndicadorTema_CheckedChanged(object sender, EventArgs e)
        {
            if (IndicadorTema.Checked == true)
            {
                Tema = "Oscuro";
                EditarTemaCaja();
                TemaOscuro();
                Listarproductosagregados();
            }
            else
            {
                Tema = "Redentor";
                EditarTemaCaja();
                TemaClaro();
                Listarproductosagregados();
            }
        }

        private void EditarTemaCaja()
        {
            Lcaja parametros = new Lcaja();
            Editar_datos funcion = new Editar_datos();
            parametros.Tema = Tema;
            funcion.EditarTemaCaja(parametros);
        }
    }
}
