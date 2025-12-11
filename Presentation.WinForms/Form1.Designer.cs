namespace Presentation.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelClients = new Panel();
            btnNewClient = new Button();
            dataGridClients = new DataGridView();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            HomeMenuItem = new ToolStripMenuItem();
            InvoicesMenuItem = new ToolStripMenuItem();
            ClientsMenuItem = new ToolStripMenuItem();
            ProductsMenuItem = new ToolStripMenuItem();
            panelHome = new Panel();
            dataGridInvoiceLine = new DataGridView();
            comboBoxClient = new ComboBox();
            panelInvoice = new Panel();
            panelProducts = new Panel();
            dataGridProducts = new DataGridView();
            btnNewProduct = new Button();
            panelClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClients).BeginInit();
            menuStrip1.SuspendLayout();
            panelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceLine).BeginInit();
            panelProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            SuspendLayout();
            // 
            // panelClients
            // 
            panelClients.Controls.Add(btnNewClient);
            panelClients.Controls.Add(dataGridClients);
            panelClients.Location = new Point(6, 27);
            panelClients.Name = "panelClients";
            panelClients.Size = new Size(585, 536);
            panelClients.TabIndex = 0;
            panelClients.Visible = false;
            // 
            // btnNewClient
            // 
            btnNewClient.Location = new Point(485, 50);
            btnNewClient.Name = "btnNewClient";
            btnNewClient.Size = new Size(75, 23);
            btnNewClient.TabIndex = 1;
            btnNewClient.Text = "Nuevo Cliente";
            btnNewClient.UseVisualStyleBackColor = true;
            btnNewClient.Click += btnNewClient_Click;
            // 
            // dataGridClients
            // 
            dataGridClients.AllowUserToAddRows = false;
            dataGridClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClients.Location = new Point(17, 79);
            dataGridClients.Name = "dataGridClients";
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.Size = new Size(543, 436);
            dataGridClients.TabIndex = 0;
            dataGridClients.CellClick += dataGridClients_CellClick;
            dataGridClients.CellValueChanged += dataGridClients_CellValueChanged;
            dataGridClients.UserAddedRow += dataGridClients_UserAddedRow;
            dataGridClients.UserDeletingRow += dataGridClients_UserDeletingRow;
            // 
            // button1
            // 
            button1.Location = new Point(478, 25);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(76, 20);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(28, 28);
            menuStrip1.Items.AddRange(new ToolStripItem[] { HomeMenuItem, InvoicesMenuItem, ClientsMenuItem, ProductsMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(601, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // HomeMenuItem
            // 
            HomeMenuItem.Name = "HomeMenuItem";
            HomeMenuItem.Size = new Size(48, 22);
            HomeMenuItem.Text = "Inicio";
            HomeMenuItem.Click += HomeMenuItem_Click;
            // 
            // InvoicesMenuItem
            // 
            InvoicesMenuItem.Name = "InvoicesMenuItem";
            InvoicesMenuItem.Size = new Size(63, 22);
            InvoicesMenuItem.Text = "Facturas";
            InvoicesMenuItem.Click += InvoicesMenuItem_Click;
            // 
            // ClientsMenuItem
            // 
            ClientsMenuItem.Name = "ClientsMenuItem";
            ClientsMenuItem.Size = new Size(61, 22);
            ClientsMenuItem.Text = "Clientes";
            ClientsMenuItem.Click += ClientsMenuItem_Click;
            // 
            // ProductsMenuItem
            // 
            ProductsMenuItem.Name = "ProductsMenuItem";
            ProductsMenuItem.Size = new Size(73, 22);
            ProductsMenuItem.Text = "Productos";
            ProductsMenuItem.Click += ProductsMenuItem_Click;
            // 
            // panelHome
            // 
            panelHome.Controls.Add(dataGridInvoiceLine);
            panelHome.Controls.Add(comboBoxClient);
            panelHome.Controls.Add(button1);
            panelHome.Location = new Point(12, 27);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(572, 536);
            panelHome.TabIndex = 2;
            // 
            // dataGridInvoiceLine
            // 
            dataGridInvoiceLine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridInvoiceLine.Location = new Point(21, 99);
            dataGridInvoiceLine.Name = "dataGridInvoiceLine";
            dataGridInvoiceLine.Size = new Size(533, 150);
            dataGridInvoiceLine.TabIndex = 2;
            dataGridInvoiceLine.DataError += dataGridInvoiceLine_DataError;
            // 
            // comboBoxClient
            // 
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(21, 28);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(121, 23);
            comboBoxClient.TabIndex = 1;
            // 
            // panelInvoice
            // 
            panelInvoice.Location = new Point(6, 27);
            panelInvoice.Name = "panelInvoice";
            panelInvoice.Size = new Size(585, 536);
            panelInvoice.TabIndex = 1;
            panelInvoice.Visible = false;
            // 
            // panelProducts
            // 
            panelProducts.Controls.Add(dataGridProducts);
            panelProducts.Controls.Add(btnNewProduct);
            panelProducts.Location = new Point(12, 27);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(572, 536);
            panelProducts.TabIndex = 0;
            panelProducts.Visible = false;
            // 
            // dataGridProducts
            // 
            dataGridProducts.AllowUserToAddRows = false;
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(13, 79);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProducts.Size = new Size(543, 436);
            dataGridProducts.TabIndex = 2;
            dataGridProducts.CellValueChanged += dataGridProducts_CellValueChanged;
            dataGridProducts.UserAddedRow += dataGridProducts_UserAddedRow;
            dataGridProducts.UserDeletingRow += dataGridProducts_UserDeletingRow;
            // 
            // btnNewProduct
            // 
            btnNewProduct.Location = new Point(453, 35);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(75, 23);
            btnNewProduct.TabIndex = 1;
            btnNewProduct.Text = "Nuevo";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Click += btnNewProduct_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(601, 592);
            Controls.Add(panelHome);
            Controls.Add(panelClients);
            Controls.Add(panelProducts);
            Controls.Add(panelInvoice);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "Form1";
            Text = "FactuNET";
            Load += Form1_Load;
            panelClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridClients).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceLine).EndInit();
            panelProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ClientsMenuItem;
        private ToolStripMenuItem ProductsMenuItem;
        private ToolStripMenuItem HomeMenuItem;
        private ToolStripMenuItem InvoicesMenuItem;
        private Panel panelHome;
        private Panel panelInvoice;
        private Panel panelClients;
        private Panel panelProducts;
        private Button btnNewClient;
        private Button btnNewProduct;
        private DataGridView dataGridClients;
        private DataGridView dataGridProducts;
        private ComboBox comboBoxClient;
        private DataGridView dataGridInvoiceLine;
    }
}
