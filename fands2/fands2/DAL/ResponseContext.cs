﻿using fands2.Models;
using System.Data.Entity;

namespace fands2.DAL
{
    public class ResponseContext : DbContext
    {
        public virtual DbSet<ResponseModel> ResponseModels { get; set; }
    }
}