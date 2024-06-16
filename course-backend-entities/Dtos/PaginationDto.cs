using System.ComponentModel.DataAnnotations;

namespace course_backend_entities.Dtos
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        private int _recordsPerPage = 10;
        private readonly int _maxAmountRecordsPerPage = 50;
        public int RecordsPerPage
        {
            get { return _recordsPerPage; }
            set 
            { 
                _recordsPerPage = (value > _maxAmountRecordsPerPage) ? _maxAmountRecordsPerPage : value; 
            }
        }

    }
}
