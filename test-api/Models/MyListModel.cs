using System.Collections.Generic;

namespace test_api.Models
{
    public class MyListSetModel
    {
        public int n { get; set; }
        public List<string> words { get; set; }
    }
    public class MyListGetModel
    {
        public int Id { get; set; }
        public string line { get; set; }
    }
}
