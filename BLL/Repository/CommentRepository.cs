﻿using BLL.Entity;
using System.Linq;
using System.Data.Entity;

namespace BLL.Repository
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(SqlDbContext sqlDbContext) : base(sqlDbContext) { }

        public override Comment Find(int id)
        {
            return sqlDbContext.Comments.Where(c => c.Id == id)
                .Include(c => c.Author.PersonalData).Include(c => c.Replys).SingleOrDefault();
        }
    }
}
