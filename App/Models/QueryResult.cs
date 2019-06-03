using System.Collections.Generic;

namespace App.Models
{
    public class QueryResult
    {
        public string Query { get; set; }
        public IEnumerable<dynamic> Values { get; set; }
        public bool IsCorrect { get; set; } = true;
    }
}