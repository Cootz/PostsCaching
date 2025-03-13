using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostsCaching.Models.Db
{
    public class Post : IPost
    {
        public int Id { get; init; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        public required string Author { get; set; }

        public required string Content { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]       
        public DateTime CreationDate { get; init; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }
}