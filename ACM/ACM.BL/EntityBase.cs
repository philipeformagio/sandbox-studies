namespace ACM.BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }

    public abstract class EntityBase
    {
        public bool IsNew { get; set; }
        public bool HasChanges { get; set; }
        public EntityStateOption EntityState { get; set; }
        public bool IsValid 
        { 
            get 
            { 
                return Validate(); 
            } 
        }

        public abstract bool Validate();
    }
}
