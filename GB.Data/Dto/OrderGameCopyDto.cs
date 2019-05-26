namespace GB.Data.Dto
{
    //!  Klasa DTO OrderGameCopy. 
    /*!
       Klasa, która służy do transferu danych modelu OrderGameCopy pomiędzy warstwą MVC a Api.
    */
    public class OrderGameCopyDto
    {
        public int ID { get; set; }
        public int GameCopyID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
}