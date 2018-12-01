namespace TermManager.Models
{
    public class TermRepository
    {
        public Term UpdateTerm(Term model)
        {
            string sql = @"
                Update Terms 
                Set
                    Title = @Title,
                    Description = @Description
                Where Id = @Id
            ";

            return model;
        }
    }
}
