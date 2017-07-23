using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Domain
{
    public class PagingModel<T>  where T : class
    {
        public IList<T> Items { get; set; }

        private int _pageCount;

        public int PageCount
        {
            get { return _pageCount; }
        }

        private int _totalRecords;

        public int TotalRecords
        {
            get { return _totalRecords; }
        }

        private int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
        }

        public PagingModel(int totalRecordCount, int recordPerPage, int position )
        {
            this._totalRecords = totalRecordCount;
            recordPerPage = recordPerPage == 0 ? 1 : recordPerPage;
            this._pageCount = Convert.ToInt32(Math.Ceiling((decimal)totalRecordCount / (decimal)recordPerPage));
            this._currentPage = Convert.ToInt32(Math.Ceiling((decimal)(position + 1) / recordPerPage));
        }


    }
}
