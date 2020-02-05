using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace WD.Entities.DTO
{
    public class BattleModeDTO
    {
        public string PlayId { get; set; }
        public int BattleLife { get; set; }
        public int BattleStrength { get; set; }
        public bool BattleMode { get; set; }

        public LocationCoords Location { get; set; }
    }


}
