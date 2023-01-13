using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InfoJobs.KnowledgeTest.Application.Curriculum.ViewModels
{
    public sealed class CandidateExperienceViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The IdCandidate is Required")]
        [DisplayName("IdCandidate")]
        public int IdCandidate { get; set; }

        [Required(ErrorMessage = "The Company is Required")]
        [MaxLength(100)]
        [DisplayName("Company")]
        public string Company { get; set; }

        [Required(ErrorMessage = "The Job is Required")]
        [MaxLength(100)]
        [DisplayName("Job")]
        public string Job { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MaxLength(4000)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Salary is Required")]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "The BeginDate is Required")]
        [DisplayName("BeginDate")]
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}