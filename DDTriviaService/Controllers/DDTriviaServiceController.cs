using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DDTriviaService.Respositories.Interfaces;
using DDTriviaService.Managers.Interfaces;
using DDTriviaService.Managers;

namespace DDTriviaService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DDTriviaServiceController : Controller
	{
		private IDDTriviaServiceManager DDTriviaServiceManager { get; set; }

		public DDTriviaServiceController(IDDTriviaServiceManager ddTriviaServiceManager)
		{
			DDTriviaServiceManager = ddTriviaServiceManager;
		}

		[HttpGet("")]
		//[Route("GetTrivia")]
		[ProducesResponseType(typeof(IEnumerable<Trivia>), StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetTriviaQuestion()
		{
			try
			{
				//DDTriviaServiceManager manager = new DDTriviaServiceManager();
				IEnumerable<Trivia> trivia = DDTriviaServiceManager.GetAllTrivia();

				if (trivia == null)
				{
					return NotFound("Requested trivia question does not exist");
				}

				return Ok(trivia);
			}

			catch (Exception ex)
			{
				//Logger.Error(ex, "An exception occurred while retirving trivia questions");
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		//[HttpPost]
		//[ProducesResponseType(typeof(Trivia), StatusCodes.Status200OK)]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		//public IActionResult CreateTriviaQuestion([FromBody]Trivia trivia)
		//{
		//	try
		//	{
		//		//DDTriviaServiceManager manager = new DDTriviaServiceManager();
		//		trivia = DDTriviaServiceManager.CreateTriviaQuestion(trivia);

		//		if (trivia == null)
		//		{
		//			return NotFound("Requested trivia question does not exist");
		//		}

		//		return Ok(trivia);
		//	}

		//	catch (Exception ex)
		//	{
		//		//Logger.Error(ex, "An exception occurred while retirving trivia questions");
		//		return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		//	}
		//}
	}
}
