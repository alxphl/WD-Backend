using MongoDB.Bson;
using System;

namespace WD.Entities
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string PlayId { get; set; }
        public string Token { get; set; }
        public double WinRate { get; set; }
        public double LostRate { get; set; }
        public int Losses { get; set; }
        public int Wins { get; set; }
        public int WorldDominationRank { get; set; }
        public TearEnum Tear { get; set; }
        public double Bank { get; set; }
        public int BattleLife { get; set; }
        public int Life { get; set; }

        public int BattleStrength { get; set; }
        public int Strength { get; set; }
        public bool BattleMode { get; set; }
        public LocationCoords Location { get; set; }

        public User(string id)
        {
            PlayId = id;
            WinRate = 50;
            LostRate = 50;
            Wins = 0;
            Losses = 0;
            Tear = TearEnum.None;
            Bank = 0;
            BattleLife = 0;
            Life = 10;
            BattleStrength = 0;
            Strength = 0;
            Token = "";
            BattleMode = false;
        }
    }

    public enum TearEnum
    {
        None = 0,
        Silver = 1,
        Gold = 2,
        Platinum = 3,
    }

    public class LocationCoords
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
