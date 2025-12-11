using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BusinessLogicLayer;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.ApplicationServices;

namespace Presentation.WinForms
{
    public partial class Form1 : Form
    {
        private BindingList<Client> _clients = [];
        private BindingList<Product> _products = [];
        private BindingList<InvoiceLine> _inLines = [];

        private readonly ClientService _clientManager;
        private readonly ProductService _productManager;
        public Form1()
        {
            InitializeComponent();

            panelProducts.Visible = true;
            _clientManager = new ClientService();
            _productManager = new ProductService();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            productos();
        }

        public void productos()
        {
            //var _productManager = new ProductService();
            //var _clientManager = new ClientService();
            //var invoiceManager = new InvoiceService();

            //var client1 = _clientManager.CreateClient("Eddy", "e.leonardo@hola.com", "40223", "Calle Privada #97");
            //var client2 = _clientManager.CreateClient("Jhon", "jjAvion@google.com", "04811", "Ave. Roberto Paztoriza #301");

            //var product1 = _productManager.CreateProduct("Bocina JBL Clip 6", 39.99m, 10);
            //var product2 = _productManager.CreateProduct("Calculadora Grafica TI", 150.00m, 5);

            //var li =  _clientManager.GetAllClients();

            //var lista = _productManager.GetAllProducts();

            //var upProduct = lista.Last();
            //upProduct.Name = "Iphone XL";
            //_productManager.UpdateProduct(upProduct);

            //_productManager.DeleteProduct(lista.First().Id);

            //var nuevalista =  _productManager.GetAllProducts();

            //List<(Product, int)> productsToBuy = [(product1, 1), (product2, 2)];

            //var newInvoice = invoiceManager.CreateInvoice(client1, productsToBuy, 0.13m);

            //var searchresult = invoiceManager.GetInvoice(newInvoice.Id);

            //newInvoice.InvoiceLines.Remove(newInvoice.InvoiceLines.First());

            //var nuevalistass = _productManager.GetAllProducts();

            //invoiceManager.UpdateInvoice(newInvoice);

            //Console.WriteLine("fin");


            //var invoicesAfter =  invoiceManager.GetAllInvoices();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

            var clients = _clientManager.GetAllClients();

            // Bind to ComboBox
            comboBoxClient.DataSource = clients;
            comboBoxClient.DisplayMember = "Name";   // property to show
            comboBoxClient.ValueMember = "Id";       // property to use internally

            // Enable autocomplete
            comboBoxClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClient.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ShowPanel(Panel pnl)
        {
            //// Hide all
            panelHome.Visible = false;
            panelInvoice.Visible = false;
            panelClients.Visible = false;
            panelProducts.Visible = false;

            //// Show selected
            pnl.Visible = true;
        }

        private void HandleCellValueChanged<T>(
       DataGridView grid,
       DataGridViewCellEventArgs e,
       Action<T> updateAction)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = grid.Columns[e.ColumnIndex].Name;

            if (columnName is "CreatedAt" or "Id")
                return;

            // Get the bound item
            var row = grid.Rows[e.RowIndex];
            if (row.DataBoundItem is not T entity)
                return;

            updateAction(entity);
        }

        private void HomeMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(panelHome);
            //dataGridInvoiceLine.DataSource = _inLines;

            // Assuming _productManager.GetAll() returns List<Product>
            //var products = _productManager.GetAllProducts();

            //// Create ComboBox column
            //var productColumn = new DataGridViewComboBoxColumn
            //{
            //    DataPropertyName = "ProductId",   // binds to InvoiceLine.ProductId
            //    HeaderText = "Product",
            //    DataSource = products,
            //    DisplayMember = "Name",           // property to show in dropdown
            //    ValueMember = "Id",               // property to bind to ProductId
            //    AutoComplete = true
            //};

            /////////////////////////////////

            //var qtyColumn = new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "Quantity",
            //    HeaderText = "Qty"
            //};

            //var priceColumn = new DataGridViewTextBoxColumn
            //{
            //    DataPropertyName = "SalePrice",
            //    HeaderText = "Price"
            //};

            //var totalColumn = new DataGridViewTextBoxColumn
            //{
            //    HeaderText = "Line Total",
            //    ReadOnly = true
            //};

            //////////////////////

            //dataGridInvoiceLine.AutoGenerateColumns = false;
            //dataGridInvoiceLine.Columns.Clear();

            //dataGridInvoiceLine.Columns.Add(productColumn);
            //dataGridInvoiceLine.Columns.Add(qtyColumn);
            //dataGridInvoiceLine.Columns.Add(priceColumn);
            //dataGridInvoiceLine.Columns.Add(totalColumn);

            //// Bind to your list of invoice lines
            //dataGridInvoiceLine.DataSource = _inLines;





        }
        private void InvoicesMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(panelInvoice);
        }
        private void ClientsMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(panelClients);
            var clients = _clientManager.GetAllClients();


            _clients = new BindingList<Client>(clients.ToList());
            dataGridClients.DataSource = _clients;


        }
        private void ProductsMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanel(panelProducts);
            var products = _productManager.GetAllProducts();


            _products = new BindingList<Product>(products.ToList());
            dataGridProducts.DataSource = _products;
            dataGridProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }





        private void dataGridClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            HandleCellValueChanged<Client>(dataGridClients, e, _clientManager.UpdateClient);
        }
        private void dataGridProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellValueChanged<Product>(dataGridProducts, e, _productManager.UpdateProduct);
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            dataGridClients.AllowUserToAddRows = true;
        }
        private void btnNewProduct_Click(object sender, EventArgs e)
        {

            dataGridProducts.AllowUserToAddRows = true;
        }


        private void dataGridClients_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure??????", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Get the currently selected row
                if (dataGridClients.CurrentRow != null)
                {
                    // Grab the bound Client object
                    var client = dataGridClients.CurrentRow.DataBoundItem as Client;
                    if (client != null)
                    {
                        // Call your service to delete from DB
                        //var _clientManager = new ClientService();
                        _clientManager.DeleteClient(client.Id);

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void dataGridProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure??????", "Some Title", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                // Get the currently selected row
                if (dataGridProducts.CurrentRow != null)
                {
                    // Grab the bound Client object
                    var product = dataGridProducts.CurrentRow.DataBoundItem as Product;
                    if (product != null)
                    {
                        // Call your service to delete from DB
                        //var _clientManager = new ClientService();
                        _productManager.DeleteProduct(product.Id);

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void dataGridClients_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridClients.AllowUserToAddRows = false;
        }
        private void dataGridProducts_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridProducts.AllowUserToAddRows = false;
        }

        private void dataGridClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridClients = dataGridClients.Rows[e.RowIndex];
        }

        private void dataGridInvoiceLine_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false; // prevents crash
            MessageBox.Show("Invalid product selection. Check ProductId vs Product list.");
        }
    }
}
