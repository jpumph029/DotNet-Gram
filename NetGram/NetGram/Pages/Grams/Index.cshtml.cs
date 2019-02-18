using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetGram.Models;
using NetGram.Models.Interfaces;

namespace NetGram.Pages.Grams
{
    public class IndexModel : PageModel
    {
        private readonly IGram _gram;

        [FromRoute]
        public int ID { get; set; }
        public Gram Gram { get; set; }

        public IndexModel(IGram gram)
        {
            _gram = gram;
        }

        public async Task OnGet()
        {
            //set data

            //get specific gram from an id
            Gram = await _gram.FindGram(ID);
        }
    }
}