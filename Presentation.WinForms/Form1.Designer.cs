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
            btnNewClient = new Button();
            dataGridClients = new DataGridView();
            btnCreateInvoice = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            labelTotal = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            labelTax = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelSubtotal = new Label();
            dataGridInvoiceLine = new DataGridView();
            comboBoxClient = new ComboBox();
            dataGridProducts = new DataGridView();
            btnNewProduct = new Button();
            tabContainer = new TabControl();
            tabHome = new TabPage();
            tabInvoices = new TabPage();
            dataGridInvoices = new DataGridView();
            tabClients = new TabPage();
            tabProducts = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridClients).BeginInit();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceLine).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            tabContainer.SuspendLayout();
            tabHome.SuspendLayout();
            tabInvoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInvoices).BeginInit();
            tabClients.SuspendLayout();
            tabProducts.SuspendLayout();
            SuspendLayout();
            // 
            // btnNewClient
            // 
            btnNewClient.Location = new Point(472, 22);
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
            dataGridClients.Location = new Point(4, 51);
            dataGridClients.Name = "dataGridClients";
            dataGridClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClients.Size = new Size(543, 436);
            dataGridClients.TabIndex = 0;
            dataGridClients.CellClick += dataGridClients_CellClick;
            dataGridClients.CellValueChanged += dataGridClients_CellValueChanged;
            dataGridClients.UserAddedRow += dataGridClients_UserAddedRow;
            dataGridClients.UserDeletingRow += dataGridClients_UserDeletingRow;
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.Location = new Point(463, 23);
            btnCreateInvoice.Margin = new Padding(2);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(76, 20);
            btnCreateInvoice.TabIndex = 0;
            btnCreateInvoice.Text = "Facturar";
            btnCreateInvoice.UseVisualStyleBackColor = true;
            btnCreateInvoice.Click += button1_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Right;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(labelTotal);
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(194, 328);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(345, 27);
            flowLayoutPanel3.TabIndex = 5;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTotal.Location = new Point(198, 0);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(144, 21);
            labelTotal.TabIndex = 0;
            labelTotal.Text = "Total a pagar: $0.00";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Right;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(labelTax);
            flowLayoutPanel2.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new Point(194, 295);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(345, 27);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // labelTax
            // 
            labelTax.AutoSize = true;
            labelTax.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTax.Location = new Point(252, 0);
            labelTax.Name = "labelTax";
            labelTax.Size = new Size(90, 21);
            labelTax.TabIndex = 0;
            labelTax.Text = "ITBIS: $0.00";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Right;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(labelSubtotal);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(194, 262);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(345, 27);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // labelSubtotal
            // 
            labelSubtotal.AutoSize = true;
            labelSubtotal.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSubtotal.Location = new Point(228, 0);
            labelSubtotal.Name = "labelSubtotal";
            labelSubtotal.Size = new Size(114, 21);
            labelSubtotal.TabIndex = 0;
            labelSubtotal.Text = "Subtotal: $0.00";
            // 
            // dataGridInvoiceLine
            // 
            dataGridInvoiceLine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridInvoiceLine.Location = new Point(6, 97);
            dataGridInvoiceLine.Name = "dataGridInvoiceLine";
            dataGridInvoiceLine.Size = new Size(533, 150);
            dataGridInvoiceLine.TabIndex = 2;
            dataGridInvoiceLine.CellEndEdit += dataGridInvoiceLine_CellEndEdit;
            dataGridInvoiceLine.CellValueChanged += dataGridInvoiceLine_CellValueChanged;
            dataGridInvoiceLine.CurrentCellDirtyStateChanged += dataGridInvoiceLine_CurrentCellDirtyStateChanged;
            dataGridInvoiceLine.DataError += dataGridInvoiceLine_DataError;
            // 
            // comboBoxClient
            // 
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(6, 26);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(121, 23);
            comboBoxClient.TabIndex = 1;
            // 
            // dataGridProducts
            // 
            dataGridProducts.AllowUserToAddRows = false;
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(3, 54);
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
            btnNewProduct.Location = new Point(443, 10);
            btnNewProduct.Name = "btnNewProduct";
            btnNewProduct.Size = new Size(75, 23);
            btnNewProduct.TabIndex = 1;
            btnNewProduct.Text = "Nuevo";
            btnNewProduct.UseVisualStyleBackColor = true;
            btnNewProduct.Click += btnNewProduct_Click;
            // 
            // tabContainer
            // 
            tabContainer.Controls.Add(tabHome);
            tabContainer.Controls.Add(tabInvoices);
            tabContainer.Controls.Add(tabClients);
            tabContainer.Controls.Add(tabProducts);
            tabContainer.Location = new Point(0, 0);
            tabContainer.Name = "tabContainer";
            tabContainer.SelectedIndex = 0;
            tabContainer.Size = new Size(561, 521);
            tabContainer.TabIndex = 3;
            tabContainer.SelectedIndexChanged += tabContainer_SelectedIndexChanged;
            // 
            // tabHome
            // 
            tabHome.Controls.Add(flowLayoutPanel3);
            tabHome.Controls.Add(comboBoxClient);
            tabHome.Controls.Add(flowLayoutPanel2);
            tabHome.Controls.Add(btnCreateInvoice);
            tabHome.Controls.Add(flowLayoutPanel1);
            tabHome.Controls.Add(dataGridInvoiceLine);
            tabHome.Location = new Point(4, 24);
            tabHome.Name = "tabHome";
            tabHome.Padding = new Padding(3);
            tabHome.Size = new Size(553, 493);
            tabHome.TabIndex = 0;
            tabHome.Text = "Inicio";
            tabHome.UseVisualStyleBackColor = true;
            // 
            // tabInvoices
            // 
            tabInvoices.Controls.Add(dataGridInvoices);
            tabInvoices.Location = new Point(4, 24);
            tabInvoices.Name = "tabInvoices";
            tabInvoices.Padding = new Padding(3);
            tabInvoices.Size = new Size(553, 493);
            tabInvoices.TabIndex = 1;
            tabInvoices.Text = "Facturas";
            tabInvoices.UseVisualStyleBackColor = true;
            // 
            // dataGridInvoices
            // 
            dataGridInvoices.AllowUserToAddRows = false;
            dataGridInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridInvoices.Location = new Point(7, 37);
            dataGridInvoices.Name = "dataGridInvoices";
            dataGridInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridInvoices.Size = new Size(543, 436);
            dataGridInvoices.TabIndex = 3;
            // 
            // tabClients
            // 
            tabClients.Controls.Add(btnNewClient);
            tabClients.Controls.Add(dataGridClients);
            tabClients.Location = new Point(4, 24);
            tabClients.Name = "tabClients";
            tabClients.Padding = new Padding(3);
            tabClients.Size = new Size(553, 493);
            tabClients.TabIndex = 2;
            tabClients.Text = "Clientes";
            tabClients.UseVisualStyleBackColor = true;
            // 
            // tabProducts
            // 
            tabProducts.Controls.Add(dataGridProducts);
            tabProducts.Controls.Add(btnNewProduct);
            tabProducts.Location = new Point(4, 24);
            tabProducts.Name = "tabProducts";
            tabProducts.Padding = new Padding(3);
            tabProducts.Size = new Size(553, 493);
            tabProducts.TabIndex = 3;
            tabProducts.Text = "Productos";
            tabProducts.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 519);
            Controls.Add(tabContainer);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "FactuNET";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridClients).EndInit();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridInvoiceLine).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            tabContainer.ResumeLayout(false);
            tabHome.ResumeLayout(false);
            tabInvoices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridInvoices).EndInit();
            tabClients.ResumeLayout(false);
            tabProducts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreateInvoice;
        private Button btnNewClient;
        private Button btnNewProduct;
        private DataGridView dataGridClients;
        private DataGridView dataGridProducts;
        private ComboBox comboBoxClient;
        private DataGridView dataGridInvoiceLine;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelSubtotal;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label labelTotal;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label labelTax;
        private TabControl tabContainer;
        private TabPage tabHome;
        private TabPage tabInvoices;
        private TabPage tabClients;
        private TabPage tabProducts;
        private DataGridView dataGridInvoices;
    }
}
