using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Module1Intro.Pages
{
    public class IndexModel : PageModel
    {
        public static HashSet<string> NamesStore = new HashSet<string>();

        public List<string> Names => NamesStore.OrderBy(x => x).ToList();

        public IndexModel()
        {
            NamesStore.Add("gattusmp");
        }

        public void OnGet(string name = "")
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            if (name.Length > 8) return;
            if (name.Length < 2) return;
            if (name.Any(x => !char.IsLetterOrDigit(x))) return;
            if (name == "exampleab") return;

            if (name == "bearcats")
            {
                NamesStore = new HashSet<string>();
                NamesStore.Add("gattusmp");
                return;
            }

            NamesStore.Add(name);
        }
    }
}
