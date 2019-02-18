using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using NetGram.Models;
using NetGram.Models.Interfaces;

namespace NetGram.Pages.Grams
{
    public class ManageModel : PageModel
    {
        private readonly IGram _gram;

        [FromRoute]
        public int? ID { get; set; }

        [BindProperty]
        public Gram Gram { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public Models.Util.Blob BlobImage { get; set; }

        public ManageModel(IGram gram, IConfiguration configuration)
        {
            _gram = gram;
            //Blob Storage Account Reference 
            BlobImage = new Models.Util.Blob(configuration);
        }

        public async Task OnGet()
        {
            Gram = await _gram.FindGram(ID.GetValueOrDefault()) ?? new Gram();
        }

        public async Task<IActionResult> OnPost()
        {
            var gram = await _gram.FindGram(ID.GetValueOrDefault()) ?? new Gram();
            gram.Name = Gram.Name;
            gram.Title = Gram.Title;

            if (Image != null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                //Get Container
                var container = await BlobImage.GetContainer("gram");
                //Upload the Image
                BlobImage.UploadFile(container, Image.FileName, filePath);

                CloudBlob blob = await BlobImage.GetBlob(Image.FileName, container.Name);
                //Update the Database image for the gram
                gram.URL = blob.Uri.ToString();
            }

            //save
            await _gram.SaveAsync(gram);
            //rederect
            return RedirectToPage("/Index", new { id = gram.ID });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await _gram.DeleteAsync(ID.Value);
            return RedirectToPage("/Index");
        }
    }
}