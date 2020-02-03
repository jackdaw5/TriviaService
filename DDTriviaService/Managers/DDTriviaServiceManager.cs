using DDTriviaService.Managers.Interfaces;
using DDTriviaService.Respositories;
using DDTriviaService.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDTriviaService.Managers
{
	public class DDTriviaServiceManager : IDDTriviaServiceManager
	{
		private IDDTriviaServiceRepository DDTriviaServiceRepository { get; set; }

		public DDTriviaServiceManager(IDDTriviaServiceRepository ddTriviaServiceRepository)
		{
			DDTriviaServiceRepository = ddTriviaServiceRepository;
		}

		public IEnumerable<Trivia> GetAllTrivia()
		{
			//DDTriviaServiceRepository DDTriviaServiceRepository = new DDTriviaServiceRepository();
			IEnumerable<Trivia> trivia = DDTriviaServiceRepository.SelectAllTrivia();
			return trivia;
		}

		//public Trivia CreateTriviaQuestion(Trivia trivia)
		//{
		//	//DDTriviaServiceRepository repo = new DDTriviaServiceRepository();
		//	return DDTriviaServiceRepository.InsertTriviaQuestion(trivia);
		//}

	}
}
