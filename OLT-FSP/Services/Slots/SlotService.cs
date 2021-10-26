﻿namespace OLT_FSP.Services.Slots
{
    using OLT_FSP.Data;
    using OLT_FSP.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using static Data.DataConstants;

    public class SlotService : ISlotService
    {
        private readonly OltDbContext data;

        public SlotService(OltDbContext data)
        => this.data = data;

        public void Add(int ports, int deviceId)
        {
            var currentDevice = this.GetDeviceById(deviceId);
            var slotsCount = GetSlotsCount(deviceId);
            if (slotsCount == FullOlt)
            {
                return;
            }
            if (slotsCount == EmptyOltSlots)
            {
                AddServiceSlot(deviceId, slotsCount);
            }
            if (slotsCount == HalfSlotsMounted)
            {
                AddServiceSlot(deviceId, slotsCount);
                AddServiceSlot(deviceId, slotsCount);
            }
            
            var slotEntity = new Slot
            {
                Device = currentDevice,
                Number = GetSlotsCount(deviceId),
                PortsCount = ports,
                IsServiceSlot = false,
            };
            currentDevice.Slots.Add(slotEntity);
            this.data.SaveChanges();

            if (GetSlotsCount(deviceId) == AllSlotsMounted)
            {
                AddServiceSlot(deviceId, slotsCount);
                AddServiceSlot(deviceId, slotsCount);
            }
        }

        public ICollection<SlotServiceModel> All(int deviceId)
        {
            var slotsQuery = GetAllSlots(deviceId);
            var deviceEntity = GetDeviceById(deviceId);
            return slotsQuery
                .Select(s => new SlotServiceModel
                {
                    Id = s.Id,
                    DeviceName = deviceEntity.Name,
                    SlotNumber = s.Number,
                    PortsCount = s.PortsCount,
                    UsedPorts = s.Ports.Count(),                    
                })
                .ToList();
        }

        private ICollection<Slot> GetAllSlots(int deviceId)
            => this.data
            .Slots
            .Where(s => s.DeviceId == deviceId && s.IsServiceSlot == false)
            .OrderBy(s => s.Number)
            .ToList();

        private void AddServiceSlot(int deviceId, int slotsCount)
        {
            var currentDevice = this.GetDeviceById(deviceId);
            var slotEntity = new Slot
            {
                Device = currentDevice,
                Number = GetSlotsCount(deviceId),
                PortsCount = ServiceSlotPortsCount,
                IsServiceSlot = true,
            };
            currentDevice.Slots.Add(slotEntity);
            this.data.SaveChanges();
        }

        private int GetSlotsCount(int deviceId) 
            => this.data
                .Slots
                .Where(s => s.DeviceId == deviceId)
                .Count();

        private Device GetDeviceById(int deviceId)
            => this.data
                .Devices
                .FirstOrDefault(d => d.Id == deviceId);

    }
}