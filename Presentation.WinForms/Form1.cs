using BusinessLogicLayer;
using EntityLayer.Entities;

namespace Presentation.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            productos().GetAwaiter().GetResult();
        }

        async Task<int> productos()
        {
            var productManager = new ProductService();
            var clientManager = new ClientService();
            var invoiceManager = new InvoiceService();

            var client1 = await clientManager.CreateClient("Eddy", "e.leonardo@hola.com", "40223", "Calle Privada #97");
            var client2 = await clientManager.CreateClient("Jhon", "jjAvion@google.com", "04811", "Ave. Roberto Paztoriza #301");

            var product1 = await productManager.CreateProduct("Lenovo Laptop", 599.99m, 10);
            var product2 = await productManager.CreateProduct("Google Pixel 8", 430.00m, 5);


            List<(Product,int)> productsToBuy = [( product1,1),( product2,1)];

            var newInvoice = await invoiceManager.CreateInvoice(client1,productsToBuy,0.13m);

            var searchresult = await invoiceManager.GetInvoice(newInvoice.Id);

            newInvoice.InvoiceLines.Remove(newInvoice.InvoiceLines.First());

            await invoiceManager.UpdateInvoice(newInvoice);


            var invoicesAfter = await invoiceManager.GetAllInvoices();

            return 0;

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
