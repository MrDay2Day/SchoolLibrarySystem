using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Views.Shared.Components.Pagination
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(
                int previousPage,
                int nextPage,
                int maxPage,
                int currentPage
            )
        {
            // Logic here
            return View(new
            {
                previousPage = previousPage,
                nextPage = nextPage,
                maxPage = maxPage,
                currentPage = currentPage
            });
        }
    }
}
