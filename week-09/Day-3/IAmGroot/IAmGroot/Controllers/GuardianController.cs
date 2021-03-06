﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmGroot.Services;
using Microsoft.AspNetCore.Mvc;

namespace IAmGroot.Controllers
{
    [Route("")]
    public class GuardianController : Controller
    {
        public CargoService cargoService;

        public GuardianController(CargoService cargoService)
        {
            this.cargoService = cargoService;
        }

        [HttpGet("groot")]
        public IActionResult Groot(string message)
        {
            if (message == null)
            {
                return BadRequest(new { error = "I am Groot!" });
            }
            return Json(new { received = message, translated = "I am Groot!" });
        }

        [HttpGet("yondu")]
        public IActionResult Yondu(double? distance, double? time)
        {
            if (time == null && distance == null)
            {
                return BadRequest(new { error = "I am Groot!" });
            }
            return Json(new { distance = distance, time = time, speed = distance / time });
        }

        [HttpGet("rocket")]
        public IActionResult Rocket()
        {
            cargoService.ShipStatus();
            cargoService.Ready();
            cargoService.GetResult();
            return Json(cargoService.result);
        }

        [HttpGet("rocket/fill")]
        public IActionResult Fill(string caliber, int amount)
        {
            cargoService.Fill(caliber, amount);
            return caliber == null && amount == 0 ? (IActionResult)BadRequest(new { error = "I am Groot!" }) 
                : RedirectToAction("rocket");
        }
    }
}
