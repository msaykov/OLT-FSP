namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Models.Devices;
    using OLT_FSP.Services.Devices;
    using System.Collections.Generic;

    public class DevicesController : Controller
    {
        private readonly IDeviceService device;
        public DevicesController(IDeviceService deviceService)
        {
            this.device = deviceService;
        }

        public IActionResult Add() => View();


        [HttpPost]
        public IActionResult Add(AddDeviceFormModel model)
        {
            
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.device.Create(model.Town, model.DataCenter, model.Manifacturer);

            return RedirectToAction("All", "Devices");
        }

        public IActionResult All(string townName, string dataCenter)
        {
            var deviceQuery = device.All(townName,dataCenter);
            var dataCenterList = device.GetDataCenters();
            return View(new DeviceSearchServiceModel 
            {
                TownName = townName,
                DataCenter = dataCenter,
                Devices = deviceQuery,
                DataCenters = dataCenterList,
            });
        }
    }
}
