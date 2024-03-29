﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;
using Azure.Storage.Blobs;

namespace Lab5.Pages.Predictions
{
    public class DeleteModel : PageModel
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";

        private readonly Lab5.Data.PredictionDataContext _context;

        public DeleteModel(Lab5.Data.PredictionDataContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        [BindProperty]
      public Prediction Prediction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Predictions == null)
            {
                return NotFound();
            }

            var prediction = await _context.Predictions.FirstOrDefaultAsync(m => m.PredictionId == id);

            if (prediction == null)
            {
                return NotFound();
            }
            else 
            {
                Prediction = prediction;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Predictions == null)
            {
                return NotFound();
            }
            var prediction = await _context.Predictions.FindAsync(id);

            if (prediction != null)
            {
                // Handle image deletion
                if (!string.IsNullOrEmpty(prediction.Url))
                {
                    var containerName = prediction.Question == Question.Earth ? earthContainerName : computerContainerName;
                    var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);

                    var fileName = Path.GetFileName(prediction.Url);
                    var blobClient = blobContainerClient.GetBlobClient(fileName);
                    await blobClient.DeleteIfExistsAsync();
                }

                Prediction = prediction;
                _context.Predictions.Remove(Prediction);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
