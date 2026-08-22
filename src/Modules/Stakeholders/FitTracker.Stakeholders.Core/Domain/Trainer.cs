using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Stakeholders.Core.Domain
{
    public class Trainer : User
    {
        public List<Trainee> Trainees { get; private set; } = new();
        public Trainer(string username, string email, string hashedPassword)
            : base(username, email, hashedPassword, UserRole.Trainer)
        {
        }

        public void AddTrainee(Trainee trainee)
        {
            if (!Trainees.Contains(trainee))
            {
                Trainees.Add(trainee);
                trainee.AssignTrainer(this);
            }
        }

        public void RemoveTrainee(Trainee trainee)
        {
            if (Trainees.Contains(trainee))
            {
                Trainees.Remove(trainee);
                trainee.RemoveTrainer(this);
            }
        }
    }
}
