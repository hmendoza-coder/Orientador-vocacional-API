using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrientadorVocacionalAPI.Models;

namespace OrientadorVocacionalAPI.Repositories
{
    public class SesionRepository
    {
        private readonly Connection _connection;

        public SesionRepository()
        {
            _connection = new Connection();
        }

    }
}
