using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.BLL
{
    public class ToDoItemManager
    {
        private readonly ToDoListDbContext context;

        public ToDoItemManager(ToDoListDbContext context)
        {
            this.context = context;
        }

        public ToDoItem AddItem(AddItemDTO itemData)
        {
            ToDoItem newItem = new ToDoItem
            {
                CreatedAt = System.DateTime.Now,
                Description = itemData.Description,
                State = ItemState.New
            };

            context.Add(newItem);
            context.SaveChanges();
            return newItem;
        }

        public async Task<List<ToDoItem>> GetAllItemsAsync()
        {
            return await context.ToDoItemData.ToListAsync();
        }

        public async Task<ToDoItem> GetItemAsync(int id)
        {
            return await context.ToDoItemData.FindAsync(id);
        }

        public async Task<ToDoItem> UpdateItemAsync(int id, UpdateItemDTO updateItemDTO)
        {
            var itemToUpdate = await GetItemAsync(id);
            if (itemToUpdate == null)
                return null;
            itemToUpdate.Description = updateItemDTO.NewDescription;
            itemToUpdate.State = updateItemDTO.NewState;
            await context.SaveChangesAsync();

            return itemToUpdate;
        }

        public async Task<ToDoItem> RemoveItemAsync(int id)
        {
            var itemToRemove = await GetItemAsync(id);
            if (itemToRemove == null)
                return null;
            context.Remove(itemToRemove);
            await context.SaveChangesAsync();

            return itemToRemove;
        }
    }
}
