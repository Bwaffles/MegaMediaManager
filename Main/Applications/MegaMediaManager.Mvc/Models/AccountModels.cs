using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MegaMediaManager.Mvc.Models
{
    public class ExternalLoginsListPartialViewModel
    {
        public enum CallingActionType { Register, Login, Manage };

        public class LoginProvider
        {
            private static readonly string Google = "Google";
            private static readonly string Facebook = "Facebook";

            private Dictionary<string, string> LoginProviderStyle = new Dictionary<string, string>()
            {
                { Google, "google plus" },
                { Facebook, "facebook" }
            };

            private Dictionary<string, string> LoginProviderIcon = new Dictionary<string, string>()
            {
                { Google, "google-plus" },
                { Facebook, "facebook" }
            };

            private Dictionary<string, string> LoginProviderText = new Dictionary<string, string>()
            {
                { Google, "Google+" },
                { Facebook, "Facebook" }
            };

            public LoginProvider(string provider) { Provider = provider; }

            public string Provider;
            public string Class { get { return LoginProviderStyle[Provider]; } }
            public string Icon { get { return LoginProviderIcon[Provider]; } }
            public string Text { get { return LoginProviderText[Provider]; } }
        }

        public LoginProvider Provider { get; set; }

        public string Action { get; set; }

        public string ReturnUrl { get; set; }

        public CallingActionType CallingAction { get; set; }
    }

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string LoginId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("PasswordHash", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}