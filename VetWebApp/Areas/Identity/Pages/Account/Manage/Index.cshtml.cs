﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetWebApp.Areas.Identity.Data;

namespace VetWebApp.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<VetWebAppUser> _userManager;
        private readonly SignInManager<VetWebAppUser> _signInManager;

        public IndexModel(
            UserManager<VetWebAppUser> userManager,
            SignInManager<VetWebAppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First/Given Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last/Family Name")]
            public string LastName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Suburb")]
            public string Suburb { get; set; }

            [Required]
            [DataType(DataType.PostalCode)]
            [Display(Name = "Postcode")]
            public int ? Postcode { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Pet Name")]
            public string PetName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Pet Breed")]
            public string PetBreed { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Pet Age")]
            public string PetAge { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Pet Gender")]
            public string PetGender { get; set; }

            [Required]
            [Display(Name = "Pet Image")]
            public string ? PetImage { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(VetWebAppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Suburb = user.Suburb,
                Postcode = user.Postcode,
                PetName = user.PetName,
                PetBreed = user.PetGender,
                PetAge = user.PetAge,
                PetGender = user.PetGender,
                PetImage = user.PetImage
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }
            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if (Input.Suburb != user.Suburb)
            {
                user.Suburb = Input.Suburb;
            }
            if (Input.Postcode != user.Postcode)
            {
                user.Postcode = Input.Postcode;
            }
            if (Input.PetName != user.PetName)
            {
                user.PetName = Input.PetName;
            }
            if (Input.PetBreed != user.PetBreed)
            {
                user.PetBreed = Input.PetBreed;
            }
            if (Input.PetAge != user.PetAge)
            {
                user.PetAge = Input.PetAge;
            }
            if (Input.PetGender != user.PetGender)
            {
                user.PetGender = Input.PetGender;
            }
            if (Input.PetImage != user.PetImage) 
            {
                user.PetImage = Input.PetImage;
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
