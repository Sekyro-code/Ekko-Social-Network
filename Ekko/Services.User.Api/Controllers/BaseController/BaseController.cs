using Common.Api.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace Services.User.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Cette méthode prend une fonction asynchrone (Func<Task>) en paramètre.
        /// Elle exécute cette fonction asynchrone à l'aide de await func().
        /// Elle retourne un Task<ActionResult>. La ActionResult est le résultat qui sera renvoyé 
        /// par l'action du contrôleur. 
        /// Dans ce cas, il s'agit généralement d'un code HTTP sans résultat spécifique.
        /// </summary>
        /// <param name="func"></param>
        /// <returns>StatusCode ou Exception</returns>
        protected async Task<ActionResult> HandleExceptionAsync(Func<Task> func)
        {
            try
            {
                // Execute la function donnée en paramètre
                await func();
                // Retourn 'StatusCode' de 'ActionResult' si aucune Exception est levée.
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex is EkkoException ekkoEx)
                {
                    if (!string.IsNullOrEmpty(ekkoEx.Title) && ekkoEx.Errors != null)
                    {
                        return StatusCode(Convert.ToInt32(ekkoEx.Code), new
                        {
                            title = ekkoEx.Title,
                            status = Convert.ToInt32(ekkoEx.Code),
                            errors = ekkoEx.Errors
                        });
                    }
                    else
                    {
                        return StatusCode(Convert.ToInt32(ekkoEx.Code), ekkoEx.Message);
                    }
                }
                else if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is BadRequestException)
                {
                    return BadRequest(ex.Message);
                }
                else if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid registration data");
                }
                else
                {
                    return (StatusCode(500, ex.Message));
                }

            }
        }
        /// <summary>
        /// Cette méthode prend une fonction asynchrone avec un résultat '(Func<Task<TResult>>)' en paramètre.
        /// Elle exécute cette fonction asynchrone à l'aide de 'await func()'.
        /// Elle retourne un Task<ActionResult<TResult>>. 
        /// La ActionResult<TResult> est le résultat qui sera renvoyé par l'action du contrôleur. 
        /// Elle contient à la fois le résultat spécifique (TResult) et les informations sur la réponse HTTP associée.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns>Retourne l'objet est le StatusCode ou l'exception</returns>
        protected async Task<ActionResult<TResult>> HandleExceptionAsync<TResult>(Func<Task<TResult>> func)
        {
            try
            {
                // 'Result' est le resultat de la fonction donnée en paramètre de la méthode qu'il va executé.
                var result = await func();
                if (result != null)
                {
                    return Ok(result);
                }
                // Retourn le resultat avec le 'StatusCode' de 'ActionResult' si aucune Exception est levée.
                return NotFound();
            }
            catch (Exception ex)
            {
                if (ex is EkkoException ekkoEx)
                {
                    if (!string.IsNullOrEmpty(ekkoEx.Title) && ekkoEx.Errors != null)
                    {
                        return StatusCode(Convert.ToInt32(ekkoEx.Code), new
                        {
                            title = ekkoEx.Title,
                            status = Convert.ToInt32(ekkoEx.Code),
                            errors = ekkoEx.Errors
                        });
                    }
                    else
                    {
                        return StatusCode(Convert.ToInt32(ekkoEx.Code), ekkoEx.Message);
                    }
                }
                else if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is BadRequestException)
                {
                    return BadRequest(ex.Message);
                }
                else if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid registration data");
                }
                else if (ex is UnauthorizedAccessException)
                {
                    return Unauthorized(ex.Message);
                }
                else
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
