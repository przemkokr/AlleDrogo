using AlleDrogo.Domain.Entities.Base;

namespace AlleDrogo.Domain.Entities.User
{

    public class User : EntityBase
    {
        protected User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

    }
}
