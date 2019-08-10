namespace Hospital.Domain.Entities
{
    public abstract class BaseEntity
    {
        #region Variables
        private int m_id;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return m_id;
            }
            set
            {
                m_id = value;
            }
        }
        #endregion
    }
}
