namespace APIdemo.Model
{
    public class Users
    {
        public Guid _id { get; }
        public string firstname { get; } = string.Empty;
        public string lastname { get; } = string.Empty;
        public string email { get; } = string.Empty;
    

        public Users(
            Guid _id,
            string firstname,
            string lastname,
            string email)
        {
            this._id = _id;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;

        }

    }
}
