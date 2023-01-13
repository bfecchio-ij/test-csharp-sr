using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels
{
    public sealed class CandidateViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Surname is Required")]
        [MaxLength(150)]
        [DisplayName("Surname")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "The Birthdate is Required")]
        [DisplayName("Birthdate")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "The Email is Required")]
        [MaxLength(250)]
        [DisplayName("Email")]
        public string Email { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}