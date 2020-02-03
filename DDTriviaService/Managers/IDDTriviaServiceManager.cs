using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDTriviaService.Managers.Interfaces
{
	public interface IDDTriviaServiceManager
	{
		public IEnumerable<Trivia> GetAllTrivia();

		//public Trivia CreateTriviaQuestion(Trivia trivia);
	}
}
