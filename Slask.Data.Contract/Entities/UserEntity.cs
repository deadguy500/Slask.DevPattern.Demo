using System;

namespace Slask.Data.Contract.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
