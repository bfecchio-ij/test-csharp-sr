﻿namespace InfoJobs.KnowledgeTest.UI.Web.ApiHelper.ViewModels.Curriculum
{
    public sealed class CandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Email { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}