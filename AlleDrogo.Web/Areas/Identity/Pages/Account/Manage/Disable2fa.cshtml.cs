using AlleDrogo.Domain.Entities.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AlleDrogo.Web.Areas.Identity.Pages.Account.Manage
{
    public class Disable2faModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Disable2faModel> _logger;

        public Disable2faModel(
            UserManager<ApplicationUser> userManager,
            ILogger<Disable2faModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie mo¿na za³adowaæ u¿ytkownika z ID '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.GetTwoFactorEnabledAsync(user))
            {
                throw new InvalidOperationException($"Nie mo¿na zablokowaæ uwierzytelniania dwuetapowego u¿ytkownikowi o ID '{_userManager.GetUserId(User)}' ,bo nie jest ono obecnie aktywne.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Nie mo¿na za³adowaæ u¿ytkownika z tym ID '{_userManager.GetUserId(User)}'.");
            }

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                throw new InvalidOperationException($"Nieoczekiwany b³¹d wyst¹pi³ podczas blokowanaia uwierzytelniania dwuetapowego dla u¿ytkownika z ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("U¿ytkownik z ID '{UserId}' ma zablokowane uwierzytelnianie dwuetapowe.", _userManager.GetUserId(User));
            StatusMessage = "Uwierzytelnianie dwuetapowe zosta³o zablokowane. Mo¿esz je oblokowaæ, kiedy ustawisz aplikacjê uwierzytelniaj¹c¹";
            return RedirectToPage("./TwoFactorAuthentication");
        }
    }
}