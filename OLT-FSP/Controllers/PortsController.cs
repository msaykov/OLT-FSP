namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Models.Ports;
    using OLT_FSP.Services.Ports;

    public class PortsController : Controller
    {
        private readonly IPortService port;
        public PortsController(IPortService portService)
        {
            this.port = portService;
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
            this.port.Add(model.Path, model.Zone, model.Destination, model.Description, model.CoremapNumber, model.Notes, id);
            return RedirectToAction("All" ,"Devices");
        }

        //public IActionResult All()
        //    => View();

        public IActionResult All(string destinationId, string destinationAddress)
        {
            var portsQuery = port.All(destinationAddress, destinationId);
            return View(new SearchPortServiceModel
            {
                Id = 5, // ??????
                Ports = portsQuery,
            });
        }
    }
}
