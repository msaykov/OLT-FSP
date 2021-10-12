namespace OLT_FSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using OLT_FSP.Models.Slots;
    using OLT_FSP.Services.Slots;

    public class SlotsController : Controller
    {
        private readonly ISlotService slot;
        public SlotsController(ISlotService slotService)
        {
            this.slot = slotService;
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddSlotFormModel model, int id)
        {
            if (!(model.PortsCount == 8 || model.PortsCount == 16))
            {
                this.ModelState.AddModelError(nameof(model.PortsCount), "Ports must be 8 or 16.");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.slot.Add(model.PortsCount, id);

            return RedirectToAction("All", "Devices");
        }
    }
}
