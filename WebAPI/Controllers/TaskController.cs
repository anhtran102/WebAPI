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
                Subject = "Project Task 1",
                Id = 2                
            },
            new AssigmentTask(){
               CompletedDate = new DateTime(2013, 4, 4),
                CreatedDate = new DateTime(2013, 4, 2),
                DueDate = new DateTime(2016, 4, 22),
                StartDate = new DateTime(2016, 4, 7),
                Status = 1,
                Subject = "Finish Homework",
                Id = 1,
            },
            new AssigmentTask(){
               CompletedDate = new DateTime(2015, 4, 4),
                CreatedDate = new DateTime(2014, 2, 2),
                DueDate = new DateTime(2016, 12, 12),
                StartDate = new DateTime(2016, 11, 11),
                Status = 1,
                Subject = "Selft Study",
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
                   FirstName = "Member 2",
                   LastName="Let",
                   UserId=2,
                   UserName = "user2"
               }
            };

        #endregion

        IList<Assignment> Assignments = new List<Assignment>()
        {
            new Assignment(){
                AssignedDate = DateTime.Now,                
                TaskId = 1,
                UserId = 1
            },   
            new Assignment(){
                AssignedDate = DateTime.Now,                
                TaskId = 1,
                UserId = 2
            },
            new Assignment(){
                AssignedDate = DateTime.Now,                
                TaskId = 2,
                UserId = 2
            }   
        };


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
        //[Route("{id}")]                
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
        [Route("{id}/user")]
        [HttpGet]
        public IEnumerable<User> UsersOfTask(int id)
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

        // POST: api/Task
        [HttpPost]
        public AssigmentTask Post(AssigmentTask task)
        {            
            if(task!= null)
            {
                Tasks.Add(task);
                task.Id = 4;
                task.CreatedDate = DateTime.Now;
                task.CompletedDate = task.DueDate;
                return task;
            }
            else
            {
                throw new ArgumentException("Task can not be null");
            }
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
        public IEnumerable<AssigmentTask> Delete(int id)
        {
            foreach (var item in Tasks)
            {
                if (item.Id == id)
                {
                    Tasks.Remove(item);
                    break;
                }
            }

            return this.Tasks;
        }
    }
}
