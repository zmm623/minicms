using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ikende.minicms.web.Service.Model;
using Peanut;

namespace ikende.minicms.web.Service
{
    public class BlockService : Interfaces.IBlockService
    {
        public BlockService()
        {
            Cached = new Service.Cached();
        }
        public IList<Model.TextBlock> List(int pageindex, int pagesize, out int count)
        {
            Peanut.Expression exp = new Peanut.Expression();
            count = exp.Count<TextBlock>();
            int size = 20;
            return exp.List<TextBlock>(new Region(pageindex, size));


        }

        public void Delete(string id)
        {
            (TextBlock.iD == id).Delete<TextBlock>();
        }

        public TextBlock Get(string id)
        {
            return Cached[id].Get<TextBlock>(() =>
            {
                return (TextBlock.iD == id).ListFirst<TextBlock>();
            });
        }

        public TextBlock GetByTitle(string title)
        {
            return (TextBlock.iD == title).ListFirst<TextBlock>();

        }

        public TextBlock Edit(string id, string title, string data)
        {
            TextBlock block = Get(id);
            if (block == null)
                block = new TextBlock();
            block.Title = title;
            block.Content = data;
            block.Save();
            Cached.Remove<TextBlock>(id);
            return block;
        }


        public Interfaces.ICached Cached
        {
            get;
            set;
        }
    }
}