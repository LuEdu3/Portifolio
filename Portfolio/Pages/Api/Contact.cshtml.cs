using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portfolio.Services;

namespace Portfolio.Pages.Api;

[IgnoreAntiforgeryToken]
public class ContactModel : PageModel
{
    private readonly ContactService _contact;
    public ContactModel(ContactService contact) => _contact = contact;

    public async Task<IActionResult> OnPostAsync([FromForm] string name, [FromForm] string email, [FromForm] string message)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            return BadRequest();

        var ok = await _contact.SendAsync(name, email, message);
        if (ok) return new OkResult();
        return StatusCode(500);
    }
}
