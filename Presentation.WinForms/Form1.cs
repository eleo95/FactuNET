using System.ComponentModel;
using System.Globalization;
using BusinessLogicLayer;
using EntityLayer.Entities;

namespace Presentation.WinForms
{
    public partial class Form1 : Form
    {
        private BindingList<Client> _clients = new BindingList<Client>();
        private BindingList<Product> _products = new BindingList<Product>();
        private BindingList<InvoiceLine> _inLines;

        private readonly ClientService _clientManager;
        private readonly ProductService _productManager;
        private readonly InvoiceService _invoiceManager;
        public Form1()
        {
            InitializeComponent();

            _clientManager = new ClientService();
            _productManager = new ProductService();
            _invoiceManager = new InvoiceService();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveInvoice();
        }

        private void ValidateGenerateInvoiceButton()
        {
            bool clientSelected = comboBoxClient.SelectedValue != null
                                  && (int)comboBoxClient.SelectedValue > 0;

            bool hasLines = dataGridInvoiceLine.Rows
                .Cast<DataGridViewRow>()
                .Any(r => !r.IsNewRow
                          && r.Cells["Product"].Value != null
                          && r.Cells["Price"].Value != null);

            btnCreateInvoice.Enabled = clientSelected && hasLines;
        }


        public void saveInvoice()
        {

            if ((int)comboBoxClient.SelectedValue! > 0)
            {
                var thisClient = _clientManager.GetClient((int)comboBoxClient.SelectedValue);
                var productlines = dataGridInvoiceLine.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && r.Cells["Product"].Value != null)
                    .Select(r =>
                    {
                        // Resolve product from the selected Id
                        var productId = Convert.ToInt32(r.Cells["Product"].Value);
                        var product = _productManager.GetProduct(productId);

                        var qty = r.Cells["Qty"].Value != null ? Convert.ToInt32(r.Cells["Qty"].Value) : 0;

                        return (product!, qty);
                    })
                    .ToList();

                MessageBox.Show("Factura Creada con exito");
                var newInvoice = _invoiceManager.CreateInvoice(thisClient, productlines, 0.13m);
                Console.WriteLine(newInvoice);
            }


        }



        private void Form1_Load(object sender, EventArgs e)
        {
            btnCreateInvoice.Enabled = false;


            var clients = _clientManager.GetAllClients().Select(c => new { c.Id, c.Name }).ToList();
            clients.Insert(0, new { Id = 0, Name = "Selecione el cliente" });

            // Bind to ComboBox
            comboBoxClient.DataSource = clients;
            comboBoxClient.DisplayMember = "Name";   // property to show
            comboBoxClient.ValueMember = "Id";       // property to use internally

            // Enable autocomplete
            comboBoxClient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxClient.AutoCompleteSource = AutoCompleteSource.ListItems;

            dataGridInvoiceLine.DataSource = _inLines;

            SetupInvoiceGrid();

            comboBoxClient.SelectedValueChanged += ComboBoxClient_SelectedValueChanged;


        }

        private void ComboBoxClient_SelectedValueChanged(object? sender, EventArgs e)
        {
            ValidateGenerateInvoiceButton();
        }

