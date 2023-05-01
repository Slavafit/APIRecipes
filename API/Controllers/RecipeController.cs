using API.Attributes;
using API.IServices;
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Resources.RequestModels;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class RecipeController : ControllerBase
    {

        private readonly IRecipeItemService _recipeItemService;
        private readonly ServiceContext _serviceContext;

        public RecipeController(IRecipeItemService recipeItemService, ServiceContext serviceContext)
        {
            _recipeItemService = recipeItemService;
            _serviceContext = serviceContext;

        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPost(Name = "InsertRecipe")]
        public async Task Post([FromBody] RecipeRequest recipeRequest)
        {

            await _recipeItemService.InsertRecipe(recipeRequest);
        }

        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpDelete(Name = "DeleteRecipe")]
        public void Delete([FromQuery] int Id)
        {

            _recipeItemService.DeleteRecipe(Id);

        }

        //[EndpointAuthorize(AllowedUserRols = "Administrador")]
        [EndpointAuthorize(AllowsAnonymous = true)]

        [HttpGet(Name = "GetRecipeById")]
        public async Task<RecipeItem> GetRecipe(int recipeId)
        {

            return await _recipeItemService.GetRecipe(recipeId);
        }

        [EndpointAuthorize(AllowsAnonymous = true)]

        [HttpGet(Name = "GetAllRecipes")]
        public async Task<List<RecipeItem>> GetAllRecipes()
        {

            return await _recipeItemService.GetAllRecipes();
        }

        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpPatch(Name = "ModifyRecipe")]
        public void Patch([FromQuery] int id,
                          [FromBody]RecipePatchRequest recipePatchRequest)

        {
            _recipeItemService.UpdateRecipe(id, recipePatchRequest);

        }


        [EndpointAuthorize(AllowsAnonymous = true)]
        [HttpGet(Name = "GetRecipesbyUser")]
        public async Task<List<RecipeItem>> GetRecipesByUser([FromQuery] int id)

        {
            return await _recipeItemService.GetRecipesByUser(id);

        }


        //[HttpGet(Name = "GetAllImages")]
        //public List<ImageItem> GetAll()
        //{

        //    return _imageService.GetAll();

    }    //}
}