using DataAcessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibrary
{
    public class CardDetails : ICardDetails
    {
        private readonly ISQLDataAcess db;

        public CardDetails(ISQLDataAcess db)
        {
            this.db = db;
        }

        public Task<List<CardModel>> GetCards()
        {
            string sql = "select * from dbo.CARD";

            return db.LoadData<CardModel, dynamic>(sql, new { });
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "SELECT * FROM  dbo.UserData";
            return db.LoadData<UserModel, dynamic>(sql, new { });
        }


        public Task InsertCard(CardModel card)
        {
            string sql = @"insert into dbo.CARD(AgencyId, InoviceId, CustomeId, CustomerName)
                            values(@AgencyId, @InoviceId, @CustomeId, @CustomerName);";

            return db.SaveData(sql, card);
        }
    }
}