        private void dataGridClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            Utilities.HandleCellValueChanged<Client>(dataGridClients, e, _clientManager.UpdateClient);
        }
        private void dataGridProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Utilities.HandleCellValueChanged<Product>(dataGridProducts, e, _productManager.UpdateProduct);
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
            Utilities.HandleRowDeleting<Client>(dataGridClients, e, client => _clientManager.DeleteClient(client.Id));
        }
        private void dataGridProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Utilities.HandleRowDeleting<Product>(dataGridProducts, e, product => _productManager.DeleteProduct(product.Id));
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
            e.ThrowException = false;
            MessageBox.Show("Invalid product selection. Check ProductId vs Product list.");
        }



        private void dataGridInvoiceLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridInvoiceLine_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridInvoiceLine.IsCurrentCellDirty)
            {
                dataGridInvoiceLine.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridInvoiceLine_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var totals = Utilities.CalculateInvoiceTotals(dataGridInvoiceLine);
            Utilities.UpdateInvoiceLabels(totals, labelSubtotal, labelTax, labelTotal);

            if (e.RowIndex < 0) return;

            var colName = dataGridInvoiceLine.Columns[e.ColumnIndex].Name;

            if (colName == "Product")
            {
                var row = dataGridInvoiceLine.Rows[e.RowIndex];
                if (row.Cells["Product"].Value != null)
                {
                    var productId = Convert.ToInt32(row.Cells["Product"].Value);

                    
                    var product = _productManager.GetProduct(productId);
                    if (product != null)
                    {
                        row.Cells["Price"].Value = product.Price;

                        
                        if (row.Cells["Qty"].Value == null)
                            row.Cells["Qty"].Value = 1;

                       
                        var qty = Convert.ToInt32(row.Cells["Qty"].Value);
                        var price = Convert.ToDecimal(row.Cells["Price"].Value);
                        row.Cells["LineTotal"].Value = qty * price;
                    }
                }
            }
            else if (colName == "Qty" || colName == "Price")
            {
                var row = dataGridInvoiceLine.Rows[e.RowIndex];
                if (row.Cells["Qty"].Value != null && row.Cells["Price"].Value != null)
                {
                    var qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    var price = Convert.ToDecimal(row.Cells["Price"].Value);
                    row.Cells["LineTotal"].Value = qty * price;
                }
            }
            ValidateGenerateInvoiceButton();

        }

        private void tabContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabContainer.SelectedTab;

            if (selectedTab == tabHome)
            {
                dataGridInvoiceLine.DataSource = _inLines;


            }
            else if (selectedTab == tabClients)
            {
                var clients = _clientManager.GetAllClients();
                _clients = new BindingList<Client>(clients.ToList());
                dataGridClients.DataSource = _clients;
            }
            else if (selectedTab == tabProducts)
            {
                var products = _productManager.GetAllProducts();
                _products = new BindingList<Product>(products.ToList());
                dataGridProducts.DataSource = _products;
                dataGridProducts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (selectedTab == tabInvoices)
            {
                var invoices = _invoiceManager.GetAllInvoices();

                dataGridInvoices.DataSource = invoices.Select(i => new
                {
                    InvoiceId = i.Id,
                    ClientName = i.Client!.Name,
                    LineCount = i.InvoiceLines.Count,
                    Total = i.Total,
                    Date = i.CreatedAt.ToString("d", new CultureInfo("es-DO"))
                })
                     .ToList();
            }
        }

        private void SetupInvoiceGrid()
        {
            dataGridInvoiceLine.Columns.Clear();
            dataGridInvoiceLine.AutoGenerateColumns = false;
            dataGridInvoiceLine.AllowUserToAddRows = true;


            var products = _productManager.GetAllProducts().ToList();
            products.Insert(0, new Product { Id = 0, Name = "Select product" });


            var colProduct = new DataGridViewComboBoxColumn
            {
                Name = "Product",
                HeaderText = "Product",
                DataSource = products,
                DisplayMember = "Name",
                ValueMember = "Id",
                FlatStyle = FlatStyle.Flat
            };

            var colQty = new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Qty", DataPropertyName = "Quantity" };
            var colPrice = new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Unit Price", DataPropertyName = "Price" };
            var colTotal = new DataGridViewTextBoxColumn { Name = "LineTotal", HeaderText = "Total", ReadOnly = true, DataPropertyName = "LineTotal" };

            dataGridInvoiceLine.Columns.AddRange(new DataGridViewColumn[] { colProduct, colQty, colPrice, colTotal });
            dataGridInvoiceLine.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridInvoiceLine.DefaultValuesNeeded += (s, e) =>
            {
                e.Row.Cells["Qty"].Value = 1;
                e.Row.Cells["Price"].Value = 0m;
            };
        }
    }

}
