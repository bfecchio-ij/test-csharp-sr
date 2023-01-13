﻿using System;

namespace InfoJobs.KnowledgeTest.Domain.Core.Entities.Curriculum
{
    public sealed class CandidateExperienceEntity : BaseEntity
    {
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? ModifyDate { get; set; }

        public CandidateEntity Candidate { get; set; }
    }
}