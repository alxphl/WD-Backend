using System;
using System.Collections.Generic;
using System.Text;

namespace WD.Entities.DTO
{
    public class SignDTO
    {
        public string PlayId { get; set; }
        public SignDTO(string playId)
        {
            PlayId = playId;
        }
    }
}
