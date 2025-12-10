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
            productos();
        }

        public void productos()
        {
            var productManager = new ProductService();
            var clientManager = new ClientService();
            var invoiceManager = new InvoiceService();

            var client1 = clientManager.CreateClient("Eddy", "e.leonardo@hola.com", "40223", "Calle Privada #97");
            var client2 = clientManager.CreateClient("Jhon", "jjAvion@google.com", "04811", "Ave. Roberto Paztoriza #301");

            var product1 = productManager.CreateProduct("Bocina JBL Clip 6", 39.99m, 10);
            var product2 = productManager.CreateProduct("Calculadora Grafica TI", 150.00m, 5);

            //var li = await clientManager.GetAllClients();

           var lista = productManager.GetAllProducts();

            //var upProduct = lista.Last();
            //upProduct.Name = "Iphone XL";
            //productManager.UpdateProduct(upProduct);

            // productManager.DeleteProduct(lista.First().Id);

            //var nuevalista =  productManager.GetAllProducts();

            List<(Product, int)> productsToBuy = [(product1, 1), (product2, 2)];

            var newInvoice = invoiceManager.CreateInvoice(client1, productsToBuy, 0.13m);

            var searchresult = invoiceManager.GetInvoice(newInvoice.Id);

            newInvoice.InvoiceLines.Remove(newInvoice.InvoiceLines.First());

            var nuevalista = productManager.GetAllProducts();

            invoiceManager.UpdateInvoice(newInvoice);

            Console.WriteLine("fin");


            //var invoicesAfter = await invoiceManager.GetAllInvoices();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
