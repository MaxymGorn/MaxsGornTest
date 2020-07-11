using Business_Logic_Layer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Interfaces
{
    public interface ISoundService
    {
        Task MakeSoundAsync(SoundDTO soundDTO);
        Task MakeUserAsync(UserDTO userDTO);
        Task DeleteSoundAsync(SoundDTO soundDTO);
        Task DeleteUser(UserDTO userDTO);
        UserDTO GetUser(int? id);
        SoundDTO GetSound(int? id);
        IEnumerable<SoundDTO> GetSounds();
        IEnumerable<UserDTO> GetUsers();
        Task UpdateSound(SoundDTO soundDTO);
        void Dispose();
    }
}
