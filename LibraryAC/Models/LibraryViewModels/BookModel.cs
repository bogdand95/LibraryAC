namespace LibraryAC.Models.LibraryViewModels
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; internal set; }
        public int NumberOfCopies { get; internal set; }

        public bool IsBorrowedByMe;
    }
}