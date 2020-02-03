using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDTriviaService
{
	public class Trivia
	{
		public int QuestionID { get; set; }
		public string Question { get; set; }
		public int CorrectAnswer { get; set; }
		public string Option1 { get; set; }
		public string Option2 { get; set; }
		public string Option3 { get; set; }
		public string Option4 { get; set; }

	}
}
