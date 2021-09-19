﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo

{
    public class Marca
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public Marca(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public Marca(string descripcion)
        {
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
