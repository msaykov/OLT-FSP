namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Models.Targets;
    using OLT_FSP.Services.Targets;

    public class TargetsController : Controller
    {
        private readonly ITargetService target;
        public TargetsController(ITargetService targetService)
        {
            this.target = targetService;
        }
        public IActionResult Add()
            => View();

        [HttpPost]
        public IActionResult Add(AddTargetFormModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.target.Add(model.Destination, model.CoremapNumber, model.Zone, id);
            

            return RedirectToAction("All", "Ports");
        }
    }
}
