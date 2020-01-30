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
        public int WorldDominationRank { get; set; }
        public TearEnum Tear { get; set; }
        public double Bank { get; set; }
        public int BattleCoins { get; set; }
        public int Coins { get; set; }

        public User(string id)
        {
            PlayId = id;
            WinRate = 50;
            LostRate = 50;
            Tear = TearEnum.None;
            Bank = 0;
            BattleCoins = 0;
            Coins = 10;
            Token = "";


        }
    }

    public enum TearEnum
    {
        None = 0,
        Silver = 1,
        Gold = 2,
        Platinum = 3,
    }
}
