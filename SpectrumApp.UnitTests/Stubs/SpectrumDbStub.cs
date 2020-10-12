using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using SpectrumApp;

namespace SpectrumApp.UnitTests.Stubs
{
    public class SpectrumDbStub : IDataStore<User>
    {
        private List<User> userRepo; 
             
        public SpectrumDbStub()
        {
            userRepo = new List<User>();
        }

        public Task<int> AddUpdateUserAsync(User user)
        {
            var task = new Task<int>(() =>
            {
                if(userRepo.Contains(user))
                {
                    userRepo.Remove(user);
                }

                userRepo.Add(user);
                return 1;
            });
            task.Start();
            return task;
        }

        public Task<int> DeleteUserAsync(User user)
        {
            var task = new Task<int>(() =>
            {
                return 0;
            });
            task.Start();
            return task;
        }

        public Task<int> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindUserAsync(string username)
        {
            var task = new Task<User>(() =>
            {
                return new Fixture().Create<User>();
            });
            task.Start();
            return task;
        }

        public Task<User> GetUserAsync(int id)
        {
            var task = new Task<User>(() =>
            {
                return new Fixture().Create<User>();
            });
            task.Start();
            return task;
        }

        public Task<List<User>> GetUsersAsync()
        {
            var task = new Task<List<User>>(() =>
            {
                return userRepo;
            });

            task.Start();
            return task;
        }
    }
}
