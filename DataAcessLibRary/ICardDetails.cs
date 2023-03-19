using DataAcessLibrary.Models;

namespace DataAcessLibrary
{
    public interface ICardDetails
    {
        Task<List<CardModel>> GetCards();
        Task InsertCard(CardModel card);
    }
}