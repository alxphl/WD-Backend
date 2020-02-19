using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace WD.Entities.DTO
{
    public class UserDTO 
    {
        public string Token { get; set; }
        public double WinRate { get; set; }
        public double LostRate { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
        public int WorldDominationRank { get; set; }
        public TearEnum Tear { get; set; }
        public double Bank { get; set; }
        public int Life { get; set; }
        public int Strength { get; set; }

        public UserDTO(string token, double winRate, double lostRate, int losses, int wins, int worldDominationRank, TearEnum tear, double bank, int life, int strength)
            {
                Token = token;
                WinRate = winRate;
                LostRate = lostRate;
                Wins = wins;
                Losses = losses;
                WorldDominationRank = worldDominationRank;
                Tear = tear;
                Bank = bank;
                Life = life;
                Strength = strength;

            }
    }
}
