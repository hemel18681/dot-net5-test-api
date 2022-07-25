using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_api.Models;
using test_api.UserDataContext;

namespace test_api.Controllers
{
    [ApiController]
    [Route("MyList")]
    public class MyList : ControllerBase
    {
        private readonly dbContext _context;

        public MyList(dbContext Context)
        {
            _context = Context;
        }

        [HttpPost]
        [Route("SetData")]

        public IActionResult SetData(MyListSetModel mydata)
        {
            int len = 0;
            string line = "";
            for (int i = 0; i < mydata.words.Count; i++)
            {
                if (len < mydata.n)
                {
                    line += mydata.words[i];
                    line += " ";
                    len++;
                }
                if (len == mydata.n)
                {
                    MyListGetModel data = new MyListGetModel();
                    data.line = line;
                    _context.mylines.Add(data);
                    _context.SaveChanges();
                    len = 0;
                    line = "";
                }
            }
            if (line.Length != 0)
            {
                MyListGetModel data = new MyListGetModel();
                data.line = line;
                _context.mylines.Add(data);
                _context.SaveChanges();
            }

            return Ok("");
        }

        [HttpGet]

        [Route("GetData")]
        public IActionResult GetData()
        {
            var data = _context.mylines.ToList();
            return Ok(data);
        }

    }
}
