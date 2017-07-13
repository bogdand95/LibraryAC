using LibraryAC.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAC.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}