namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Data.Models;
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
            this.port.Add(model.SplitterOutputs, model.Path, model.Destination, model.CoremapNumber, model.Zone, model.Description, model.Notes, id);
            return RedirectToAction("All" ,"Ports");
        }

        public IActionResult All(string coremapId, string address, string port, int id)
        {
            var allPorts = this.port.All(coremapId, address, port, id);
            var deviceName = this.port.GetDeviceFullName(id);
            return View(new SearchPortServiceModel
            {
                Id = id,
                Ports = allPorts,
                Address = address,
                CoremapId = coremapId,
                DeviceFullName = deviceName,
            });
        }

        


    }
}
