namespace LibraryAC.Data.Entities
{
    public class Book
    {
        public string Type;
        public int Score;
        public bool IsBorrowed;
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
