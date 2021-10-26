namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Models.Ports;
    using OLT_FSP.Services.Ports;

    public class PortsController : Controller
    {
        private readonly IPortService port;
        public PortsController(IPortService portsService)
        {
            this.port = portsService;
        }

        public IActionResult Add()
            => View();

        [HttpPost]
        public IActionResult Add(AddPortFormModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.port.Add(id);
            return View();
        }
    }
}
