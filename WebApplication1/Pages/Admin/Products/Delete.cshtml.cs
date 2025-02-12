using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Services;

namespace WebApplication1.Pages.Admin.Products
{
    public class DeleteModel : PageModel
    { private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment; 
            this.context=context;
        }



        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;

            }
            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin/Products/Index");
                return;
            }
            string imageFilePath = environment.WebRootPath + "/Products/" + product.ImageFileName;
            System.IO.File.Delete(imageFilePath);

            context.Products.Remove(product);
            context.SaveChanges();

            Response.Redirect("/Admin/Products/Index");

        }
    }
}
