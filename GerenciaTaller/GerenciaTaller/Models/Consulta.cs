using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaTaller.Models
{
    public class Consulta
    {
        private List<Familia> familias;

        public Consulta()
        {

        }

        public Consulta(List<Familia> _familia)
        {
            this.familias = _familia;
        }

        public List<Familia> GetFamilias()
        {
            return this.familias;
        }
    }
}