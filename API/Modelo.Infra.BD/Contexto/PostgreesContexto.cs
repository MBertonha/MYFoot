using Microsoft.EntityFrameworkCore;
using Modelo.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Runtime.Session;

namespace Modelo.Infra.BD.Contexto
{
    public class PostgreesContexto : MyFootContexto
    {
        public PostgreesContexto(DbContextOptions<MyFootContexto> options, ITnfSession session) : base(options, session)
        {
        }
    }
}
