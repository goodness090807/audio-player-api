namespace DataAccessLayer.Utils
{
    public static class PaginationHelper
    {
        public static (int offset, int limit) GetOffsetAndLimit(int page, int pageSize)
        {
            return ((page - 1) * pageSize, pageSize);
        }
    }
}
