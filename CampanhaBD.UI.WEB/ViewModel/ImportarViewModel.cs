using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampanhaBD.UI.WEB.ViewModel
{
    public class ImportarViewModel
    {
        public string Nome { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}