//===============================================================================
// Microsoft FastTrack for Azure
// Application Insights Examples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PubsRepository.Models;
using PubsRepository.Services;
using System.Collections.Generic;

namespace PubsRazorPages.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private ILogger _logger = null;
        private PubsService _pubsService = null;

        public List<Author> Authors { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PubsService pubsService)
        {
            _logger = logger;
            _pubsService = pubsService;
        }
        public IActionResult OnGet()
        {
            _logger.LogInformation("Author Index: Retrieving Authors...");
            this.Authors = _pubsService.ListAuthors();
            return Page();
        }
    }
}