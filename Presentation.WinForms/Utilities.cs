using System.ComponentModel;
using System.Globalization;

namespace Presentation.WinForms
{
    public class Utilities
    {
        public static (decimal Subtotal, decimal Tax, decimal FinalTotal) CalculateInvoiceTotals(DataGridView dataGridInvoiceLine)
        {
            decimal subtotal = 0m;

            foreach (DataGridViewRow row in dataGridInvoiceLine.Rows)
            {
                if (row.IsNewRow) continue; // skip placeholder row

                var qty = Convert.ToInt32(row.Cells["Qty"].Value);
                var price = Convert.ToDecimal(row.Cells["Price"].Value);

                subtotal += qty * price;
            }

            decimal tax = subtotal * 0.13m;
            decimal finalTotal = subtotal + tax;

            return (subtotal, tax, finalTotal);
        }

        public static void UpdateInvoiceLabels((decimal Subtotal, decimal Tax, decimal FinalTotal) totals,
                                 Label labelSubtotal,
                                 Label labelTax,
                                 Label labelTotal)
        {
            var culture = CultureInfo.GetCultureInfo("en-US");

            labelSubtotal.Text = $"Subtotal: {totals.Subtotal.ToString("C2", culture)}";
            labelTax.Text = $"ITBIS: {totals.Tax.ToString("C2", culture)}";
            labelTotal.Text = $"Total: {totals.FinalTotal.ToString("C2", culture)}";
        }

        public static void RecalculateRow(DataGridViewRow row)
        {
            if (row.IsNewRow) return;

            decimal qty = 0;
            decimal price = 0;

            decimal.TryParse(Convert.ToString(row.Cells["Qty"].Value), out qty);
            decimal.TryParse(Convert.ToString(row.Cells["Price"].Value), out price);

            row.Cells["LineTotal"].Value = qty * price;
        }


        public static void HandleCellValueChanged<T>(
           DataGridView grid,
           DataGridViewCellEventArgs e,
           Action<T> updateAction)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName = grid.Columns[e.ColumnIndex].Name;

            if (columnName is "CreatedAt" or "Id")
                return;

           
            var row = grid.Rows[e.RowIndex];
            if (row.DataBoundItem is not T entity)
                return;

            updateAction(entity);
        }


        public static void BindDataToGrid<T>(
                               DataGridView grid,
                               IEnumerable<T> data,
                               bool autoSizeFirstColumn = false)
        {

            var bindingList = new BindingList<T>(data.ToList());
            grid.DataSource = bindingList;

            if (autoSizeFirstColumn && grid.Columns.Count > 0)
            {
                grid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        public static void HandleRowDeleting<T>(DataGridView grid,
                                  DataGridViewRowCancelEventArgs e,
                                  Action<T> deleteAction)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure??????",
                                                        "Confirm Delete",
                                                        MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.DataBoundItem is T entity)
                    {
                        deleteAction(entity);
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }



    }
}
