using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Models;

namespace MongoDB.ViewModel
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public IQueryable<EstiloMusical> EstilosMusicais { get; set; }

        public AlbumViewModel()
        {
        }
    }
}