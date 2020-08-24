using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalCap.Models;
using FinalCapApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalCapApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    private static List<Car> _cars = new List<Car>();

    [HttpGet]
    public IEnumerable<Car> Get()
    {
        return Car;
    }

    [HttpPost]
    public IActionResult Post(Car car)
    {
        _cars.Add(car);
        return Created($"/api/books/{car.CarId}", car);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var car = _cars.FirstOrDefault(x => x.CarId == id);
        if (car == null)
        {
            return NotFound();
        }

        return Ok(car);
    }
}
