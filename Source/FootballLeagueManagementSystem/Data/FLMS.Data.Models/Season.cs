namespace FLMS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class Season
    {
        [Key]
        public int Id { get; set; }

        public DateTime Year { get; set; }
    }
}