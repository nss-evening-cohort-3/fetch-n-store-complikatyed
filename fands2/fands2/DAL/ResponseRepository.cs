using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using fands2.Models;

namespace fands2.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context { get; set; }

        public ResponseRepository()
        {
            Context = new ResponseContext();
        }

        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }

        public void AddResponse(Response response)
        {
            Context.Responses.Add(response);
            Context.SaveChanges();
        }

        public List<Response> GetResponses()
        {
            return Context.Responses.ToList();
        }

        public Response GetResponseById(int id)
        {
            Response selected_response = Context.Responses.First(r => r.ResponseId == id);
            return selected_response;

        }


    }
}
