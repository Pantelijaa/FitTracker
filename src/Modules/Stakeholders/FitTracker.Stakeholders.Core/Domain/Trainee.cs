using System;
using System.Collections.Generic;
using System.Text;

namespace FitTracker.Stakeholders.Core.Domain
{
    public class Trainee : User
    {
        public Trainer? Trainer { get; private set; }
        public Trainee(string username, string email, string hashedPassword)
            : base(username, email, hashedPassword, UserRole.Trainee)
        {
        }

        public void AssignTrainer(Trainer trainer)
        {

            Trainer = trainer;
            trainer.AddTrainee(this);
        }

        public void RemoveTrainer(Trainer trainer)
        {
            if (Trainer != null && Trainer.Equals(trainer))
            {
                Trainer = null;
                trainer.RemoveTrainee(this);
            }
        }
    }
}
