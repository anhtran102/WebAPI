using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/task")]
    public class TaskController : ApiController
    {
        #region Init
        IList<AssigmentTask> Tasks = new List<AssigmentTask>
        {
            new AssigmentTask(){
                CompletedDate = new DateTime(2016, 2, 4),
                CreatedDate = new DateTime(2016, 1, 4),
                DueDate = new DateTime(2016, 4, 4),
                StartDate = new DateTime(2016, 1, 7),
                Status = 1,
                Subject = "New task",
                Id = 2                
            },
            new AssigmentTask(){
               CompletedDate = new DateTime(2013, 4, 4),
                CreatedDate = new DateTime(2013, 4, 2),
                DueDate = new DateTime(2016, 4, 22),
                StartDate = new DateTime(2016, 4, 7),
                Status = 1,
                Subject = "New task2",
                Id = 1,
            },
            new AssigmentTask(){
               CompletedDate = new DateTime(2015, 4, 4),
                CreatedDate = new DateTime(2014, 2, 2),
                DueDate = new DateTime(2016, 12, 12),
                StartDate = new DateTime(2016, 11, 11),
                Status = 1,
                Subject = "New task2",
                Id = 3,
            }            
        };

        IList<User> Users = new List<User>(){
               new User(){
                   FirstName = "Anh",
                   LastName="Tran",
                   UserId=1,
                   UserName = "administrator"
               },
                 new User(){
                   FirstName = "Anh2",
                   LastName="Tran2",
                   UserId=2,
                   UserName = "anhtran"
               }
            };

        #endregion

        IList<Assignment> Assignments = new List<Assignment>();

        // GET: api/Task\
        /// <summary>
        /// Get task collection
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        public IEnumerable<AssigmentTask> Get()
        {                        
            return this.Tasks;
        }

        // GET: api/Task/5
        /// <summary>
        /// Get task based on Task Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]        
        [HttpGet]
        public AssigmentTask Get(int id)
        {
            return Tasks.Where(t => t.Id == id).FirstOrDefault();
        }

        // GET: api/Task/id/users
        /// <summary>
        /// Get users assigned to task
        /// </summary>
        /// <returns></returns>
        //[RouteAttribute("Task/id/user")]
        [Route("{id}/user/{cid}")]
        [HttpGet]
        public IEnumerable<User> UsersOfTask(int id, int cid)
        {
            var task = Tasks.Where(t => t.Id == id).FirstOrDefault();
            var assigments = Assignments.Where(a => task != null && a.TaskId == task.Id).ToList();
            //var users = from assigment in assigments
            //            join user in Users on assigment.UserId equals user.UserId
            //            where assigment.TaskId == id
            //            select user;

            var us = Users.Join(assigments, user=>user.UserId, assign=>assign.UserId, (u, a) => u);

            return us;
            
        }

        // GET: api/Task/id/users
        /// <summary>
        /// Get users assigned to task
        /// </summary>
        /// <returns></returns>
        //[RouteAttribute("Task/id/user")]
        [Route("{id}/user")]
        [HttpGet]
        public string UsersOfTask2(int id)
        {            

            return "jjj";

        }

        // POST: api/Task
        [HttpPost]
        public void Post(AssigmentTask task)
        {
            var newTask = new AssigmentTask()
            {
                CompletedDate = DateTime.Now.AddDays(19),
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(12),
                StartDate = DateTime.Now.AddDays(5),
                Status = 1,
                Subject = "New task2"
            };

            newTask.Id = 4;
            Tasks.Add(newTask);            
            //return newTask;
        }

        // PUT: api/Task/5
        [HttpPut]
        public AssigmentTask Put(int id, AssigmentTask updateTask)
        {           
            foreach (var item in Tasks)
            {
                if (item.Id == id)
                {
                    item.CompletedDate = updateTask.CompletedDate;
                    item.CreatedDate = updateTask.CreatedDate;
                    item.DueDate = updateTask.DueDate;
                    item.StartDate = updateTask.StartDate;
                    item.Status = updateTask.Status;
                    item.Subject = updateTask.Subject;
                    item.Id = updateTask.Id;
                }

                return item;
            }

            return updateTask;
        }

        // DELETE: api/Task/5
        [HttpDelete]
        public void Delete(int id)
        {
            foreach (var item in Tasks)
            {
                if (item.Id == id)
                {
                    Tasks.Remove(item);
                }
            }
        }
    }
}
