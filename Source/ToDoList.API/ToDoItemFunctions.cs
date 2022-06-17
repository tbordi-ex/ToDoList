using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ToDoList.BLL;
using System.Collections.Generic;

namespace ToDoList.API
{
    public class ToDoItemFunctions
    {
        private ToDoItemManager itemManager;

        public ToDoItemFunctions(ToDoListDbContext context)
        {
            itemManager = new ToDoItemManager(context);
        }

        [FunctionName("AddItem")]
        public async Task<IActionResult> AddItem(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "item")] HttpRequest req,
            ILogger log)
        {
            try
            {
                AddItemDTO addItemDTO = null;
                string requestBody;
                // try to read the dto from body (request)
                try
                {
                    using (var reader = new StreamReader(req.Body))
                    {
                        requestBody = await reader.ReadToEndAsync();
                    }

                    addItemDTO = JsonConvert.DeserializeObject<AddItemDTO>(requestBody);
                }
                catch (Exception e)
                {
                    var result = new ObjectResult(e);
                    result.StatusCode = StatusCodes.Status400BadRequest;
                    return result;
                }
                // send to manager
                var newItem = itemManager.AddItem(addItemDTO);
                return new OkObjectResult(newItem);
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }

        [FunctionName("GetItems")]
        public async Task<IActionResult> GetItems(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "item")] HttpRequest req,
        ILogger log)
        {
            try
            {
                List<ToDoItem> allItems = await itemManager.GetAllItemsAsync();
                return new OkObjectResult(allItems);
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }

        [FunctionName("GetItem")]
        public async Task<IActionResult> GetItem(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "item/{id}")] HttpRequest req,
        int id,
        ILogger log)
        {
            try
            {
                ToDoItem toDoItem = await itemManager.GetItemAsync(id);
                if (toDoItem == null)
                    return new NotFoundResult();
                else 
                    return new OkObjectResult(toDoItem);
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }

        [FunctionName("RemoveItem")]
        public async Task<IActionResult> RemoveItem(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "item/{id}")] HttpRequest req,
        int id,
        ILogger log)
        {
            try
            {
                ToDoItem listWithRemovedItems = await itemManager.RemoveItemAsync(id);
                return new OkResult();
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }

        [FunctionName("UpdateItem")]
        public async Task<IActionResult> UpdateItem(
        [HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = "item/{id}")] HttpRequest req,
        int id,
        ILogger log)
        {
            try
            {
                UpdateItemDTO updateItemDTO = null;
                string requestBody;
                // try to read the dto from body (request)
                try
                {
                    using (var reader = new StreamReader(req.Body))
                    {
                        requestBody = await reader.ReadToEndAsync();
                    }

                    updateItemDTO = JsonConvert.DeserializeObject<UpdateItemDTO>(requestBody);
                }
                catch (Exception e)
                {
                    var result = new ObjectResult(e);
                    result.StatusCode = StatusCodes.Status500InternalServerError;
                    return result;
                }
                // send to manager
                ToDoItem updatedItem = await itemManager.UpdateItemAsync(id, updateItemDTO);
                return new OkObjectResult(updatedItem);
            }
            catch (Exception e)
            {
                var result = new ObjectResult(e);
                result.StatusCode = StatusCodes.Status500InternalServerError;
                return result;
            }
        }
    }
}
