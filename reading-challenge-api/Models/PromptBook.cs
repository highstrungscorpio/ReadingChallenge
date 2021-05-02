using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingChallengeApi.Models
{
    public class PromptBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public Book BookRead { get; set; }

        public DateTime DateRead { get; set; }

        public List<Prompt> Prompts { get; set; }
    }
}
