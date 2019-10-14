using System;
using System.Net.Http;
using lab_48_api_todo_list_core; //reference classes from other projects
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace lab_48_read_api
{
    class Program
    {
        static string url = "https://localhost:44305/api/TaskItems/";
        static HttpClient client = new HttpClient();
        static TaskItem taskItem = null;
        static List<TaskItem> taskItems = new List<TaskItem>();

        static void Main(string[] args)
        {
            //Displays all the database items
            GetTaskItemsAsync().Wait();
            DisplayTaskItems();
            Console.WriteLine("");

            //Displays one of the database items
            GetTaskItemsAsync(2).Wait();
            DisplayTaskItem();
            Console.WriteLine("");

            ////creates and adds a new item into the database
            //var t = new TaskItem
            //{
            //    Description = "New Task",
            //    TaskDone = false,
            //    DateDue = DateTime.Parse("12/12/2019"),
            //    UserId = 2,
            //    CategoryId = 1
            //};
            //TaskItem newItem = PostNewTaskItemAsync(t).Result;
            //Console.WriteLine($"New Task created with ID: {newItem.TaskItemId}");
            //Console.WriteLine("");

            //updates an existing item into the database 
            //TaskItem itemToUpdate = UpdateTaskItemAsync(2).Wait();
            //Console.WriteLine($"Task with ID: {itemToUpdate} has been updated");
            UpdateTaskItemAsync(2, "This is changed").Wait();
            GetTaskItemsAsync().Wait();
            DisplayTaskItems();

            ////deletes an existing item from the database 
            //TaskItem itemToDelete = DeleteTaskItemAsync(5).Result;
            //Console.WriteLine($"Task with ID: {itemToDelete.TaskItemId} has been deleted");
            //GetTaskItemsAsync().Wait();
            //DisplayTaskItems();
        }

        static async Task GetTaskItemsAsync()
        {
            Console.WriteLine("Getting all task items... ");
            
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //raw json string
                var responseString = await response.Content.ReadAsStringAsync();
                //uses newtonsoft to deserialise string into list of taskitems
                taskItems = JsonConvert.DeserializeObject<List<TaskItem>>(responseString);
            }
        }
        static void DisplayTaskItems()
        {
            taskItems.ForEach(t => {
                Console.WriteLine(
$"{t.TaskItemId,-10}, {t.Description,-30}, {t.TaskDone,-10}, {t.DateDue}");
            });
        }

        static async Task GetTaskItemsAsync(int i)
        {
            Console.WriteLine($"Getting task item {i}... ");

            var response = await client.GetAsync(url + i);
            if (response.IsSuccessStatusCode)
            {
                //raw json string
                var responseString = await response.Content.ReadAsStringAsync();
                //uses newtonsoft to deserialise string into list of taskitems
                taskItem = JsonConvert.DeserializeObject<TaskItem>(responseString);
            }
        }
        static void DisplayTaskItem()
        {
            Console.WriteLine( $"{taskItem.TaskItemId,-10}, {taskItem.Description,-30}, {taskItem.TaskDone,-10}, {taskItem.DateDue}");
        }

        static async Task<TaskItem> PostNewTaskItemAsync(TaskItem t)
        {

            var taskItemString = JsonConvert.SerializeObject(t);//  tun it into a string
            var taskItemHttp = new StringContent(taskItemString);// turn it into a http request
            taskItemHttp.Headers.ContentType.MediaType = "application/json";
            taskItemHttp.Headers.ContentType.CharSet = "UTF-8";
            var response = await client.PostAsync(url, taskItemHttp);// waits for the response from the client

            var newItemsJson = response.Content.ReadAsStringAsync(); // reads the response as a string
            var newItemTask = JsonConvert.DeserializeObject<TaskItem>(newItemsJson.Result);// turns the response into a json

            return newItemTask;// returns the new item created 
        }

        static async Task<TaskItem> DeleteTaskItemAsync(int i)
        {
            var response = await client.DeleteAsync(url + i);

            var newItemsJson = response.Content.ReadAsStringAsync(); // reads the response as a string
            var itemTaskBeingDeleted = JsonConvert.DeserializeObject<TaskItem>(newItemsJson.Result);// turns the response into a json

            return itemTaskBeingDeleted;
        }

        static async Task UpdateTaskItemAsync(int i, string newDescription)
        {
            GetTaskItemsAsync(i).Wait();

            taskItem.Description = newDescription;

            var taskItemString = JsonConvert.SerializeObject(taskItem);//  tun it into a string
            var taskItemHttp = new StringContent(taskItemString);// turn it into a http request
            taskItemHttp.Headers.ContentType.MediaType = "application/json";
            taskItemHttp.Headers.ContentType.CharSet = "UTF-8";
            var response = await client.PutAsync((url+i), taskItemHttp);// waits for the response from the client

            var newItemsJson = response.Content.ReadAsStringAsync(); // reads the response as a string
            var itemToUpdate = JsonConvert.DeserializeObject<TaskItem>(newItemsJson.Result);// turns the response into a json

        }
    }
}
