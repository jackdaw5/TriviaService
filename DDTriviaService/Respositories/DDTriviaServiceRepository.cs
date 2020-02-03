using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DDTriviaService.Properties;
using DDTriviaService.Respositories.Interfaces;

namespace DDTriviaService.Respositories
{
	public class DDTriviaServiceRepository : IDDTriviaServiceRepository
	{
		
		public IEnumerable<Trivia> SelectAllTrivia()
		{
			MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
			builder.Database = "localhost";
			builder.UserID = "root";
			builder.Password = "Playthegame11!!";

			using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))

			{
				using (MySqlCommand command = new MySqlCommand(Resource.SelectAllTrivia, connection))
				{
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
						}
					}
				}
			}
			return null;
		}

		//public Trivia InsertTriviaQuestion(Trivia trivia)
		//{
		//	//IDictionary<string, string> parameters = new Dictionary<string, string>
		//	//{
		//	//	{ "@Question", trivia.Question },
		//	//	{ "@CorrectAnswer", trivia.CorrectAnswer.ToString() },
		//	//	{ "@Option1", trivia.Option1 },
		//	//	{ "@Option2", trivia.Option2 },
		//	//	{ "@Option3", trivia.Option3 },
		//	//	{ "@Option4", trivia.Option4 }
		//	//};

		//	//object result = MySql.Data.
		//	MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
		//	builder.Database = "localhost";
		//	builder.UserID = "root";
		//	builder.Password = "Playthegame11!!";

		//	using (MySqlConnection connection = new MySqlConnection(builder.ConnectionString))

		//	{
		//		using (MySqlCommand command = new MySqlCommand(Resource.InsertTriviaQuestion, connection))
		//		{
		//			using (MySqlDataReader reader = command.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
		//				}
		//			}
		//		}
		//	}
		//	return null;
		//	//	sql = "server=localhost;port=3306;database=sys;user=root;password=Playthegame11!!";

		//	//using (MySqlConnection conn = sql)
		//	//{
		//	//	List<Trivia> list = new List<Trivia>();
		//	//	conn.Open();
		//	//	MySqlCommand cmd = new MySqlCommand("select * from Album where id < 10", conn);

		//	//	using (var reader = cmd.ExecuteReader());
		//		//{
		//		//	while (reader.Read())
		//		//	{
		//		//		list.Add(new Trivia()
		//		//		{
		//		//			Id = Convert.ToInt32(reader["Id"]),
		//		//			Name = reader["Name"].ToString(),
		//		//			ArtistName = reader["ArtistName"].ToString(),
		//		//			Price = Convert.ToInt32(reader["Price"]),
		//		//			Genre = reader["genre"].ToString()
		//		//		});
		//		//	}
		//		//}
		//	}
		}
	}