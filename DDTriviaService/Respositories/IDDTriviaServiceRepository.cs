using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDTriviaService.Respositories.Interfaces
{
	public interface IDDTriviaServiceRepository
	{
		public IEnumerable<Trivia> SelectAllTrivia();

		//public Trivia InsertTriviaQuestion(Trivia trivia);
	}
}
