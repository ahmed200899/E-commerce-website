using System.Collections;
using System.Collections.Generic;

namespace API.Helpers
{
    public class paggination<T> where T : class
    {
        public paggination(int page_Number, int page_size, int count, IEnumerable<T> data)
        {
            this.page_Number = page_Number;
            this.page_size = page_size;
            Count = count;
            Data = data;
        }

        public int page_Number { get; set; }
        public int page_size { get; set; }

        public int Count { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}