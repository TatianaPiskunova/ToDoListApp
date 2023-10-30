using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using ToDoListApp.EF;
using ToDoListApp.Models;


namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext db;
        private ITaskToDoService _taskToDoService;




        public HomeController(ILogger<HomeController> logger, ApplicationContext context, ITaskToDoService taskToDoService)
        {
            _logger = logger;
            db = context;
            _taskToDoService= taskToDoService;
         
        }

        public IActionResult Index()
        {
            
            return View(GetListTask());
        }

        public IActionResult ShowTable()
        {
           
            return PartialView(GetListTask());
        }

        public List<TaskToDo> GetListTask()
        {
            var JsonString = _taskToDoService.GetAll();
            List<TaskToDo> tasks = new();
            dynamic arr = JsonConvert.DeserializeObject(JsonString);
            foreach (var taskToDo in arr)
            {
                var tmpTask = new TaskToDo()
                {
                    TaskId = taskToDo.TaskId,
                    Title = taskToDo.Title,
                    Description = taskToDo.Description,
                    DueDate = taskToDo.DueDate,
                    IsDone = taskToDo.IsDone,
                    IsDel = taskToDo.IsDel
                };
                tasks.Add(tmpTask);
            }

            return tasks;
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            var vm = new AddTaskViewModel();
            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult AddTask(AddTaskViewModel vm)
        {
                _taskToDoService.AddNewTask(vm);
                return PartialView("ShowTable", GetListTask());

        }
      
        [HttpGet]
        public IActionResult DelTask(int id)
        {
           _taskToDoService.DeleteById(id);
            return PartialView("ShowTable", GetListTask());
        }
        [HttpGet]
        public IActionResult FinishTask(int id)
        {
            _taskToDoService.FinishTask(id);
            return PartialView("ShowTable", GetListTask());
        }


        [HttpGet]
        public IActionResult UpdateTask(int id)
        {
            var tmp=_taskToDoService.FindById(id);
            var vm = new UpdateTaskViewModel { 
                Id=tmp.TaskId, 
                Title=tmp.Title,
                Description=tmp.Description,
                           
            };

            return PartialView(vm);
        }

        [HttpPost]
        public IActionResult UpdateTask(UpdateTaskViewModel vm)
        {
            _taskToDoService.UpdateTask(vm);
            return PartialView("ShowTable", GetListTask());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

           }
}