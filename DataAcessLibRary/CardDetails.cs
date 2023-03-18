using DataAcessLibRary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLibRary
{
    internal class CardDetails
    {
        private readonly ISQLDataAcess db;

        public CardDetails(ISQLDataAcess db)
        {
            this.db = db;
        }

        public Task<List<CardModel>> GetCards()
        {
            string sql = "select * from dbo.cardDetailes";
        }
    }
}
