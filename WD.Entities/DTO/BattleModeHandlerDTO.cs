using System;
using System.Collections.Generic;
using System.Text;

namespace WD.Entities.DTO
{
    public class BattleModeHandlerDTO
    {
        // public string PlayId { get; set; }
        public int Life { get; set; }
        public int BattleLife { get; set; }
        public int Strength { get; set; }
        public int BattleStrength { get; set; }
        public bool BattleMode { get; set; }

        // public LocationCoords Location { get; set; }

        public BattleModeHandlerDTO(int life, int battleLife, int strength, int battleStrength,bool battleMode)
        {
            Life = life;
            BattleLife = battleLife;
            Strength = strength;
            BattleStrength = battleStrength;
            BattleMode = battleMode;
        }
    }


}
