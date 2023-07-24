using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Pages.Predictions
{
    public class CreateModel : PageModel
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string containerName = "files";

        private readonly Lab5.Data.PredictionDataContext _context;

        public CreateModel(Lab5.Data.PredictionDataContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prediction Prediction { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Please fill the complete form with correct info")]
        public IFormFile ImageFile { get; set; } // Add this property for the uploaded image


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            // Handle image upload
            if (ImageFile != null)
            {
                //var containerName = Prediction.Question == Question.Earth ? earthContainerName : computerContainerName;
                var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var blobClient = blobContainerClient.GetBlobClient(fileName);

                using (var memoryStream = new MemoryStream())
                {
                    await ImageFile.CopyToAsync(memoryStream);
                    memoryStream.Position = 0;
                    await blobClient.UploadAsync(memoryStream);
                }

                // Set the URL property based on the uploaded image's URL
                Prediction.Url = blobClient.Uri.AbsoluteUri;
                Prediction.FileName=Path.GetFileNameWithoutExtension(ImageFile.FileName);
            }


            _context.Predictions.Add(Prediction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
