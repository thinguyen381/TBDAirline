using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TBDAirline.Data;
using TBDAirline.Models;
using System.Security.Claims;

namespace TBDAirline.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Register creates a new account in the database
        /// </summary>
        /// <param name="AccountView"></param>
        /// <returns>View()</returns>
        public IActionResult Register(AccountView accountModel)
        {

            if (!string.IsNullOrEmpty(accountModel?.Account?.UserName)
                && !string.IsNullOrEmpty(accountModel?.Account?.Password))
            {
                Account existingAccount =
                    _context.Account.Where(a => a.UserName == accountModel.Account.UserName).FirstOrDefault();

                // Ask for another user name when typed userName has been already existing
                if (existingAccount != null)
                {
                    accountModel.Error = "User Name or Password is not correct";
                    accountModel.Success = false;
                    return View(accountModel);
                }

                // Create a new Account and store the new Account into database
                else
                {
                    Account newAccount = new Account();
                    newAccount.UserName = accountModel.Account.UserName;
                    newAccount.Password = accountModel.Account.Password;
                    newAccount.IsAdmin = false; // A new account is not authorized as an admin by default
                    _context.Account.Add(newAccount);
                    _context.SaveChanges();

                    accountModel.Success = true;
                    return View(accountModel);

                }
            }

            return View();
        }
        /// <summary>
        /// Login logs user into an already created account
        /// </summary>
        /// <param name="AccountView"></param>
        /// <returns>View()</returns>
        public async Task<IActionResult> Login(AccountView accountModel)
        {


            if (!string.IsNullOrEmpty(accountModel?.Account?.UserName)
                && !string.IsNullOrEmpty(accountModel?.Account?.Password))
            {
                Account existingAccount =
                    _context.Account.Where(a => a.UserName == accountModel.Account.UserName
                                             && a.Password == accountModel.Account.Password).FirstOrDefault();

                if (existingAccount == null)
                {
                    accountModel.Error = "User Name or Password is not correct";
                    return View(accountModel);
                }
                else
                {
                    // TODO: Fix error
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, accountModel.Account.UserName));
                    claims.Add(new Claim("AccountID", existingAccount.AccountID.ToString()));
                    claims.Add(new Claim("IsAdmin", existingAccount.IsAdmin? "true": "false"));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    // Session is from BookController where flights have been selected
                    if (this.HttpContext.Session.Keys.Contains("DepartFlightID"))
                    {
                        return RedirectToAction("Index", "Passenger");
                    }

                    // Login before searching
                    return RedirectToAction("Index", "Search");
                }

            }

            return View();
        }



        /// <summary>
        /// Logout directs user to home page and logs out of an account they were previously logged into
        /// </summary>
        /// <param name="AccountView"></param>
        /// <returns>View()</returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Search");
        }
    }
}