﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Newtonsoft.Json;
using ControlVehicularEN = CASCO.EN.SICAS;

namespace ControlVehicularF4.Controllers
{
	//[Authorize]
	public class AccountController : Controller
	{
		
		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
            FormsAuthentication.SignOut();
            Session.RemoveAll();

            ViewBag.ReturnUrl = returnUrl;
			return View();
		}



        //[AllowAnonymous]
        [HttpPost]
        public JsonResult ObtienUsuarioValido(string usuario_ID, String pwd)
        {
            ControlVehicularEN.Usuario user = new ControlVehicularEN.Usuario();
            user.Usuario_ID = usuario_ID;
            user.Pwd = pwd;

            CASCO.BL.SICAS.Usuarios usuariosBL = new CASCO.BL.SICAS.Usuarios();
            bool bActualiza = usuariosBL.ObtienUsuarioValido(user);

            if(bActualiza) {
                //DateTime expiration = DateTime.Now.AddHours(2);
                //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Usuario_ID, DateTime.Now, expiration, false, user.Usuario_ID);
                //string cookie = FormsAuthentication.Encrypt(ticket);
                //HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookie);
                //httpCookie.Expires = expiration;
                //httpCookie.Path = FormsAuthentication.FormsCookiePath;
                //Response.Cookies.Add(httpCookie);

                Session["Usuario_ID"] = user.Usuario_ID;                
                Session["UsuarioAccesos"] = CASCO.BL.ControlVehicular.RevistaGeneral.obtieneAccesosPaginas(user.Usuario_ID);
            }

            JsonResult j = new JsonResult();
            j.Data = bActualiza;
            j.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return j;
        }


        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			WebSecurity.Logout();

			return RedirectToAction("Index", "Home");
		}

		//
		// GET: /Account/Register

		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Disassociate(string provider, string providerUserId)
		{
			string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
			ManageMessageId? message = null;

			// Only disassociate the account if the currently logged in user is the owner
			if (ownerAccount == User.Identity.Name)
			{
				// Use a transaction to prevent the user from deleting their last login credential
				using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
				{
					bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
					if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
					{
						OAuthWebSecurity.DeleteAccount(provider, providerUserId);
						scope.Complete();
						message = ManageMessageId.RemoveLoginSuccess;
					}
				}
			}

			return RedirectToAction("Manage", new { Message = message });
		}

		public ActionResult Manage(ManageMessageId? message)
		{
			ViewBag.StatusMessage =
			    message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
			    : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
			    : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
			    : "";
			ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
			ViewBag.ReturnUrl = Url.Action("Manage");
			return View();
		}



		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public ActionResult ExternalLogin(string provider, string returnUrl)
		{
			return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
		}

		//
		// GET: /Account/ExternalLoginCallback

		[AllowAnonymous]
		//public ActionResult ExternalLoginCallback(string returnUrl)
		//{
		//	AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
		//	if (!result.IsSuccessful)
		//	{
		//		return RedirectToAction("ExternalLoginFailure");
		//	}

		//	if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
		//	{
		//		return RedirectToLocal(returnUrl);
		//	}

		//	if (User.Identity.IsAuthenticated)
		//	{
		//		// If the current user is logged in add the new account
		//		OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
		//		return RedirectToLocal(returnUrl);
		//	}
		//	else
		//	{
		//		// User is new, ask for their desired membership name
		//		string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
		//		ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
		//		ViewBag.ReturnUrl = returnUrl;
		//		return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
		//	}
		//}

		//
		// POST: /Account/ExternalLoginConfirmation

		//[HttpPost]
		//[AllowAnonymous]
		[ValidateAntiForgeryToken]
		//public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
		//{
		//	string provider = null;
		//	string providerUserId = null;

		//	if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
		//	{
		//		return RedirectToAction("Manage");
		//	}

		//	if (ModelState.IsValid)
		//	{
		//		// Insert a new user into the database
		//		using (UsersContext db = new UsersContext())
		//		{
		//			UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
		//			// Check if user already exists
		//			if (user == null)
		//			{
		//				// Insert name into the profile table
		//				db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
		//				db.SaveChanges();

		//				OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
		//				OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

		//				return RedirectToLocal(returnUrl);
		//			}
		//			else
		//			{
		//				ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
		//			}
		//		}
		//	}

		//	ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
		//	ViewBag.ReturnUrl = returnUrl;
		//	return View(model);
		//}

		//
		// GET: /Account/ExternalLoginFailure

		//[AllowAnonymous]
		//public ActionResult ExternalLoginFailure()
		//{
		//	return View();
		//}

		//[AllowAnonymous]
		//[ChildActionOnly]
		//public ActionResult ExternalLoginsList(string returnUrl)
		//{
		//	ViewBag.ReturnUrl = returnUrl;
		//	return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
		//}

		//[ChildActionOnly]
		//public ActionResult RemoveExternalLogins()
		//{
		//	ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
		//	List<ExternalLogin> externalLogins = new List<ExternalLogin>();
		//	foreach (OAuthAccount account in accounts)
		//	{
		//		AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

		//		externalLogins.Add(new ExternalLogin
		//		{
		//			Provider = account.Provider,
		//			ProviderDisplayName = clientData.DisplayName,
		//			ProviderUserId = account.ProviderUserId,
		//		});
		//	}

		//	ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
		//	return PartialView("_RemoveExternalLoginsPartial", externalLogins);
		//}

		#region Helpers
		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}

		public enum ManageMessageId
		{
			ChangePasswordSuccess,
			SetPasswordSuccess,
			RemoveLoginSuccess,
		}

		internal class ExternalLoginResult : ActionResult
		{
			public ExternalLoginResult(string provider, string returnUrl)
			{
				Provider = provider;
				ReturnUrl = returnUrl;
			}

			public string Provider { get; private set; }
			public string ReturnUrl { get; private set; }

			public override void ExecuteResult(ControllerContext context)
			{
				OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
			}
		}

		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
				case MembershipCreateStatus.DuplicateUserName:
					return "User name already exists. Please enter a different user name.";

				case MembershipCreateStatus.DuplicateEmail:
					return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

				case MembershipCreateStatus.InvalidPassword:
					return "The password provided is invalid. Please enter a valid password value.";

				case MembershipCreateStatus.InvalidEmail:
					return "The e-mail address provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidAnswer:
					return "The password retrieval answer provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidQuestion:
					return "The password retrieval question provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.InvalidUserName:
					return "The user name provided is invalid. Please check the value and try again.";

				case MembershipCreateStatus.ProviderError:
					return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				case MembershipCreateStatus.UserRejected:
					return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

				default:
					return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
			}
		}
		#endregion
	}
}
