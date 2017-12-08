using Noriko.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Noriko
{
    class NorikoCore
    {
		private const string ConntectionString = "Host=karuta.luminousvector.com;Username=TechSupport;Password=;Database=itec305";

		private static T RunCommand<T>(Func<NpgsqlCommand, T> func)
		{
			using (var con = new NpgsqlConnection(ConntectionString))
			{
				con.Open();
				using (var cmd = con.CreateCommand())
				{
					return func(cmd);
				}
			}
		}


		public static void AddDish(DishModel dish) => RunCommand(cmd =>
		{
			cmd.CommandText = $"INSERT INTO dishes VALUES('{Uri.EscapeDataString(dish.Name)}', {dish.Spiciness})";
			cmd.ExecuteNonQuery();
			return 0;
		});

		public static List<DishModel> GetDishes() => RunCommand(cmd =>
		{
			List<DishModel> dishes = new List<DishModel>();
			cmd.CommandText = "SELECT * FROM dishes";
			using (var reader = cmd.ExecuteReader())
			{
				while (reader.Read())
					dishes.Add(new DishModel
					{
						Name = Uri.UnescapeDataString(reader.GetString(0)),
						Spiciness = reader.GetInt32(1)
					});
			}
			return dishes;
		});
	}
}
