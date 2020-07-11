using AutoMapper;
using Business_Logic_Layer.DTO;
using Business_Logic_Layer.Infrastructure;
using Business_Logic_Layer.Interfaces;
using Data_Access_Layer.Interfaces;
using MaxsGornTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Business_Logic_Layer.Services
{
    public class SoundService : ISoundService
    {
        IUnitOfWork Database { get; set; }
        public SoundService(IUnitOfWork uow)
        {
            Database = uow;
            //k++;
            //MessageBox.Show(k.ToString());
        }
        //static int k=0;
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<SoundDTO> GetSounds()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sound, SoundDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Sound>, List<SoundDTO>>(Database.Sounds.GetAll());
        }
        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(Database.Users.GetAll());
        }

        public SoundDTO GetSound(int? id)
        {
            if (id == null)
                throw new ValidationException("Sound dont founded!", "");
            var sound = Database.Sounds.Get(id.Value);
            if (sound == null)
                throw new ValidationException("Sound dont founded!", "");

            return new SoundDTO { id = id.Value, DateStart = sound.DateStart, Duration = sound.Duration, FileNameUrl = sound.FileNameUrl, UserId = sound.UserId };
        }
        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Id dont founded!", "");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("User dont founded!", "");

            return new UserDTO { value = user.value, id = user.id };
        }

        public async Task MakeSoundAsync(SoundDTO soundDTO)
        {
            if (soundDTO == null)
                throw new ValidationException("Sound is null!", "");
            Database.Sounds.Create(new Sound() { DateStart = soundDTO.DateStart, UserId = soundDTO.UserId, Duration = soundDTO.Duration, FileNameUrl = soundDTO.FileNameUrl });
            Database.Save();
        }
        public async Task MakeUserAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ValidationException("User is null!", "");
            Database.Users.Create(new User() { value = userDTO.value });
             Database.Save();
        }

        public async Task DeleteSoundAsync(SoundDTO soundDTO)
        {
            if (soundDTO == null)
                throw new ValidationException("Sound is null!", "");
            await Database.Sounds.DeleteAsync(soundDTO.id);
            await Database.SaveAsync();
        }

        public async Task DeleteUser(UserDTO userDTO)
        {
            if (userDTO == null)
                throw new ValidationException("User is null!", "");
            await Database.Users.DeleteAsync(userDTO.id);
            await Database.SaveAsync();
        }
       public async Task UpdateSound(SoundDTO soundDTO)
       {
            if (soundDTO == null)
                throw new ValidationException("Sound is null!", "");
            Database.Sounds.UpdateAsync(new Sound() { id = soundDTO.id, DateStart = soundDTO.DateStart, UserId = soundDTO.UserId, Duration = soundDTO.Duration, FileNameUrl = soundDTO.FileNameUrl });
            await Database.SaveAsync();
       }
    }
}
