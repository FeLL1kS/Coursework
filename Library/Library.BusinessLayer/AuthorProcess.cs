using Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BusinessLayer
{
    public class AuthorProcess : IAuthorProcess
    {
        private static readonly IDictionary<int, AuthorDto> Authors = new Dictionary<int, AuthorDto>();

        public void Add(AuthorDto author)
        {
            int newId = Authors.Keys.Count == 0 ? 1 : Authors.Keys.Max(p => p) + 1;
            author.Id = newId;
            Authors.Add(newId ,author);
        }

        public void Delete(int id)
        {
            if(Authors.ContainsKey(id))
            {
                Authors.Remove(id);
            }
        }

        public AuthorDto Get(int id)
        {
            return Authors.ContainsKey(id) ? Authors[id] : null;
        }

        public IList<AuthorDto> GetList()
        {
            return new List<AuthorDto>(Authors.Values);
        }

        public void Update(AuthorDto author)
        {
            if(Authors.ContainsKey(author.Id))
            {
                Authors[author.Id] = author;
            }
        }
    }
}
