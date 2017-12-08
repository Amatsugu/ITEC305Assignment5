using Nancy;
using Nancy.ModelBinding;
using Noriko.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noriko.Modules
{
    public class MainModule : NancyModule
    {
		public MainModule()
		{
			Get("/", _ =>
			{
				return View["index"];
			});

			Get("/result", _ => 
			{
				var dish = this.Bind<DishModel>();
				NorikoCore.AddDish(dish);
				return View["result", NorikoCore.GetDishes()];
			});
		}
    }
}
