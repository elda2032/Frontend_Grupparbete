using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Mvc.JQuery.Datatables;

[assembly: PreApplicationStartMethod(typeof(Frontend_Grupparbete.RegisterDatatablesModelBinder), "Start")]

namespace Frontend_Grupparbete {
    public static class RegisterDatatablesModelBinder {
        public static void Start() {
        }
    }
}
