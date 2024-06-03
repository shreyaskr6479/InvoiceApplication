using InvoiceApplication.Container;
using InvoiceApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceItemContainer _invoiceItemContainer;

        public InvoiceController(IInvoiceItemContainer invoiceItemContainer)
        {
            this._invoiceItemContainer = invoiceItemContainer;
        }

        // GET: api/Invoice/5/generate
        [HttpGet("{customerId}/generate")]
        public async Task<ActionResult<InvoiceDto>> GenerateInvoice(int customerId, string paymentOption)
        {
            try
            {
                var customer = await _invoiceItemContainer.GetCustomerByCustomerId(customerId);

                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                var invoiceItems = await _invoiceItemContainer.GetCartItemsForCustomer(customerId);

                if (invoiceItems == null || !invoiceItems.Any())
                {
                    return BadRequest("Cart is empty");
                }

                var invoice = await _invoiceItemContainer.GetInvoice(customer, invoiceItems, paymentOption);

                if (invoice == null)
                {
                    BadRequest("Invoice not available");
                }

                return Ok(invoice);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}