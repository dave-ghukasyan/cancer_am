namespace CancerAM.DAL.Entities
{
    public partial class Author
    {
        public Author()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        
        public string Password { get; set; }

        public bool IsSuperuser { get; set; }

        public bool IsActive { get; set; }

        #endregion

        #region Generated Relationships
        #endregion

    }
}
