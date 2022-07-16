using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class UserManagementService
    {
        MakeupApiContext db = new MakeupApiContext();

        public List<UserDto> GetAll()
        {


         
            List<UserDto> usersDto = null;
            using (var x = new MakeupApiContext())
            {
                usersDto = x.Users
                    .Select(c => new UserDto()
                    {
                        Id = c.Id,
                        Username = c.Username,
                        Role = c.Role

                    })
                    .ToList<UserDto>();



            }
            return usersDto;

        }

      


        public UserDto GetById(int id)
        {
            UserDto userDto = new UserDto();

          

            using (var x = new MakeupApiContext())
            {
                userDto = x.Users
                    .Where(i => i.Id == id)
                    .Select(c => new UserDto()
                    {
                        Id = c.Id,
                        Username = c.Username,
                        Role=c.Role
                    }).FirstOrDefault();
            }
            return userDto;
        }

        public UserDto Save(UserDto userDto)
        {
            using (var x = new MakeupApiContext())
            {
                x.Users.Add(new User()
                {
                    Username = userDto.Username,
                    Role = userDto.Role
                });
                x.SaveChanges();
            }
            return userDto;


           

        }


        public bool Delete(int id)
        {
            if (id == 0) return false;

            try
            {

                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
