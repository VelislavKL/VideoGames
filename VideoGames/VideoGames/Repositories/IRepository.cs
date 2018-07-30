using System.Collections.Generic;
using video_games.Models;

namespace video_games.Repositories
{
    /// <summary>
    /// Интерфейс за работа с хранилища с филми
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Връща списък с всички игри.
        /// </summary>
        ///
        /// <returns>всички игри</returns>
        IEnumerable<Games> GetGames();

        /// <summary>
        /// Връща игра по задеден идентификатор
        /// </summary>
        ///
        /// <param name="ID">идентификаторът</param>
        ///
        /// <returns>играта</returns>
        Games FindById(int ID);

        /// <summary>
        /// Добавя нова игра.
        /// </summary>
        ///
        /// <param name="game">играта, който ще бъде добавен</param>
        void Add(Games game);

        IEnumerable<Games> SearchWord(string searchName);

        void DeleteAll();
    }
}
