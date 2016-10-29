﻿using System;
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

    }
}
