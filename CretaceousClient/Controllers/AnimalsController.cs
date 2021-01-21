using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CretaceousClient.Models;

namespace CretaceousClient.Controllers
{
    public class AnimalsController : Controller
    {
      public IActionResult Index()
      {
        var allAnimals = Animal.GetAnimals();
        return View(allAnimals);
      }

      public IActionResult Details(int id)
      {
        var animalDetails = Animal.GetDetails(id);
        return View(animalDetails);
      }
      public IActionResult Delete(int id)
      {
        Animal.Delete(id);
        return RedirectToAction("Index");
      }
      public IActionResult Edit(int id)
      {
        var animal = Animal.GetDetails(id);
        return View(animal);
      }

      [HttpPost]
      public IActionResult Edit(Animal animal)
      {
        Animal.Put(animal);
        return RedirectToAction("Details", new {id = animal.AnimalId});
      }
    }
}
