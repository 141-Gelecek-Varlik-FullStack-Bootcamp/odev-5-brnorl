namespace odev3.Models.Pagination
{
    public class PaginationFilter
    {//Saylafama filtresi, belirlenen aralığın dışına çıkılmamasını sağlar,özelleştirilebilir.
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}