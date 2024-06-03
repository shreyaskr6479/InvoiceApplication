using InvoiceApplication.Container;
using InvoiceApplication.DTOs;
using InvoiceApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemContainer _invoiceItemContainer;

        public InvoiceItemController(IInvoiceItemContainer invoiceItemContainer)
        {
            this._invoiceItemContainer = invoiceItemContainer;
        }

        // PUT: api/InvoiceItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemQuantity(int id, InvoiceItemDto invoiceItem)
        {
            try
            {
                if (id != invoiceItem.Id)
                {
                    return BadRequest();
                }

                // only to update quantity.
                if (_invoiceItemContainer.IsItemQuantitySame(invoiceItem))
                {
                    return NotFound();
                }
                else
                {
                    await _invoiceItemContainer.UpdateInvoiceItemQuantity(invoiceItem);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/InvoiceItem
        [HttpPost("{customerId}/add")]
        public async Task<ActionResult<InvoiceItem>> AddItemToCart(int customerId, [FromBody]InvoiceItemDto invoiceItem)
        {
            try
            {
                var customer = await _invoiceItemContainer.GetCustomerByCustomerId(customerId);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                var product = await _invoiceItemContainer.GetProductByProductId(invoiceItem.ProductId);

                if (product == null || product.Quantity < invoiceItem.Quantity)
                {
                    return BadRequest("Product not available or insufficient quantity");
                }

                await _invoiceItemContainer.AddInvoiceItemToCart(invoiceItem, product);
                return Ok(invoiceItem);
                //return CreatedAtAction("GetInvoiceItem", new { id = invoiceItem.Id }, invoiceItem);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE: api/InvoiceItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemFromCart(int id)
        {
            try
            {
                var item = await _invoiceItemContainer.GetItemToDeleteByInvoiceId(id);

                if (item == null)
                {
                    return NotFound();
                }
                var product = await _invoiceItemContainer.GetProductByProductId(item.ProductId);

                await _invoiceItemContainer.DeleteInvoiceItemFromCart(item, product);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}