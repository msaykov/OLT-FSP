namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Authorization;
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

        
        public IActionResult Edit(int id)
        => View(port.Edit(id));

        [HttpPost]
        //[Authorize]
        public IActionResult Edit(int id, EditPortServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(port.Edit(id));
            }

            port.Edit(
            model.SplitterOutputs,   
            model.Path,            
            model.Destination,
            model.CoremapNumber,
            model.Zone,
            model.Notes,              
            id);

            return RedirectToAction("All", "Ports");
        }


        public IActionResult All(string coremapId, string address, string port, int id)
        {
            var allPorts = this.port.All(coremapId, address, port, id);

            string deviceName = null;
            if (id != 0)
            {
                deviceName = this.port.GetDeviceFullName(id);
            }
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
